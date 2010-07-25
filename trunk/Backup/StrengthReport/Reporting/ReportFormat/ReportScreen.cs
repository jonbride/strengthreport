using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using StrengthReport.Layouting;

namespace StrengthReport.Reporting.ReportFormat {
    class ReportScreen : ReportAbstract {
        private DataTable m_DataTable;
        // TODO:Template in Screen
        public ReportScreen(Layout Layout, Dictionary<string, string> ConfigParams) : base(null, Layout, null, ConfigParams) {
            m_Layout = Layout;
            m_DataTable = new DataTable();
            foreach (LayoutElement e in m_Layout) {
                DataColumn column = new DataColumn(e.Title, typeof(string));
                m_DataTable.Columns.Add(column);
            }
        }
        
        public override void AddRow(string[] data) {
            /*
            DataRow row = new DataRow();
            row.ItemArray = data;
            m_DataTable.Rows.Add(row);
            */
            m_DataTable.Rows.Add(data);
        }

        public override void Close() {
            ReportScreenForm form = new ReportScreenForm(m_Layout.Name, m_DataTable);
            form.ShowDialog();
        }

        public override void AddGroup(string title) {
            // SKIP
        }

    }
}
