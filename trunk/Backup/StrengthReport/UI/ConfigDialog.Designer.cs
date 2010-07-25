namespace StrengthReport.UI {
    partial class ConfigDialog {
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node8");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node7", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node4", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode8});
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.treeGroups = new System.Windows.Forms.TreeView();
            this.m_bannerImage = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabFormat = new System.Windows.Forms.TabControl();
            this.tabPageScreen = new System.Windows.Forms.TabPage();
            this.tabPagePDF = new System.Windows.Forms.TabPage();
            this.tabPageHTML = new System.Windows.Forms.TabPage();
            this.tabPageCSV = new System.Windows.Forms.TabPage();
            this.groupLayout = new System.Windows.Forms.GroupBox();
            this.btnLayoutManager = new System.Windows.Forms.Button();
            this.btnLayoutEditor = new System.Windows.Forms.Button();
            this.comboLayout = new System.Windows.Forms.ComboBox();
            this.layoutBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupContent = new System.Windows.Forms.GroupBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboTemplate = new System.Windows.Forms.ComboBox();
            this.templatesBinginSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_bannerImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabFormat.SuspendLayout();
            this.groupLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBoxBindingSource)).BeginInit();
            this.groupContent.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.templatesBinginSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(561, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Make report ...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(12, 418);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeGroups
            // 
            this.treeGroups.CheckBoxes = true;
            this.treeGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeGroups.FullRowSelect = true;
            this.treeGroups.Location = new System.Drawing.Point(6, 19);
            this.treeGroups.Margin = new System.Windows.Forms.Padding(10);
            this.treeGroups.Name = "treeGroups";
            treeNode1.Checked = true;
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Node2";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Node3";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Node1";
            treeNode5.Name = "Node5";
            treeNode5.Text = "Node5";
            treeNode6.Name = "Node6";
            treeNode6.Text = "Node6";
            treeNode7.Checked = true;
            treeNode7.Name = "Node8";
            treeNode7.Text = "Node8";
            treeNode8.Name = "Node7";
            treeNode8.Text = "Node7";
            treeNode9.Name = "Node4";
            treeNode9.Text = "Node4";
            this.treeGroups.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode9});
            this.treeGroups.Size = new System.Drawing.Size(403, 311);
            this.treeGroups.TabIndex = 2;
            // 
            // m_bannerImage
            // 
            this.m_bannerImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_bannerImage.Location = new System.Drawing.Point(0, 0);
            this.m_bannerImage.Name = "m_bannerImage";
            this.m_bannerImage.Size = new System.Drawing.Size(713, 60);
            this.m_bannerImage.TabIndex = 4;
            this.m_bannerImage.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabFormat);
            this.groupBox1.Location = new System.Drawing.Point(434, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(267, 192);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type of visualisation";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tabFormat
            // 
            this.tabFormat.Controls.Add(this.tabPageScreen);
            this.tabFormat.Controls.Add(this.tabPagePDF);
            this.tabFormat.Controls.Add(this.tabPageHTML);
            this.tabFormat.Controls.Add(this.tabPageCSV);
            this.tabFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormat.Location = new System.Drawing.Point(6, 19);
            this.tabFormat.Name = "tabFormat";
            this.tabFormat.SelectedIndex = 0;
            this.tabFormat.Size = new System.Drawing.Size(255, 167);
            this.tabFormat.TabIndex = 1;
            // 
            // tabPageScreen
            // 
            this.tabPageScreen.Location = new System.Drawing.Point(4, 22);
            this.tabPageScreen.Name = "tabPageScreen";
            this.tabPageScreen.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScreen.Size = new System.Drawing.Size(247, 141);
            this.tabPageScreen.TabIndex = 0;
            this.tabPageScreen.Text = "Screen";
            this.tabPageScreen.UseVisualStyleBackColor = true;
            // 
            // tabPagePDF
            // 
            this.tabPagePDF.Location = new System.Drawing.Point(4, 22);
            this.tabPagePDF.Name = "tabPagePDF";
            this.tabPagePDF.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePDF.Size = new System.Drawing.Size(247, 141);
            this.tabPagePDF.TabIndex = 1;
            this.tabPagePDF.Text = "PDF";
            this.tabPagePDF.UseVisualStyleBackColor = true;
            // 
            // tabPageHTML
            // 
            this.tabPageHTML.Location = new System.Drawing.Point(4, 22);
            this.tabPageHTML.Name = "tabPageHTML";
            this.tabPageHTML.Size = new System.Drawing.Size(247, 141);
            this.tabPageHTML.TabIndex = 2;
            this.tabPageHTML.Text = "HTML";
            this.tabPageHTML.UseVisualStyleBackColor = true;
            // 
            // tabPageCSV
            // 
            this.tabPageCSV.Location = new System.Drawing.Point(4, 22);
            this.tabPageCSV.Name = "tabPageCSV";
            this.tabPageCSV.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCSV.Size = new System.Drawing.Size(247, 141);
            this.tabPageCSV.TabIndex = 3;
            this.tabPageCSV.Text = "CSV";
            this.tabPageCSV.UseVisualStyleBackColor = true;
            // 
            // groupLayout
            // 
            this.groupLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupLayout.Controls.Add(this.btnLayoutManager);
            this.groupLayout.Controls.Add(this.btnLayoutEditor);
            this.groupLayout.Controls.Add(this.comboLayout);
            this.groupLayout.Location = new System.Drawing.Point(434, 257);
            this.groupLayout.Name = "groupLayout";
            this.groupLayout.Padding = new System.Windows.Forms.Padding(6);
            this.groupLayout.Size = new System.Drawing.Size(267, 82);
            this.groupLayout.TabIndex = 6;
            this.groupLayout.TabStop = false;
            this.groupLayout.Text = "Layout";
            // 
            // btnLayoutManager
            // 
            this.btnLayoutManager.Location = new System.Drawing.Point(144, 48);
            this.btnLayoutManager.Name = "btnLayoutManager";
            this.btnLayoutManager.Size = new System.Drawing.Size(113, 23);
            this.btnLayoutManager.TabIndex = 2;
            this.btnLayoutManager.Text = "Manage layouts...";
            this.btnLayoutManager.UseVisualStyleBackColor = true;
            this.btnLayoutManager.Click += new System.EventHandler(this.btnLayoutManager_Click);
            // 
            // btnLayoutEditor
            // 
            this.btnLayoutEditor.Location = new System.Drawing.Point(6, 48);
            this.btnLayoutEditor.Name = "btnLayoutEditor";
            this.btnLayoutEditor.Size = new System.Drawing.Size(113, 23);
            this.btnLayoutEditor.TabIndex = 1;
            this.btnLayoutEditor.Text = "Edit selected";
            this.btnLayoutEditor.UseVisualStyleBackColor = true;
            this.btnLayoutEditor.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboLayout
            // 
            this.comboLayout.DataSource = this.layoutBoxBindingSource;
            this.comboLayout.DisplayMember = "Name";
            this.comboLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLayout.FormattingEnabled = true;
            this.comboLayout.Location = new System.Drawing.Point(6, 21);
            this.comboLayout.Name = "comboLayout";
            this.comboLayout.Size = new System.Drawing.Size(251, 21);
            this.comboLayout.TabIndex = 0;
            // 
            // layoutBoxBindingSource
            // 
            this.layoutBoxBindingSource.DataSource = typeof(StrengthReport.Layouting.LayoutBox);
            // 
            // groupContent
            // 
            this.groupContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupContent.Controls.Add(this.treeGroups);
            this.groupContent.Location = new System.Drawing.Point(12, 67);
            this.groupContent.Margin = new System.Windows.Forms.Padding(6);
            this.groupContent.Name = "groupContent";
            this.groupContent.Padding = new System.Windows.Forms.Padding(6);
            this.groupContent.Size = new System.Drawing.Size(415, 336);
            this.groupContent.TabIndex = 7;
            this.groupContent.TabStop = false;
            this.groupContent.Text = "Content";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboTemplate);
            this.groupBox2.Location = new System.Drawing.Point(436, 345);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(267, 58);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deisgn template";
            // 
            // comboTemplate
            // 
            this.comboTemplate.DataSource = this.templatesBinginSource;
            this.comboTemplate.DisplayMember = "Name";
            this.comboTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTemplate.FormattingEnabled = true;
            this.comboTemplate.Location = new System.Drawing.Point(6, 21);
            this.comboTemplate.Name = "comboTemplate";
            this.comboTemplate.Size = new System.Drawing.Size(251, 21);
            this.comboTemplate.TabIndex = 0;
            // 
            // templatesBinginSource
            // 
            this.templatesBinginSource.DataSource = typeof(StrengthReport.Templating.TemplateBox);
            // 
            // ConfigDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(713, 453);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupContent);
            this.Controls.Add(this.groupLayout);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_bannerImage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(570, 420);
            this.Name = "ConfigDialog";
            this.Text = "Generating report about your passwords";
            this.Load += new System.EventHandler(this.ConfigDialog_Load);
            this.SizeChanged += new System.EventHandler(this.ConfigDialog_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.m_bannerImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabFormat.ResumeLayout(false);
            this.groupLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutBoxBindingSource)).EndInit();
            this.groupContent.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.templatesBinginSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeGroups;
        private System.Windows.Forms.PictureBox m_bannerImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupLayout;
        private System.Windows.Forms.GroupBox groupContent;
        private System.Windows.Forms.Button btnLayoutEditor;
        private System.Windows.Forms.ComboBox comboLayout;
        private System.Windows.Forms.TabControl tabFormat;
        private System.Windows.Forms.TabPage tabPageScreen;
        private System.Windows.Forms.TabPage tabPagePDF;
        private System.Windows.Forms.TabPage tabPageHTML;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabPage tabPageCSV;
        private System.Windows.Forms.BindingSource layoutBoxBindingSource;
        private System.Windows.Forms.Button btnLayoutManager;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboTemplate;
        private System.Windows.Forms.BindingSource templatesBinginSource;


    }
}