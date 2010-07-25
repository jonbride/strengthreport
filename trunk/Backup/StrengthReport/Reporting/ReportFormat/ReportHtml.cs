/// <author>Peter Torok (torok.peter@peter.hu)</author>

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using StrengthReport.Templating;
using StrengthReport.Layouting;
using System.Globalization;

namespace StrengthReport.Reporting.ReportFormat {
    /// <summary>
    /// HTML-format for reporing. Own engine by Peter Torok (torok.peter@progterv.info)
    /// </summary>
    public class ReportHtml : ReportAbstract {

        private StreamWriter writer;
        private int m_RowCount = 0;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Output">The output stream (usually redirected to a file), upper level responsibility.</param>
        /// <param name="Layout">The content layout (columns, ...)</param>
        /// <param name="Template">Design</param>
        /// <param name="ConfigParams">Misc parameteres</param>
        public ReportHtml(Stream output, Layout layout, Template template, Dictionary<string,string> configParams)
            : base(output, layout, template, configParams) {
            writer = new StreamWriter(output);
            Open();
            AddReportHeader();
            AddTableStart();
            AddTableHeader();
        }

        
        private void AddReportHeader() {
            writer.WriteLine("<h1>" + Layout.Title + "</h1><h2>" + DateTime.Now.ToString() + "</h2>");
        }

        private void AddTableStart() {
            writer.WriteLine("<table width='100%' cellspacing='0' cellpadding='4' border='1'>");
        }

        private void AddTableHeader() {
            double width = Layout.Width;
            writer.WriteLine("<thead>");
            writer.WriteLine("\t<tr>");

            for (int i = 0; i < Layout.Count; i++) {
                writer.WriteLine("\t\t<td width='"+((Layout[i].Width/width)*100)+"%'>" + Layout[i].Title + "</td>");
            }

            writer.WriteLine("\t</tr>");
            writer.WriteLine("</thead>");
            writer.WriteLine("<tbody>");
        }

        private void AddTableEnd() {
            writer.WriteLine("</tbody>");
            writer.WriteLine("</table>");
        }

        public override void AddRow(string[] data) {
            writer.WriteLine("\t<tr class='r"+(m_RowCount%2).ToString()+"'>");
            for (int i = 0; i < data.Length; i++) {
                writer.WriteLine("\t\t<td>" + data[i] + "</td>");
            }
            writer.WriteLine("\t</tr>");
            m_RowCount++;
        }

        public void Open() {
            
            writer.WriteLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<title>"+Layout.Title+"</title>");
            writer.WriteLine("<style>");
            writer.WriteLine((new CssFactory(Template)).ToString());
            writer.WriteLine("</style>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
        }

        public override void Close() {
            AddTableEnd();
            writer.WriteLine("<div id='footer'>Contains <i>"+m_RowCount.ToString()+" rows</i>. Generated with <a href='http://dev.progterv.info/strengthreport' alt='StrengthReport homepage'>StrengthReport</a> (a <a href='http://keepass.info' alt='KeePass homepage'>KeePass</a> plugin).</div>");
            writer.WriteLine("</body></html>");
            writer.Close();
        }

        public override void AddGroup(string title) {
            writer.WriteLine("\t<tr><td colspan='"+Layout.Count+"' class='group'>" + title + "</td></tr>");
        }
    }

    class CssWriter : Utf8StringWriter {
        public CssWriter() : base() { }

        public void AddRaw(string rawData) {
            this.WriteLine(rawData);
        }

        public void Add(string key, double value) {
            this.WriteLine("\t" + key + ": " + value.ToString("#,00.0", CultureInfo.InvariantCulture) + "pt" + ";");
        }

        public void Add(string key, string value) {
            this.WriteLine("\t"+key + ": " + value + ";");
        }

        public void Add(StyleAlignment alignment) {
            Add("text-align", alignment.ToString());
        }

        public void Add(Style style) {
            Add(style.Alignment);
            Add("background", style.Background.GetHex());
            Add(style.Font);
        }

        public void Add(Font font) {
            Add("font-family", font.FontName);

            switch(font.FontStyle) {
                case FontFontStyle.Bold:
                    Add("font-weight", "bold");
                    break;
                case FontFontStyle.BoldItalic:
                    Add("font-weight", "bold");
                    Add("font-style", "italic");
                    break;
                case FontFontStyle.Italic:
                    Add("font-style", "italic");
                    break;
            }

            Add("color", font.Color.GetHex());
            Add("font-size", font.Size);
        }


        public void Begin(string section) {
            this.WriteLine(section + " {");
        }

        public void End() {
            this.WriteLine("}");
        }
    }

    /// <summary>
    /// Generates CSS-style from given <see>Template</see>
    /// </summary>
    class CssFactory {

        private Template m_Template;
        public CssFactory(Template template) {
            m_Template = template;
        }

        private string getStyle() {
            CssWriter writer = new CssWriter();

            double ratio = 0.015;
            writer.Begin("body");
            writer.Add("margin", m_Template.Margin.Top*ratio + "cm " + m_Template.Margin.Right*ratio + "cm " + m_Template.Margin.Bottom*ratio + "cm " + m_Template.Margin.Left*ratio + "cm");
            writer.Add(m_Template.ReportHeader);
            writer.End();

            writer.Begin("tbody tr td");
            writer.Add(m_Template.Row);
            writer.End();

            writer.Begin("tbody tr.r0 td");
            writer.Add("background", m_Template.Row.BackgroundA.GetHex());
            writer.End();

            writer.Begin("tbody tr.r1 td");
            writer.Add("background", m_Template.Row.BackgroundB.GetHex());
            writer.End();

            writer.Begin("thead tr td");
            writer.Add(m_Template.Header);
            writer.End();

            writer.Begin("td.group");
            writer.Add(m_Template.GroupHeading);
            writer.End();

            writer.Begin("h1, h2");
            writer.Add(m_Template.ReportHeader);
            writer.Add("margin-bottom", "4px");
            writer.End();

            writer.Begin("h2");
            writer.Add("font-size", (m_Template.ReportHeader.Font.Size * 0.8));
            writer.Add("margin-top", "0px");
            writer.Add("margin-bottom", "10px");
            writer.End();

            writer.Begin("#footer");
            writer.Add("margin-top", "6px");
            writer.Add(m_Template.ReportFooter); 
            writer.End();

            return writer.ToString();
        }

        public override string ToString() {
            return this.getStyle();
        }
    }
}
