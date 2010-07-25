using System;
using System.Collections.Generic;
using System.Text;
using StrengthReport.Reporting;
using StrengthReport.Reporting.ReportFormat;
using KeePassLib;
using System.Collections;

namespace StrengthReport {
    public class ReportEngine {
        #region Fields
        private ReportConfig m_Config;
        private IReport m_Report;
        #endregion

        #region Properties
        public IReport Report { get { return m_Report; } }
        #endregion

        #region Constructor
        public ReportEngine(ReportConfig config) {
            m_Config = config;

        }
        #endregion

        public static string GetGroupPath(PwGroup group) {
            string path = GetGroupPathRec(group);
            if (path.Length > 0) {
                return path;
            } else {
                return "(Root)";
            }
        }

        private static string GetGroupPathRec(PwGroup group) {
            if (group.ParentGroup != null) {
                string parent = GetGroupPathRec(group.ParentGroup);
                return parent + (parent.Length > 0 ? "/" : "") + group.Name;
            } else {
                // Empty, because we don't need the name of DB in path, which is the root.
                return "";
            }
        }


        #region Methods

        public void CreateReport() {
            m_Report = ReportFactory.Create(m_Config.Format, m_Config.Output, m_Config.Layout, m_Config.Template, m_Config.ConfigParams);
            foreach (PwGroup group in m_Config.Groups) {
                m_Report.AddGroup(GetGroupPath(group));
                foreach (PwEntry entry in group.Entries) {
                    string[] data = new string[m_Config.Layout.Count];
                    bool rowEnabled = true;
                    for (int i = 0; i < m_Config.Layout.Count; i++) {
                        data[i] = m_Config.Layout[i].EvaluateString(entry);
                        if (m_Config.Layout[i].Filter.Enabled)
                            if (!m_Config.Layout[i].Filter.Evaluate(data[i])) {
                                rowEnabled = false;
                                break;
                            }
                    }
                    if (rowEnabled) m_Report.AddRow(data);
                }
            }
            
            if (ReportDoneEvent != null)
                ReportDoneEvent(this, null);

            m_Report.Close();
        }

        public event EventHandler<EventArgs> ReportDoneEvent;

        #endregion
    }
}
