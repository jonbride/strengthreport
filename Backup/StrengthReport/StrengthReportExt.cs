using System;
using System.Collections.Generic;

using KeePass.Plugins;
using System.Windows.Forms;
using StrengthReport.UI;


namespace StrengthReport
{
    /// <summary>
    /// Entry point of plugin. This connects to host application.
    /// By tutorial on http://www.keepass.info/help/v2_dev/plg_index.html
    /// </summary>
    public sealed class StrengthReportExt : Plugin
    {
        private IPluginHost m_host = null;
        private ToolStripSeparator m_tsSeparator = null;
        private ToolStripMenuItem m_tsmiMenuItem = null;

        /// <summary>
        /// Initializes variables and register menus.
        /// </summary>
        /// <param name="host">Callback of host application.</param>
        /// <returns>True if no error occured and ready to work.</returns>
        public override bool Initialize(IPluginHost host)
        {
            m_host = host;

            // Get a reference to the 'Tools' menu item container
            ToolStripItemCollection tsMenu = m_host.MainWindow.ToolsMenu.DropDownItems;

            // Add a separator at the bottom
            m_tsSeparator = new ToolStripSeparator();
            tsMenu.Add(m_tsSeparator);

            // Add menu item 'Do Something'
            m_tsmiMenuItem = new ToolStripMenuItem();
            m_tsmiMenuItem.Text = "Create report...";
            m_tsmiMenuItem.Click += CreateReport;
            tsMenu.Add(m_tsmiMenuItem);
            return true;
        }

        /// <summary>
        /// Release resources, unload.
        /// </summary>
        public override void Terminate()
        {
            base.Terminate();
            // Remove all of our menu items
            ToolStripItemCollection tsMenu = m_host.MainWindow.ToolsMenu.DropDownItems;
            tsMenu.Remove(m_tsSeparator);
            tsMenu.Remove(m_tsmiMenuItem);
        }

        /// <summary>
        /// Callback for menu item. Open report creating dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateReport(object sender, EventArgs e)
        {
            // Called when the menu item is clicked
            ConfigDialog dialog = new ConfigDialog(m_host);
            dialog.ShowDialog();
        }

    }
}
