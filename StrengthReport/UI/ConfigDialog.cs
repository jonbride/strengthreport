using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KeePass.UI;
using KeePass.Properties;
using KeePass.Plugins;
using KeePassLib;
using StrengthReport.Reporting;
using System.IO;
using StrengthReport.Templating;
using StrengthReport.Layouting;
using System.Xml.Serialization;


namespace StrengthReport.UI {
    public partial class ConfigDialog : Form {
        static string w_Title = "StrengthReport";
        static string w_Desc = "Create a report about your passwords' stength";
        static Icon   w_Icon = new Icon(Resources.StrengthReport, 48, 48);

        IPluginHost m_PluginHost;
        private Layout m_Layout;
        private TemplateBox m_TemplateBox;
        private LayoutBox m_LayoutBox;
        private Filter m_Filter = null;

        public ConfigDialog(IPluginHost pluginHost) {
            InitializeComponent();
            m_PluginHost = pluginHost;

            if (File.Exists("StrengthReportLayouts.xml")) {
                m_LayoutBox = LayoutBox.LoadFromFile("StrengthReportLayouts.xml");
            } else {
                m_LayoutBox = LayoutBox.LoadFromString(Resources.LayoutsDefault);
            }

            foreach (Layout l in m_LayoutBox)
                layoutBoxBindingSource.Add(l);

            if (File.Exists("StrengthReportTemplates.xml")) {
                m_TemplateBox = TemplateBox.LoadFromFile("StrengthReportTemplates.xml");
            } else {
                m_TemplateBox = TemplateBox.LoadFromString(Resources.TemplatesDefault);
            }

            foreach (Template l in m_TemplateBox)
                templatesBinginSource.Add(l);

            tabFormat.SelectedIndex = 1;
        }

        private void ConfigDialog_Load(object sender, EventArgs e) {
            doHeader();

            PwGroup root = m_PluginHost.Database.RootGroup;
            treeGroups.BeginUpdate();
            treeGroups.Nodes.Clear();
            if (root != null) {
                fillTree(null, root);
                treeGroups.Nodes[0].Expand();
            }
            treeGroups.EndUpdate();

        }

        private void fillTree(TreeNode root, PwGroup item) {
            TreeNode new_root = new MyNode(item);
            new_root.Checked = true;
            if (root == null) {
                treeGroups.Nodes.Add(new_root);
            } else {
                root.Nodes.Add(new_root);
            }
            foreach (PwGroup sub in item.Groups) {
                fillTree(new_root, sub);
            }
            
        }

        private void radioHTML_CheckedChanged(object sender, EventArgs e) {

        }

        private List<PwGroup> getSelectedGroups(TreeNodeCollection Nodes) {
            List<PwGroup> list = new List<PwGroup>();
            foreach(TreeNode node in Nodes) {
                if (node.Checked) list.Add((PwGroup)node.Tag);
                list.AddRange(getSelectedGroups(node.Nodes));
            }
            return list;
        }

        private void button1_Click(object sender, EventArgs e) {
            /* Checklist for parameters:
             * C Stream Output, 
             * C string Format, 
             * C Layout Layout, 
             * ? Template Template,
             * C List<PwGroup> Groups, 
             * ? Dictionary<string, string> ConfigParams
             */


            Stream Output = null;
            string Format = "";
            Layout Layout = (Layout)comboLayout.SelectedItem;
            Template Template = (Template)comboTemplate.SelectedItem;
            List<PwGroup> Groups = getSelectedGroups(treeGroups.Nodes);
            Dictionary<string, string> ConfigParams = new Dictionary<string, string>();

            saveFileDialog.DefaultExt = "";

            if (tabFormat.SelectedTab == tabPageScreen) {
                Format = "SCREEN";
            } else if (tabFormat.SelectedTab == tabPagePDF) {
                Format = "PDF";
                saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                saveFileDialog.DefaultExt = "pdf";
            } else if (tabFormat.SelectedTab == tabPageHTML) {
                Format = "HTML";
                saveFileDialog.Filter = "HTML (*.html)|*.html";
                saveFileDialog.DefaultExt = "html";
            } else if (tabFormat.SelectedTab == tabPageCSV) {
                Format = "CSV";
                saveFileDialog.Filter = "Comma separated text (*.csv)|*.csv";
                saveFileDialog.DefaultExt = "csv";
            }

            //TODO: SORRY NOT IMPLEMENTED

            saveFileDialog.AddExtension = true;
            
            if (saveFileDialog.DefaultExt.Length != 0) {
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    Output = saveFileDialog.OpenFile();
                }

                if (Output == null) {
                    MessageBox.Show("Error during opening output file!");
                    return;
                }
            }

            if (Layout == null) {
                MessageBox.Show("Layout not selected!");
                return;
            }


            ReportConfig config = new ReportConfig(Output, Format, Layout, Template, Groups, ConfigParams);

            GeneratingForm genform = new GeneratingForm(config);
            genform.ShowDialog();
            Close();
        }

        private void collapsibleGroupBox1_Load(object sender, EventArgs e) {

        }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }

        private void button3_Click(object sender, EventArgs e) {
            int Index = comboLayout.SelectedIndex;
            if (Index >= 0) {
                Layout l = (Layout)layoutBoxBindingSource[Index];
                if (l == null) l = new Layout();

                LayoutEditor editor = new LayoutEditor(l);
                if (editor.ShowDialog() == DialogResult.OK) {
                    layoutBoxBindingSource[Index] = editor.ReportLayout;
                    layoutBoxBindingSource.ResetCurrentItem();
                }
            }
        }

        private void doHeader() {
            this.Text = w_Title;
            m_bannerImage.Image = BannerFactory.CreateBanner(m_bannerImage.Width,
                m_bannerImage.Height, BannerStyle.Default,
                w_Icon.ToBitmap(), w_Title, w_Desc);
        }

        private void ConfigDialog_SizeChanged(object sender, EventArgs e) {
            doHeader();
        }

        private void btnLayoutManager_Click(object sender, EventArgs e) {
            Object selected = comboLayout.SelectedItem;
            LayoutBoxEditor layoutBoxEditor = new LayoutBoxEditor(layoutBoxBindingSource);
            layoutBoxEditor.ShowDialog();
            layoutBoxBindingSource.Clear();
            foreach(Object o in layoutBoxEditor.Layouts) {
                layoutBoxBindingSource.Add(o);
            }
            comboLayout.SelectedItem = selected;
        }

        private void ConfigDialog_FormClosing(object sender, FormClosingEventArgs e) {
            LayoutBox lb = new LayoutBox();
            foreach (Object o in layoutBoxBindingSource) {
                Layout l = (Layout)o;
                lb.Add(l);
            }
            lb.SaveToFile();

            m_TemplateBox.SaveToFile("StrengthReportTemplates.xml");
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }


    }

    class MyNode : TreeNode {
        private PwGroup m_group;

        public MyNode(PwGroup group) {
            base.Tag = group;
            base.Text = group.Name;
        }


        public PwGroup Group { get { return (PwGroup)base.Tag; } }
    }

}
