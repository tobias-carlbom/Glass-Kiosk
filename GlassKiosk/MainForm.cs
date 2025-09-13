using System.Configuration;
using System.Diagnostics;
using System.Text;
using Microsoft.Win32;

namespace GlassKiosk
{
    public partial class MainForm : Form
    {

        private string currentUrl = "http://localhost:1881";
        private string adminPassword = "";
        private const string REGISTRY_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private const string APP_NAME = "GlassKiosk";


        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            LoadConfiguration();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitBrowser();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditApplicationSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            EditApplicationSettings();
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(adminPassword))
            {
                if (!ValidateAdminAccess())
                {
                    e.Cancel = true;
                    MessageBox.Show("Access denied. Incorrect password.", "Authentication Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }





        /*
         * Helper Methods
         */
        private void LoadConfiguration()
        {
            currentUrl = ConfigurationManager.AppSettings["url"] ?? "http://localhost:1881";
            //webView21.CoreWebView2.Navigate(currentUrl);

            string encryptedPassword = ConfigurationManager.AppSettings["adminPassword"] ?? "";
            adminPassword = string.IsNullOrEmpty(encryptedPassword) ? "" : DecryptString(encryptedPassword);

            bool maximized = bool.Parse(ConfigurationManager.AppSettings["maximized"] ?? "false");
            if (maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

            bool toolbar = bool.Parse(ConfigurationManager.AppSettings["toolbar"] ?? "true");
            if (toolbar)
            {
                menuStrip1.Visible = true;
            }
            else
            {
                menuStrip1.Visible = false;
            }

            bool titleBar = bool.Parse(ConfigurationManager.AppSettings["titleBar"] ?? "true");
            if (titleBar)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }

            bool statusBar = bool.Parse(ConfigurationManager.AppSettings["statusBar"] ?? "true");
            if (statusBar)
            {
                statusStrip1.Visible = true;
            }
            else
            {
                statusStrip1.Visible = false;
            }

            bool autostart = bool.Parse(ConfigurationManager.AppSettings["autostart"] ?? "false");
        }

        private void SaveConfiguration(string url, bool maximized, bool toolbar, bool titleBar, bool statusBar, bool autostart, string adminPassword)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.AppSettings.Settings["url"] == null)
                    config.AppSettings.Settings.Add("url", url);
                else
                    config.AppSettings.Settings["url"].Value = url;

                if (config.AppSettings.Settings["maximized"] == null)
                    config.AppSettings.Settings.Add("maximized", maximized.ToString());
                else
                    config.AppSettings.Settings["maximized"].Value = maximized.ToString();

                if (config.AppSettings.Settings["toolbar"] == null)
                    config.AppSettings.Settings.Add("toolbar", toolbar.ToString());
                else
                    config.AppSettings.Settings["toolbar"].Value = toolbar.ToString();

                if (config.AppSettings.Settings["titleBar"] == null)
                    config.AppSettings.Settings.Add("titleBar", titleBar.ToString());
                else
                    config.AppSettings.Settings["titleBar"].Value = titleBar.ToString();

                if (config.AppSettings.Settings["statusBar"] == null)
                    config.AppSettings.Settings.Add("statusBar", statusBar.ToString());
                else
                    config.AppSettings.Settings["statusBar"].Value = statusBar.ToString();

                if (config.AppSettings.Settings["autostart"] == null)
                    config.AppSettings.Settings.Add("autostart", autostart.ToString());
                else
                    config.AppSettings.Settings["autostart"].Value = autostart.ToString();

                string encryptedPassword = string.IsNullOrEmpty(adminPassword) ? "" : EncryptString(adminPassword);
                if (config.AppSettings.Settings["adminPassword"] == null)
                    config.AppSettings.Settings.Add("adminPassword", encryptedPassword);
                else
                    config.AppSettings.Settings["adminPassword"].Value = encryptedPassword;

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save configuration: {ex.Message}", "Configuration Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task Initialized()
        {
            await webView21.EnsureCoreWebView2Async(null);
        }

        public async void InitBrowser()
        {
            await Initialized();
            webView21.CoreWebView2.Navigate(currentUrl);
        }

        private bool ValidateAdminAccess()
        {
            if (string.IsNullOrWhiteSpace(adminPassword))
                return true;

            using (var passwordForm = new PasswordForm())
            {
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    return passwordForm.Password == adminPassword;
                }
            }
            return false;
        }

        public void EditApplicationSettings()
        {
            if (!ValidateAdminAccess())
            {
                MessageBox.Show("Access denied. Incorrect password.", "Authentication Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SettingsForm configForm = new SettingsForm())
            {
                configForm.websiteUrl = currentUrl;
                configForm.maximized = bool.Parse(ConfigurationManager.AppSettings["maximized"] ?? "false");
                configForm.toolbar = bool.Parse(ConfigurationManager.AppSettings["toolbar"] ?? "false");
                configForm.titleBar = bool.Parse(ConfigurationManager.AppSettings["titleBar"] ?? "false");
                configForm.statusBar = bool.Parse(ConfigurationManager.AppSettings["statusBar"] ?? "false");
                configForm.autostart = bool.Parse(ConfigurationManager.AppSettings["Autostart"] ?? "false");
                configForm.adminPassword = adminPassword;

                if (configForm.ShowDialog() == DialogResult.OK)
                {
                    string newUrl = configForm.websiteUrl;
                    bool maximized = configForm.maximized;
                    bool toolbar = configForm.toolbar;
                    bool titleBar = configForm.titleBar;
                    bool statusBar = configForm.statusBar;
                    bool autostart = configForm.autostart;
                    string newAdminPassword = configForm.adminPassword;

                    adminPassword = newAdminPassword;
                    SaveConfiguration(newUrl, maximized, toolbar, titleBar, statusBar, autostart, newAdminPassword);
                    SetAutostart(autostart);
                    //LoadConfiguration();
                    DialogResult result = MessageBox.Show(
    "Settings have been saved. The application needs to restart to apply all changes.\n\nWould you like to restart now?",
    "Restart Required",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        RestartApplication();
                    }
                }
            }
        }

        private void RestartApplication()
        {
            try
            {
                // Start a new instance of the application
                string executablePath = Application.ExecutablePath;
                Process.Start(new ProcessStartInfo
                {
                    FileName = executablePath,
                    UseShellExecute = true
                });

                // Exit the current application
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not restart application: {ex.Message}\n\nPlease restart manually.",
                    "Restart Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
        }

        private void SetAutostart(bool enable)
        {
            try
            {
                using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY, true))
                {
                    if (enable)
                    {
                        string executablePath = Application.ExecutablePath;
                        key?.SetValue(APP_NAME, executablePath);
                    }
                    else
                    {
                        key?.DeleteValue(APP_NAME, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not update autostart setting: {ex.Message}", "Autostart Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string EncryptString(string text)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(text);
                byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(data, null, System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return Convert.ToBase64String(encryptedData);
            }
            catch
            {
                return text;
            }
        }

        private string DecryptString(string encryptedText)
        {
            try
            {
                byte[] encryptedData = Convert.FromBase64String(encryptedText);
                byte[] data = System.Security.Cryptography.ProtectedData.Unprotect(encryptedData, null, System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(data);
            }
            catch
            {
                return encryptedText;
            }
        }
    }
}
