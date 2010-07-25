using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KeePass.UI;
using StrengthReport.Reporting;
using StrengthReport.Layouting;

namespace StrengthReport.UI {
    public partial class LayoutBoxEditor : Form {

        static string w_Title = "LayoutBox";
        static string w_Desc = "Here you can manage the layouts";
        static Icon w_Icon = new Icon(Resources.StrengthReport, 48, 48);

        public BindingSource Layouts { get { return layoutBoxBindingSource; } }

        public LayoutBoxEditor(BindingSource layoutBoxBS) {
            InitializeComponent();
            foreach (Object o in layoutBoxBS)
                layoutBoxBindingSource.Add(o);

            
        }

        private void doHeader() {
            this.Text = w_Title;
            m_bannerImage.Image = BannerFactory.CreateBanner(m_bannerImage.Width,
                m_bannerImage.Height, BannerStyle.Default,
                w_Icon.ToBitmap(), w_Title, w_Desc);
        }

        private void LayoutBoxEditor_Load(object sender, EventArgs e) {
            doHeader();
        }

        private void LayoutBoxEditor_SizeChanged(object sender, EventArgs e) {
            doHeader();
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        private void btnAdd_Click(object sender, EventArgs e) {
            Layout layout = new Layout();
            layout.Name = "Untitled";
            layoutBoxBindingSource.Add(layout);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (listLayout.SelectedIndex >= 0 && MessageBox.Show("Are you sure to delete the selected layout?", "Really delete?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                layoutBoxBindingSource.RemoveAt(listLayout.SelectedIndex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            int Index = listLayout.SelectedIndex;
            if (Index >= 0) {
                LayoutEditor editor = new LayoutEditor((Layout)layoutBoxBindingSource[Index]);
                if (editor.ShowDialog() == DialogResult.OK) {
                    layoutBoxBindingSource[Index] = editor.ReportLayout;
                    layoutBoxBindingSource.ResetCurrentItem();
                }
            }

        }

        private void listLayout_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void listLayout_DoubleClick(object sender, EventArgs e) {
            btnEdit_Click(sender, e);
        }
    }
}
