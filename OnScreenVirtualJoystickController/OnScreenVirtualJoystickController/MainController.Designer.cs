namespace OnScreenVirtualJoystickController
{
    partial class MainController
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
            this.components = new System.ComponentModel.Container();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.SourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VoiceControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompactControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComplexControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TouchControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabletControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JoyStickButtonConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VoiceJoyStickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalJoyStickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompactJoyStickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComplexJoyStickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabletJoyStickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomControllerStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SourceToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.SettingToolStripMenuItem,
            this.CustomControllerStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(297, 24);
            this.MainMenu.TabIndex = 10;
            this.MainMenu.Text = "menuStrip1";
            // 
            // SourceToolStripMenuItem
            // 
            this.SourceToolStripMenuItem.Name = "SourceToolStripMenuItem";
            this.SourceToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.SourceToolStripMenuItem.Text = "Source";
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VoiceControllerToolStripMenuItem,
            this.ControllerToolStripMenuItem,
            this.editControllerToolStripMenuItem,
            this.reloadControllerToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.ToolsToolStripMenuItem.Text = "Tools";
            // 
            // VoiceControllerToolStripMenuItem
            // 
            this.VoiceControllerToolStripMenuItem.Name = "VoiceControllerToolStripMenuItem";
            this.VoiceControllerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.VoiceControllerToolStripMenuItem.Text = "Voice Controller";
            this.VoiceControllerToolStripMenuItem.Click += new System.EventHandler(this.voiceControllerToolStripMenuItem_Click);
            // 
            // ControllerToolStripMenuItem
            // 
            this.ControllerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NormalControllerToolStripMenuItem,
            this.CompactControllerToolStripMenuItem,
            this.ComplexControllerToolStripMenuItem,
            this.TouchControllerToolStripMenuItem,
            this.TabletControllerToolStripMenuItem});
            this.ControllerToolStripMenuItem.Name = "ControllerToolStripMenuItem";
            this.ControllerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ControllerToolStripMenuItem.Text = "Controller";
            // 
            // NormalControllerToolStripMenuItem
            // 
            this.NormalControllerToolStripMenuItem.Name = "NormalControllerToolStripMenuItem";
            this.NormalControllerToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.NormalControllerToolStripMenuItem.Text = "Normal";
            this.NormalControllerToolStripMenuItem.Click += new System.EventHandler(this.NormalControllerToolStripMenuItem_Click);
            // 
            // CompactControllerToolStripMenuItem
            // 
            this.CompactControllerToolStripMenuItem.Name = "CompactControllerToolStripMenuItem";
            this.CompactControllerToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.CompactControllerToolStripMenuItem.Text = "Compact";
            this.CompactControllerToolStripMenuItem.Click += new System.EventHandler(this.CompactControllerToolStripMenuItem_Click);
            // 
            // ComplexControllerToolStripMenuItem
            // 
            this.ComplexControllerToolStripMenuItem.Name = "ComplexControllerToolStripMenuItem";
            this.ComplexControllerToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ComplexControllerToolStripMenuItem.Text = "Complex";
            this.ComplexControllerToolStripMenuItem.Click += new System.EventHandler(this.ComplexControllerToolStripMenuItem_Click);
            // 
            // TouchControllerToolStripMenuItem
            // 
            this.TouchControllerToolStripMenuItem.Name = "TouchControllerToolStripMenuItem";
            this.TouchControllerToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.TouchControllerToolStripMenuItem.Text = "Touch";
            this.TouchControllerToolStripMenuItem.Click += new System.EventHandler(this.TouchControllerToolStripMenuItem_Click);
            // 
            // TabletControllerToolStripMenuItem
            // 
            this.TabletControllerToolStripMenuItem.Name = "TabletControllerToolStripMenuItem";
            this.TabletControllerToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.TabletControllerToolStripMenuItem.Text = "Tablet";
            this.TabletControllerToolStripMenuItem.Click += new System.EventHandler(this.TabletControllerToolStripMenuItem_Click);
            // 
            // editControllerToolStripMenuItem
            // 
            this.editControllerToolStripMenuItem.Name = "editControllerToolStripMenuItem";
            this.editControllerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editControllerToolStripMenuItem.Text = "Edit Controller";
            this.editControllerToolStripMenuItem.Click += new System.EventHandler(this.editControllerToolStripMenuItem_Click);
            // 
            // reloadControllerToolStripMenuItem
            // 
            this.reloadControllerToolStripMenuItem.Name = "reloadControllerToolStripMenuItem";
            this.reloadControllerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reloadControllerToolStripMenuItem.Text = "Reload Controller";
            this.reloadControllerToolStripMenuItem.Click += new System.EventHandler(this.reloadControllerToolStripMenuItem_Click);
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.JoyStickButtonConfigurationToolStripMenuItem,
            this.OptionToolStripMenuItem});
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.SettingToolStripMenuItem.Text = "Setting";
            // 
            // JoyStickButtonConfigurationToolStripMenuItem
            // 
            this.JoyStickButtonConfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VoiceJoyStickToolStripMenuItem,
            this.NormalJoyStickToolStripMenuItem,
            this.CompactJoyStickToolStripMenuItem,
            this.ComplexJoyStickToolStripMenuItem,
            this.TabletJoyStickToolStripMenuItem});
            this.JoyStickButtonConfigurationToolStripMenuItem.Name = "JoyStickButtonConfigurationToolStripMenuItem";
            this.JoyStickButtonConfigurationToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.JoyStickButtonConfigurationToolStripMenuItem.Text = "JoyStick Button Configuration";
            // 
            // VoiceJoyStickToolStripMenuItem
            // 
            this.VoiceJoyStickToolStripMenuItem.Name = "VoiceJoyStickToolStripMenuItem";
            this.VoiceJoyStickToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.VoiceJoyStickToolStripMenuItem.Text = "Voice Controller";
            this.VoiceJoyStickToolStripMenuItem.Click += new System.EventHandler(this.VoiceJoyStickToolStripMenuItem_Click);
            // 
            // NormalJoyStickToolStripMenuItem
            // 
            this.NormalJoyStickToolStripMenuItem.Name = "NormalJoyStickToolStripMenuItem";
            this.NormalJoyStickToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.NormalJoyStickToolStripMenuItem.Text = "Normal Controller";
            this.NormalJoyStickToolStripMenuItem.Click += new System.EventHandler(this.NormalJoyStickToolStripMenuItem_Click);
            // 
            // CompactJoyStickToolStripMenuItem
            // 
            this.CompactJoyStickToolStripMenuItem.Name = "CompactJoyStickToolStripMenuItem";
            this.CompactJoyStickToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.CompactJoyStickToolStripMenuItem.Text = "Compact Controller";
            this.CompactJoyStickToolStripMenuItem.Click += new System.EventHandler(this.CompactJoyStickToolStripMenuItem_Click);
            // 
            // ComplexJoyStickToolStripMenuItem
            // 
            this.ComplexJoyStickToolStripMenuItem.Name = "ComplexJoyStickToolStripMenuItem";
            this.ComplexJoyStickToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ComplexJoyStickToolStripMenuItem.Text = "Complex Controller";
            this.ComplexJoyStickToolStripMenuItem.Click += new System.EventHandler(this.ComplexJoyStickToolStripMenuItem_Click);
            // 
            // TabletJoyStickToolStripMenuItem
            // 
            this.TabletJoyStickToolStripMenuItem.Name = "TabletJoyStickToolStripMenuItem";
            this.TabletJoyStickToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.TabletJoyStickToolStripMenuItem.Text = "Touch Controller";
            this.TabletJoyStickToolStripMenuItem.Click += new System.EventHandler(this.TouchJoyStickToolStripMenuItem_Click);
            // 
            // OptionToolStripMenuItem
            // 
            this.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            this.OptionToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.OptionToolStripMenuItem.Text = "Option";
            this.OptionToolStripMenuItem.Click += new System.EventHandler(this.OptionToolStripMenuItem_Click);
            // 
            // CustomControllerStripMenuItem
            // 
            this.CustomControllerStripMenuItem.Name = "CustomControllerStripMenuItem";
            this.CustomControllerStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.CustomControllerStripMenuItem.Text = "Custom Controllers";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Onscreen Controller";
            this.notifyIcon1.BalloonTipTitle = "Onscreen Controller with Voice Command.";
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MainController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(297, 24);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainController";
            this.Text = "OnScreen Joystick with Voice Command";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem SourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VoiceControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NormalControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompactControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComplexControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JoyStickButtonConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VoiceJoyStickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NormalJoyStickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompactJoyStickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComplexJoyStickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TouchControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TabletJoyStickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TabletControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editControllerToolStripMenuItem;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ToolStripMenuItem CustomControllerStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadControllerToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

