namespace StrengthReport.UI {
    partial class LayoutEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.m_bannerImage = new System.Windows.Forms.PictureBox();
            this.listLayoutElements = new System.Windows.Forms.ListBox();
            this.layoutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkFilter = new System.Windows.Forms.CheckBox();
            this.comboCompareWith = new System.Windows.Forms.ComboBox();
            this.comboComparator = new System.Windows.Forms.ComboBox();
            this.groupHelp = new System.Windows.Forms.GroupBox();
            this.textHelp = new System.Windows.Forms.TextBox();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.comboFunction = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLayoutName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_bannerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // m_bannerImage
            // 
            this.m_bannerImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_bannerImage.Location = new System.Drawing.Point(0, 0);
            this.m_bannerImage.Name = "m_bannerImage";
            this.m_bannerImage.Size = new System.Drawing.Size(608, 60);
            this.m_bannerImage.TabIndex = 5;
            this.m_bannerImage.TabStop = false;
            // 
            // listLayoutElements
            // 
            this.listLayoutElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listLayoutElements.DataSource = this.layoutBindingSource;
            this.listLayoutElements.DisplayMember = "TitleExt";
            this.listLayoutElements.FormattingEnabled = true;
            this.listLayoutElements.Location = new System.Drawing.Point(12, 110);
            this.listLayoutElements.Name = "listLayoutElements";
            this.listLayoutElements.Size = new System.Drawing.Size(198, 238);
            this.listLayoutElements.TabIndex = 6;
            this.listLayoutElements.SelectedIndexChanged += new System.EventHandler(this.listLayoutElements_SelectedIndexChanged);
            // 
            // layoutBindingSource
            // 
            this.layoutBindingSource.DataSource = typeof(StrengthReport.Layouting.Layout);
            this.layoutBindingSource.PositionChanged += new System.EventHandler(this.layoutBindingSource_PositionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 354);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(45, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(63, 354);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(45, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Del";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Location = new System.Drawing.Point(114, 354);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(45, 23);
            this.btnUp.TabIndex = 9;
            this.btnUp.Text = "/\\";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Location = new System.Drawing.Point(165, 354);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(45, 23);
            this.btnDown.TabIndex = 10;
            this.btnDown.Text = "\\/";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkFilter);
            this.groupBox1.Controls.Add(this.comboCompareWith);
            this.groupBox1.Controls.Add(this.comboComparator);
            this.groupBox1.Controls.Add(this.groupHelp);
            this.groupBox1.Controls.Add(this.numWidth);
            this.groupBox1.Controls.Add(this.comboFunction);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(216, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 238);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // checkFilter
            // 
            this.checkFilter.AutoSize = true;
            this.checkFilter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkFilter.Location = new System.Drawing.Point(5, 177);
            this.checkFilter.Name = "checkFilter";
            this.checkFilter.Size = new System.Drawing.Size(101, 19);
            this.checkFilter.TabIndex = 17;
            this.checkFilter.Text = "Filter enabled";
            this.checkFilter.UseVisualStyleBackColor = true;
            this.checkFilter.CheckedChanged += new System.EventHandler(this.checkFilter_CheckedChanged);
            // 
            // comboCompareWith
            // 
            this.comboCompareWith.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCompareWith.FormattingEnabled = true;
            this.comboCompareWith.Location = new System.Drawing.Point(209, 175);
            this.comboCompareWith.Name = "comboCompareWith";
            this.comboCompareWith.Size = new System.Drawing.Size(162, 21);
            this.comboCompareWith.TabIndex = 16;
            this.comboCompareWith.SelectedIndexChanged += new System.EventHandler(this.comboCompareWith_SelectedIndexChanged);
            this.comboCompareWith.TextUpdate += new System.EventHandler(this.comboCompareWith_TextUpdate);
            // 
            // comboComparator
            // 
            this.comboComparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComparator.FormattingEnabled = true;
            this.comboComparator.Location = new System.Drawing.Point(112, 175);
            this.comboComparator.Name = "comboComparator";
            this.comboComparator.Size = new System.Drawing.Size(91, 21);
            this.comboComparator.TabIndex = 15;
            this.comboComparator.SelectedIndexChanged += new System.EventHandler(this.comboComparator_SelectedIndexChanged);
            // 
            // groupHelp
            // 
            this.groupHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupHelp.Controls.Add(this.textHelp);
            this.groupHelp.Location = new System.Drawing.Point(115, 109);
            this.groupHelp.Margin = new System.Windows.Forms.Padding(10);
            this.groupHelp.Name = "groupHelp";
            this.groupHelp.Size = new System.Drawing.Size(259, 53);
            this.groupHelp.TabIndex = 14;
            this.groupHelp.TabStop = false;
            this.groupHelp.Text = "Help";
            // 
            // textHelp
            // 
            this.textHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textHelp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.layoutBindingSource, "DataDesc", true));
            this.textHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textHelp.Location = new System.Drawing.Point(3, 16);
            this.textHelp.Margin = new System.Windows.Forms.Padding(10);
            this.textHelp.Multiline = true;
            this.textHelp.Name = "textHelp";
            this.textHelp.ReadOnly = true;
            this.textHelp.Size = new System.Drawing.Size(253, 34);
            this.textHelp.TabIndex = 0;
            // 
            // numWidth
            // 
            this.numWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numWidth.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.layoutBindingSource, "Width", true));
            this.numWidth.DecimalPlaces = 2;
            this.numWidth.Location = new System.Drawing.Point(92, 49);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(281, 20);
            this.numWidth.TabIndex = 7;
            // 
            // comboFunction
            // 
            this.comboFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFunction.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.layoutBindingSource, "Data", true));
            this.comboFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFunction.FormattingEnabled = true;
            this.comboFunction.Location = new System.Drawing.Point(92, 75);
            this.comboFunction.Name = "comboFunction";
            this.comboFunction.Size = new System.Drawing.Size(282, 21);
            this.comboFunction.TabIndex = 6;
            this.comboFunction.SelectedIndexChanged += new System.EventHandler(this.comboFunction_SelectedIndexChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.layoutBindingSource, "Title", true));
            this.txtTitle.Location = new System.Drawing.Point(92, 23);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(282, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Function: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Width: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title: ";
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDone.Location = new System.Drawing.Point(478, 437);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(118, 38);
            this.btnDone.TabIndex = 12;
            this.btnDone.Text = "Save";
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 445);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 25);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(99, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Name of layout: ";
            // 
            // txtLayoutName
            // 
            this.txtLayoutName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLayoutName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLayoutName.Location = new System.Drawing.Point(216, 73);
            this.txtLayoutName.Name = "txtLayoutName";
            this.txtLayoutName.Size = new System.Drawing.Size(380, 22);
            this.txtLayoutName.TabIndex = 15;
            this.txtLayoutName.TextChanged += new System.EventHandler(this.txtLayoutName_TextChanged);
            // 
            // LayoutEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 487);
            this.Controls.Add(this.txtLayoutName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listLayoutElements);
            this.Controls.Add(this.m_bannerImage);
            this.MinimumSize = new System.Drawing.Size(600, 435);
            this.Name = "LayoutEditor";
            this.Text = "LayoutEditor";
            this.Load += new System.EventHandler(this.LayoutEditor_Load);
            this.SizeChanged += new System.EventHandler(this.LayoutEditor_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.m_bannerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupHelp.ResumeLayout(false);
            this.groupHelp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_bannerImage;
        private System.Windows.Forms.ListBox listLayoutElements;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboFunction;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupHelp;
        private System.Windows.Forms.TextBox textHelp;
        private System.Windows.Forms.BindingSource layoutBindingSource;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLayoutName;
        private System.Windows.Forms.ComboBox comboComparator;
        private System.Windows.Forms.ComboBox comboCompareWith;
        private System.Windows.Forms.CheckBox checkFilter;
    }
}