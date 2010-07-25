using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using StrengthReport.Templating;
using StrengthReport.Layouting;

namespace StrengthReport.Reporting.ReportFormat {
    /// <summary>
    /// PDF output fileformat.
    /// </summary>
    class ReportPdf : ReportAbstract {
        private Document m_Document;
        public Document Document {
            get { return m_Document; }
        }

        private PdfPTable m_Table;
        private CMYKColor[] m_colorRow;
        private int m_rowCount = 0;

        public PdfPTable Table {
            get { return m_Table; }
        }

        private PdfWriter m_Writer;

        private static float mm2pt(float mm) {
            return mm / (float)25.4 * 72;
        }

        private static float cm2pt(float cm) {
            return cm / (float)2.54 * 72;
        }

        public ReportPdf(Stream Output, Layout Layout, Template Template, Dictionary<string, string> ConfigParams)
            : base(Output, Layout, Template, ConfigParams) {

            Rectangle pageSize = new Rectangle(mm2pt(Template.PageSize.Width), mm2pt(Template.PageSize.Height));

            // Initialization
            m_Document = new Document(pageSize, mm2pt(Template.Margin.Left), mm2pt(Template.Margin.Right), mm2pt(Template.Margin.Top), mm2pt(Template.Margin.Bottom));
            m_Writer = PdfWriter.GetInstance(m_Document, Output);

            m_Document.AddCreationDate();
            m_Document.AddCreator("StrengthReport http://dev.progterv.info/strengthreport) and KeePass (http://keepass.info)");
            m_Document.AddKeywords("report");
            m_Document.AddTitle(Layout.Title+" (report)");

            // Header
            HeaderFooter header = new HeaderFooter(new Phrase(Layout.Title+", "+DateTime.Now.ToString(), m_Template.ReportFooter.getFont()), false);
            header.Alignment = Template.ReportFooter.getAlignment();
            m_Document.Header = header;

            // Footer
            HeaderFooter footer = new HeaderFooter(new Phrase(new Chunk("Page ", m_Template.ReportFooter.getFont())), new Phrase(new Chunk(".", m_Template.ReportFooter.getFont())));
            footer.Alignment = Template.ReportFooter.getAlignment();
            m_Document.Footer = footer;

            // TODO: Metadata
            // Open document
            m_Document.Open();

            // Report Heading
            {
                PdfPTable reportTitle = new PdfPTable(1);
                PdfPCell titleCell = new PdfPCell(new Phrase(Layout.Title, m_Template.ReportHeader.getFont()));
                titleCell.Border = 0;
                titleCell.FixedHeight = mm2pt(m_Template.ReportHeader.Height);
                titleCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                titleCell.HorizontalAlignment = m_Template.ReportHeader.getAlignment();
                reportTitle.AddCell(titleCell);
                reportTitle.WidthPercentage = 100;
                m_Document.Add(reportTitle);
            }

            // Create main table
            m_Table = new PdfPTable(Layout.GetColumnWidths());
            m_Table.WidthPercentage = 100;
            m_Table.HeaderRows = 1;
            foreach (LayoutElement element in Layout) {
                PdfPCell cell = new PdfPCell(new Phrase(element.Title, m_Template.Header.getFont()));
                cell.BackgroundColor = m_Template.Header.Background.ToColor();
                cell.MinimumHeight = mm2pt(m_Template.Header.Height);
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                m_Table.AddCell(cell);
            }

            m_colorRow = new CMYKColor[] { m_Template.Row.BackgroundA.ToColor(), m_Template.Row.BackgroundB.ToColor() };
        }

        public override void AddGroup(string title) {
            PdfPCell cell = new PdfPCell(new Phrase(title, Template.GroupHeading.getFont()));
            cell.BackgroundColor = m_Template.GroupHeading.Background.ToColor();
            cell.MinimumHeight = mm2pt(m_Template.GroupHeading.Height);
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Colspan = Layout.Count;
            Table.AddCell(cell);
        }

        public override void AddRow(string[] data) {
            foreach (string d in data) {
                PdfPCell cell = new PdfPCell(new Phrase(d, m_Template.Row.getFont()));
                cell.BackgroundColor = m_colorRow[m_rowCount % 2];
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.MinimumHeight = mm2pt(m_Template.Row.Height);
                m_Table.AddCell(cell);
            }
            m_rowCount++;
        }

        public override void Close() {
            m_Document.Add(m_Table);
            m_Document.Close();
        }

    }
}
