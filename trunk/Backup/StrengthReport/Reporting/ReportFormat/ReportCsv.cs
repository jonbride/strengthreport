using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using StrengthReport.Layouting;

namespace StrengthReport.Reporting.ReportFormat {
    class ReportCsv : ReportAbstract {
        private StreamWriter m_StreamWriter;
        private string m_SeparatorSign = ";";

        public ReportCsv(Stream output, StrengthReport.Layouting.Layout layout, StrengthReport.Templating.Template template, Dictionary<string, string> configParams)
            : base(output, layout, template, configParams) {
            m_StreamWriter = new StreamWriter(m_Output);

            foreach (LayoutElement item in Layout) {
                m_StreamWriter.Write(item.Title);
                m_StreamWriter.Write(m_SeparatorSign);
            }
            m_StreamWriter.WriteLine();

        }

        /// <summary>
        /// Adds a <see>SeparatorSign</see> separated row of items in data.
        /// </summary>
        /// <param name="data">The data written to the CSV.</param>
        public override void AddRow(string[] data) {
            foreach (string item in data) {
                m_StreamWriter.Write(item);
                m_StreamWriter.Write(m_SeparatorSign);
            }
            m_StreamWriter.WriteLine();
        }

        /// <summary>
        /// Adds a one-item row, with the title.
        /// </summary>
        /// <param name="title"></param>
        public override void AddGroup(string title) {
            m_StreamWriter.WriteLine(title);
        }

        /// <summary>
        /// Close output streamwriter and underlaying stream (the file usually).
        /// </summary>
        public override void Close() {
            m_StreamWriter.Close();
        }
    }
}
