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
using StrengthReport.Measuring;

namespace StrengthReport.UI {
    public partial class LayoutEditor : Form {
        static string w_Title = "Layout editor";
        static string w_Desc = "Edit the columns of the report";
        static Icon   w_Icon = new Icon(Resources.StrengthReport, 48, 48);

        string m_LayoutName;

        #region Properties
        public Layout ReportLayout {
            get {
                Layout Layout = new Layout();
                Layout.Name = m_LayoutName;
                foreach (Object o in layoutBindingSource) {
                    if (o is LayoutElement)
                        Layout.Add((LayoutElement)o);
                }
                return Layout;
            }
        }

        #endregion

        public LayoutEditor(Layout layout) {
            InitializeComponent();

            m_LayoutName = layout.Name;
            foreach (LayoutElement element in layout)
                layoutBindingSource.Add(element);
        }

        private void LayoutEditor_Load(object sender, EventArgs e) {
            doHeader();

            DataElementList dataElements = DataElementList.Standard;
            foreach (DataElement element in dataElements) {
                comboFunction.Items.Add(element);
            }

            txtLayoutName.Text = m_LayoutName;
            if (layoutBindingSource.Count > 0)
                layoutBindingSource.Position = 0;
            layoutBindingSource.ResetCurrentItem();

        }


        private void btnAdd_Click(object sender, EventArgs e) {
            LayoutElement elem = new LayoutElement();
            elem.Title = "New item " + (layoutBindingSource.Count + 1);
            elem.Data = new DataElement(EntryDataType.UserName);
            elem.Filter = new Filter();
            layoutBindingSource.Add(elem);

        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (listLayoutElements.SelectedItem != null) {
                if (MessageBox.Show("Do you really want to remove the selected item from the list?", "Delete comfirmation", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    layoutBindingSource.RemoveAt(listLayoutElements.SelectedIndex);
                }
            }

        }

        private void btnUp_Click(object sender, EventArgs e) {
            
            int Index = listLayoutElements.SelectedIndex;
            LayoutElement Swap = null;      //Selected Item
            if (Index > 0) {               //If something is selected...
                Swap = (LayoutElement)layoutBindingSource[Index - 1];   //Selected Item
                layoutBindingSource.RemoveAt(Index - 1);                //Remove it
                layoutBindingSource.Insert(Index, Swap);        //Add it back in one spot up
                //listLayoutElements.SelectedItem = Swap;             //Keep this item selected
            }
        }

        private void btnDown_Click(object sender, EventArgs e) {
            int Index = listLayoutElements.SelectedIndex;          //Selected Index
            LayoutElement Swap = null;      //Selected Item

            if (Index >= 0 && Index + 1 < listLayoutElements.Items.Count) {               //If something is selected...
                Swap = (LayoutElement)layoutBindingSource[Index];      //Selected Item
                layoutBindingSource.RemoveAt(Index);                 //Remove it
                layoutBindingSource.Insert(Index + 1, Swap);        //Add it back in one spot up
                listLayoutElements.SelectedItem = Swap;                   //Keep this item selected
            }
        }

        private void listLayoutElements_SelectedIndexChanged(object sender, EventArgs e) {
            
        }

        private void comboFunction_SelectedIndexChanged(object sender, EventArgs e) {
            //Bind filter
            LayoutElement el = (LayoutElement)layoutBindingSource.Current;
            DataElement de = (DataElement)comboFunction.SelectedItem;

            if (de != null) {
                if (de.IsFunction) {
                    comboComparator.Items.Clear();
                    comboComparator.Items.AddRange(Filter.ComparatorPasswordQuality);
                    comboCompareWith.Items.Clear();
                    comboCompareWith.Items.AddRange(Enum.GetNames(typeof(PasswordQuality)));
                    comboCompareWith.DropDownStyle = ComboBoxStyle.DropDownList;
                } else {
                    comboComparator.Items.Clear();
                    comboComparator.Items.AddRange(Filter.ComparatorString);
                    comboCompareWith.Items.Clear();
                    comboCompareWith.DropDownStyle = ComboBoxStyle.DropDown;
                }

                if (el.Filter.Comparator != null && comboComparator.Items.Contains(el.Filter.Comparator))
                    comboComparator.SelectedItem = el.Filter.Comparator;
                else
                    comboComparator.SelectedItem = null;

                if (el.Filter.CompareWith != null) {
                    if ((de.IsFunction && comboCompareWith.Items.Contains(el.Filter.CompareWith)))
                        comboCompareWith.SelectedItem = el.Filter.CompareWith;
                    if (!de.IsFunction)
                        comboCompareWith.Text = el.Filter.CompareWith;
                } else {
                    comboCompareWith.Text = el.Filter.CompareWith;
                }

                checkFilter.Checked = el.Filter.Enabled;
            }
        }

        private void txtLayoutName_TextChanged(object sender, EventArgs e) {
            m_LayoutName = txtLayoutName.Text;
        }

        private void LayoutEditor_SizeChanged(object sender, EventArgs e) {
            doHeader();
        }

        private void doHeader() {
            this.Text = w_Title;
            m_bannerImage.Image = BannerFactory.CreateBanner(m_bannerImage.Width,
                m_bannerImage.Height, BannerStyle.Default,
                w_Icon.ToBitmap(), w_Title, w_Desc);
        }

        private void comboComparator_SelectedIndexChanged(object sender, EventArgs e) {
            LayoutElement el = (LayoutElement)layoutBindingSource.Current;
            el.Filter.Comparator = comboComparator.Text;
            //layoutBindingSource.ResetCurrentItem();
        }

        private void layoutBindingSource_PositionChanged(object sender, EventArgs e) {
            LayoutElement element = (LayoutElement)layoutBindingSource.Current;

            if (element.Filter == null) {
                element.Filter = new Filter();
            }
            comboFunction_SelectedIndexChanged(sender, e);

        }

        private void comboCompareWith_TextUpdate(object sender, EventArgs e) {
            LayoutElement el = (LayoutElement)layoutBindingSource.Current;
            el.Filter.CompareWith = comboCompareWith.Text;
            //layoutBindingSource.ResetCurrentItem();
        }

        private void comboCompareWith_SelectedIndexChanged(object sender, EventArgs e) {
            LayoutElement el = (LayoutElement)layoutBindingSource.Current;
            el.Filter.CompareWith = (string) comboCompareWith.SelectedItem;
            //layoutBindingSource.ResetCurrentItem();
        }

        private void checkFilter_CheckedChanged(object sender, EventArgs e) {
            LayoutElement element = (LayoutElement)layoutBindingSource.Current;
            element.Filter.Enabled = checkFilter.Checked;
        }
      
    }

    

}
