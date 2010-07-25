using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using StrengthReport.Templating;
using StrengthReport.Layouting;

namespace StrengthReport.Reporting.ReportFormat {
    /// <summary>
    /// Represents a report format, with some basic operations implemented.
    /// </summary>
    public abstract class ReportAbstract : IReport {
        /// <summary>
        /// The output file's path
        /// </summary>
        protected Stream m_Output;

        /// <summary>
        /// The layout (list of columns) of the report.
        /// </summary>
        protected Layout m_Layout;

        /// <summary>
        /// Misc configuration parameters vary for each ReportFormat
        /// </summary>
        protected Dictionary<string, string> m_ConfigParams;

        /// <summary>
        /// Defines a style for the layout, it contains the background and font informations.
        /// </summary>
        protected Template m_Template;

        /// <summary>
        /// Title of the report document
        /// </summary>
        protected string m_Title;

        /// <summary>
        /// Creates a new ReportAbstract, it used in children as base() when contructing.
        /// </summary>
        /// <param name="Filename">The output file's path</param>
        /// <param name="layout">The layout (list of columns) of the report.</param>
        /// <param name="ConfigParams">Misc configuration parameters vary for each ReportFormat</param>
        public ReportAbstract(Stream output, Layout layout, Template template, Dictionary<string, string> configParams) {
            m_Output       = output;
            m_Layout       = layout;
            m_Template     = template;
            m_ConfigParams = configParams;
        }

        /// <summary>
        /// The output stream
        /// </summary>
        public Stream Output {
            get { return m_Output; }
        }

        /// <summary>
        /// The layout (list of columns) of the report
        /// </summary>
        public Layout Layout {
            get { return m_Layout; }
        }

        /// <summary>
        /// The Template of the current ReportFormat, it defines the colors, style, size, fonts.
        /// </summary>
        public Template Template {
            get { return m_Template; }
        }

        /// <summary>
        /// Set the title of the report.
        /// </summary>
        public string Title {
            get { return m_Title; }
            set { m_Title = value; }
        }

        /// <summary>
        /// Adds a new row witch representr an entry from DB into the Report, continually.
        /// </summary>
        /// <param name="data"></param>
        public abstract void AddRow(string[] data);

        /// <summary>
        /// Adds a new row which represents a Group (title)
        /// </summary>
        /// <param name="title"></param>
        public abstract void AddGroup(string title);

        /// <summary>
        /// Finishes the report.
        /// </summary>
        public abstract void Close();


    }
}
