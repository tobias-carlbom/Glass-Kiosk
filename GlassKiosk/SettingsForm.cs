using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GlassKiosk
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public string WebsiteUrl
        {
            get { return textBoxURL.Text; }
            set { textBoxURL.Text = value; }
        }

        public bool StartMaximized
        {
            get { return checkBoxStartMaximized.Checked; }
            set { checkBoxStartMaximized.Checked = value; }
        }

        public bool HideToolbar
        {
            get { return checkBoxHideToolbar.Checked; }
            set { checkBoxHideToolbar.Checked = value; }
        }

        public bool HideTitleBar
        {
            get { return checkBoxHideTitleBar.Checked; }
            set { checkBoxHideTitleBar.Checked = value; }
        }

        public bool HideStatusBar
        {
            get { return checkBoxHideStatusBar.Checked; }
            set { checkBoxHideStatusBar.Checked = value; }
        }

        public bool Autostart
        {
            get { return checkBoxAutoStart.Checked; }
            set { checkBoxAutoStart.Checked = value; }
        }

        public string AdminPassword
        {
            get { return textBoxPassword.Text; }
            set { textBoxPassword.Text = value; }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxURL.Text))
            {
                MessageBox.Show("Please enter a valid URL.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
