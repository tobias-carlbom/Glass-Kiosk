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

        public string websiteUrl
        {
            get { return textBoxURL.Text; }
            set { textBoxURL.Text = value; }
        }

        public bool maximized
        {
            get { return checkBoxMaximized.Checked; }
            set { checkBoxMaximized.Checked = value; }
        }

        public bool toolbar
        {
            get { return checkBoxToolbar.Checked; }
            set { checkBoxToolbar.Checked = value; }
        }

        public bool titleBar
        {
            get { return checkBoxTitleBar.Checked; }
            set { checkBoxTitleBar.Checked = value; }
        }

        public bool statusBar
        {
            get { return checkBoxStatusBar.Checked; }
            set { checkBoxStatusBar.Checked = value; }
        }

        public bool autostart
        {
            get { return checkBoxAutoStart.Checked; }
            set { checkBoxAutoStart.Checked = value; }
        }

        public string adminPassword
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
