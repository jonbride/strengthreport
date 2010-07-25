/// <author>Peter Torok (torok.peter@progterv.info)</author>

using System;
using System.Collections.Generic;
using System.Text;
using StrengthReport.Reporting;
using KeePassLib;
using System.IO;
using StrengthReport.Templating;
using StrengthReport.Layouting;

namespace StrengthReport.Reporting {
    public class ReportConfig {
        #region Fields
        private Stream m_Output;
        private string m_Format;
        private Layout m_Layout;
        private Template m_Template;
        private List<PwGroup> m_Groups;
        private Dictionary<string, string> m_ConfigParams;
        #endregion

        #region Properties
        public Stream Output { get { return m_Output; } }
        public string Format { get { return m_Format; } }
        public Layout Layout { get { return m_Layout; } }
        public Template Template { get { return m_Template; } }
        public IList<PwGroup> Groups { get { return m_Groups; } }
        public Dictionary<string, string> ConfigParams { get { return m_ConfigParams; } }
        
        #endregion

        public ReportConfig(Stream output, string format, Layout layout, Template template, List<PwGroup> groups, Dictionary<string, string> configParams) {
            m_Output = output;
            m_Format = format;
            m_Layout = layout;
            m_Template = template;
            m_Groups = groups;
            m_ConfigParams = configParams;
        }
    }
}
