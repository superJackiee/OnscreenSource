namespace OnScreenVirtualJoystickController
{
    partial class VoiceJoystickCfgForm
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.VoiceConfigGridView = new System.Windows.Forms.DataGridView();
            this.voice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.joystick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.VoiceCmdTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.JoystickIDCmb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceConfigGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(168, 424);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(275, 424);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 6;
            this.OkBtn.Text = "&Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // VoiceConfigGridView
            // 
            this.VoiceConfigGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.VoiceConfigGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.voice,
            this.joystick});
            this.VoiceConfigGridView.Location = new System.Drawing.Point(9, 61);
            this.VoiceConfigGridView.MultiSelect = false;
            this.VoiceConfigGridView.Name = "VoiceConfigGridView";
            this.VoiceConfigGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.VoiceConfigGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VoiceConfigGridView.Size = new System.Drawing.Size(354, 357);
            this.VoiceConfigGridView.TabIndex = 7;
            this.VoiceConfigGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.VoiceConfigGridView_RowsAdded);
            this.VoiceConfigGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.VoiceConfigGridView_RowsRemoved);
            this.VoiceConfigGridView.SelectionChanged += new System.EventHandler(this.VoiceConfigGridView_SelectionChanged);
            // 
            // voice
            // 
            this.voice.HeaderText = "Voice Text";
            this.voice.Name = "voice";
            this.voice.ReadOnly = true;
            this.voice.Width = 200;
            // 
            // joystick
            // 
            this.joystick.HeaderText = "JoyStick Button";
            this.joystick.Name = "joystick";
            this.joystick.ReadOnly = true;
            this.joystick.Width = 110;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Voice Text:";
            // 
            // VoiceCmdTxt
            // 
            this.VoiceCmdTxt.Location = new System.Drawing.Point(16, 29);
            this.VoiceCmdTxt.Name = "VoiceCmdTxt";
            this.VoiceCmdTxt.Size = new System.Drawing.Size(149, 20);
            this.VoiceCmdTxt.TabIndex = 10;
            this.VoiceCmdTxt.TextChanged += new System.EventHandler(this.VoiceCmdTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(201, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Joystick Button:";
            // 
            // JoystickIDCmb
            // 
            this.JoystickIDCmb.FormattingEnabled = true;
            this.JoystickIDCmb.Location = new System.Drawing.Point(194, 28);
            this.JoystickIDCmb.Name = "JoystickIDCmb";
            this.JoystickIDCmb.Size = new System.Drawing.Size(156, 21);
            this.JoystickIDCmb.TabIndex = 12;
            this.JoystickIDCmb.SelectedIndexChanged += new System.EventHandler(this.JoystickIDCmb_SelectedIndexChanged);
            // 
            // VoiceJoystickCfgForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(373, 452);
            this.Controls.Add(this.JoystickIDCmb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VoiceCmdTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VoiceConfigGridView);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VoiceJoystickCfgForm";
            this.Text = "Config Voice Joystick";
            ((System.ComponentModel.ISupportInitialize)(this.VoiceConfigGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.DataGridView VoiceConfigGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn voice;
        private System.Windows.Forms.DataGridViewTextBoxColumn joystick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox VoiceCmdTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox JoystickIDCmb;
    }
}