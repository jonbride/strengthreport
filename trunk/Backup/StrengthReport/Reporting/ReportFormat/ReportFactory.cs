using System;
using System.Collections.Generic;
using System.Text;
using StrengthReport.Exceptions;
using System.IO;
using StrengthReport.Templating;
using StrengthReport.Layouting;

namespace StrengthReport.Reporting.ReportFormat {
    /// <summary>
    /// Creates a new instance from ReportAbstract's children based a string given, the other params passed through.
    /// </summary>
    class ReportFactory {
        private ReportFactory() { }

        /// <summary>
        /// Creates a new instance from ReportAbstract's children based a string given, the other params passed through.
        /// </summary>
        /// <param name="Format">Which class be used: PDF, HTML, SCREEN</param>
        /// <param name="Filename">The output file's path (if Screen used: "")</param>
        /// <param name="Layout">The layout of report.</param>
        /// <param name="ConfigParams">Misc config params, vary each backend.</param>
        /// <returns>A new report visualisation engine.</returns>
        public static IReport Create(string Format, Stream Output, Layout Layout, Template Template, Dictionary<string, string> ConfigParams) {
            switch (Format.ToUpper()) {
                case "PDF":
                    return new ReportPdf(Output, Layout, Template, ConfigParams);
                    
                case "HTML":
                    return new ReportHtml(Output, Layout, Template, ConfigParams);
                    
                case "SCREEN":
                    return new ReportScreen(Layout, ConfigParams);
                    
                case "CSV":
                    return new ReportCsv(Output, Layout, Template, ConfigParams);

                default:
                    throw new NoReportTypeException();
            }
            
        }

    }
}
