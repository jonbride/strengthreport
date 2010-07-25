using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StrengthReport.Reporting;
using StrengthReport.Layouting;

namespace StrengthReport.UI {
    public partial class ParametersForm : Form {
        private DataElement m_Selected;
        public DataElement Selected { get { return m_Selected; } }

        public ParametersForm() {
            InitializeComponent();
        }

        private void ParametersForm_Load(object sender, EventArgs e) {

            foreach (DataElement elem in DataElementList.Standard)
                dataElementsBindingSource.Add(elem);
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            m_Selected = (DataElement)listParams.SelectedItem;
        }

        private void listParams_SelectedIndexChanged(object sender, EventArgs e) {
           
        }
    }
}
