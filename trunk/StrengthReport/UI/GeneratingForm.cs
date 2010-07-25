using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KeePass.UI;
using System.Threading;
using StrengthReport.Reporting;


namespace StrengthReport {
    public partial class GeneratingForm : Form {
        private ReportConfig m_Config;
        private Thread m_Thread;

        public GeneratingForm(ReportConfig config) {
            m_Config = config;
            InitializeComponent();
        }

        private void GeneratingForm_Load(object sender, EventArgs e) {
            string strTitle = "StrengthReport: Generating";
            string strDesc = "Generating the report you requested";
            Icon icoNew = new Icon(Resources.StrengthReportPrinting, 48, 48);

            m_bannerImage.Image = BannerFactory.CreateBanner(m_bannerImage.Width,
                m_bannerImage.Height, BannerStyle.Default,
                icoNew.ToBitmap(), strTitle, strDesc);

        }


        private void btnCancel_Click(object sender, EventArgs e) {
            m_Thread.Abort();
            Close();
        }

        private void GeneratingForm_Shown(object sender, EventArgs e) {
            ReportEngine engine = new ReportEngine(m_Config);
            engine.ReportDoneEvent += new EventHandler<EventArgs>(engine_ReportDoneEvent);
            // engine.CreateReport();
            // Close();

            m_Thread = new Thread(new ThreadStart(engine.CreateReport));
            m_Thread.Start();
             

        }

        public void InvokeClose() {
            Close();
        }

        public delegate void InvokeDelegate();

        void engine_ReportDoneEvent(object sender, EventArgs e) {
            this.BeginInvoke( new InvokeDelegate(Close));
        }
    }


}
