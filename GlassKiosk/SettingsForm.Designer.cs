namespace GlassKiosk
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            textBoxURL = new TextBox();
            groupBox2 = new GroupBox();
            checkBoxHideStatusBar = new CheckBox();
            checkBoxHideToolbar = new CheckBox();
            checkBoxAutoStart = new CheckBox();
            checkBoxStartMaximized = new CheckBox();
            checkBoxHideTitleBar = new CheckBox();
            groupBox3 = new GroupBox();
            textBoxPassword = new TextBox();
            buttonCancel = new Button();
            buttonApply = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxURL);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(608, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Browser URL";
            // 
            // textBoxURL
            // 
            textBoxURL.Location = new Point(6, 38);
            textBoxURL.Name = "textBoxURL";
            textBoxURL.Size = new Size(596, 39);
            textBoxURL.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxHideStatusBar);
            groupBox2.Controls.Add(checkBoxHideToolbar);
            groupBox2.Controls.Add(checkBoxAutoStart);
            groupBox2.Controls.Add(checkBoxStartMaximized);
            groupBox2.Controls.Add(checkBoxHideTitleBar);
            groupBox2.Location = new Point(12, 118);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(608, 272);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Basic Settings";
            // 
            // checkBoxHideStatusBar
            // 
            checkBoxHideStatusBar.AutoSize = true;
            checkBoxHideStatusBar.Location = new Point(6, 164);
            checkBoxHideStatusBar.Name = "checkBoxHideStatusBar";
            checkBoxHideStatusBar.Size = new Size(208, 36);
            checkBoxHideStatusBar.TabIndex = 6;
            checkBoxHideStatusBar.Text = "Hide Status Bar";
            checkBoxHideStatusBar.UseVisualStyleBackColor = true;
            // 
            // checkBoxHideToolbar
            // 
            checkBoxHideToolbar.AutoSize = true;
            checkBoxHideToolbar.Location = new Point(6, 80);
            checkBoxHideToolbar.Name = "checkBoxHideToolbar";
            checkBoxHideToolbar.Size = new Size(182, 36);
            checkBoxHideToolbar.TabIndex = 3;
            checkBoxHideToolbar.Text = "Hide Toolbar";
            checkBoxHideToolbar.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoStart
            // 
            checkBoxAutoStart.AutoSize = true;
            checkBoxAutoStart.Location = new Point(6, 206);
            checkBoxAutoStart.Name = "checkBoxAutoStart";
            checkBoxAutoStart.Size = new Size(152, 36);
            checkBoxAutoStart.TabIndex = 5;
            checkBoxAutoStart.Text = "Auto Start";
            checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartMaximized
            // 
            checkBoxStartMaximized.AutoSize = true;
            checkBoxStartMaximized.Location = new Point(6, 38);
            checkBoxStartMaximized.Name = "checkBoxStartMaximized";
            checkBoxStartMaximized.Size = new Size(217, 36);
            checkBoxStartMaximized.TabIndex = 0;
            checkBoxStartMaximized.Text = "Start Maximized";
            checkBoxStartMaximized.UseVisualStyleBackColor = true;
            // 
            // checkBoxHideTitleBar
            // 
            checkBoxHideTitleBar.AutoSize = true;
            checkBoxHideTitleBar.Location = new Point(6, 122);
            checkBoxHideTitleBar.Name = "checkBoxHideTitleBar";
            checkBoxHideTitleBar.Size = new Size(190, 36);
            checkBoxHideTitleBar.TabIndex = 4;
            checkBoxHideTitleBar.Text = "Hide Title Bar";
            checkBoxHideTitleBar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxPassword);
            groupBox3.Location = new Point(18, 396);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(608, 108);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Admin Password";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(6, 38);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(596, 39);
            textBoxPassword.TabIndex = 4;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(464, 639);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(150, 46);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click_1;
            // 
            // buttonApply
            // 
            buttonApply.Location = new Point(308, 639);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(150, 46);
            buttonApply.TabIndex = 4;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 697);
            Controls.Add(buttonApply);
            Controls.Add(buttonCancel);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SettingsForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBoxURL;
        private GroupBox groupBox2;
        private CheckBox checkBoxAutoStart;
        private CheckBox checkBoxHideTitleBar;
        private GroupBox groupBox3;
        private TextBox textBoxPassword;
        private CheckBox checkBoxStartMaximized;
        private CheckBox checkBoxHideToolbar;
        private Button buttonCancel;
        private Button buttonApply;
        private CheckBox checkBoxHideStatusBar;
    }
}