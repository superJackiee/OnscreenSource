namespace OnScreenVirtualJoystickController
{
    partial class NormalJoystickCfgForm
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
            this.NormalControllerPnl = new System.Windows.Forms.Panel();
            this.NormalCircleBtn = new System.Windows.Forms.Panel();
            this.NormalMovingPart = new System.Windows.Forms.PictureBox();
            this.NormalBlueBtn = new System.Windows.Forms.Panel();
            this.NormalGreenBtn = new System.Windows.Forms.Panel();
            this.NormalIndigoBtn = new System.Windows.Forms.Panel();
            this.SelectedButtonLbl1 = new System.Windows.Forms.Label();
            this.JoystickIDCmb = new System.Windows.Forms.ComboBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.NormalDangerBtn = new System.Windows.Forms.Panel();
            this.SelectedButtonLbl2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HAxisCmb = new System.Windows.Forms.ComboBox();
            this.VAxisCmb = new System.Windows.Forms.ComboBox();
            this.ActionPressRdo = new System.Windows.Forms.RadioButton();
            this.ActionReleaseRdo = new System.Windows.Forms.RadioButton();
            this.ActionClickRdo = new System.Windows.Forms.RadioButton();
            this.ActionToggleRdo = new System.Windows.Forms.RadioButton();
            this.NormalControllerPnl.SuspendLayout();
            this.NormalCircleBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NormalMovingPart)).BeginInit();
            this.SuspendLayout();
            // 
            // NormalControllerPnl
            // 
            this.NormalControllerPnl.AutoSize = true;
            this.NormalControllerPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NormalControllerPnl.Controls.Add(this.NormalCircleBtn);
            this.NormalControllerPnl.Controls.Add(this.NormalBlueBtn);
            this.NormalControllerPnl.Controls.Add(this.NormalGreenBtn);
            this.NormalControllerPnl.Controls.Add(this.NormalIndigoBtn);
            this.NormalControllerPnl.Location = new System.Drawing.Point(9, 36);
            this.NormalControllerPnl.Margin = new System.Windows.Forms.Padding(0);
            this.NormalControllerPnl.Name = "NormalControllerPnl";
            this.NormalControllerPnl.Size = new System.Drawing.Size(249, 199);
            this.NormalControllerPnl.TabIndex = 6;
            // 
            // NormalCircleBtn
            // 
            this.NormalCircleBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.curcle_normal;
            this.NormalCircleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalCircleBtn.Controls.Add(this.NormalMovingPart);
            this.NormalCircleBtn.Location = new System.Drawing.Point(0, 0);
            this.NormalCircleBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NormalCircleBtn.Name = "NormalCircleBtn";
            this.NormalCircleBtn.Size = new System.Drawing.Size(199, 199);
            this.NormalCircleBtn.TabIndex = 9;
            this.NormalCircleBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CircleButton_MouseClick);
            // 
            // NormalMovingPart
            // 
            this.NormalMovingPart.BackColor = System.Drawing.Color.Transparent;
            this.NormalMovingPart.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.movingpart_mornal;
            this.NormalMovingPart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalMovingPart.Enabled = false;
            this.NormalMovingPart.Location = new System.Drawing.Point(87, 84);
            this.NormalMovingPart.Margin = new System.Windows.Forms.Padding(0);
            this.NormalMovingPart.Name = "NormalMovingPart";
            this.NormalMovingPart.Size = new System.Drawing.Size(30, 30);
            this.NormalMovingPart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NormalMovingPart.TabIndex = 0;
            this.NormalMovingPart.TabStop = false;
            // 
            // NormalBlueBtn
            // 
            this.NormalBlueBtn.BackColor = System.Drawing.Color.Transparent;
            this.NormalBlueBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.bluebutton_normal;
            this.NormalBlueBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalBlueBtn.Location = new System.Drawing.Point(204, 154);
            this.NormalBlueBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NormalBlueBtn.Name = "NormalBlueBtn";
            this.NormalBlueBtn.Size = new System.Drawing.Size(45, 45);
            this.NormalBlueBtn.TabIndex = 5;
            this.NormalBlueBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BlueButton_MouseClick);
            // 
            // NormalGreenBtn
            // 
            this.NormalGreenBtn.BackColor = System.Drawing.Color.Transparent;
            this.NormalGreenBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.greenbutton_normal;
            this.NormalGreenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalGreenBtn.Location = new System.Drawing.Point(204, 103);
            this.NormalGreenBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NormalGreenBtn.Name = "NormalGreenBtn";
            this.NormalGreenBtn.Size = new System.Drawing.Size(45, 45);
            this.NormalGreenBtn.TabIndex = 6;
            this.NormalGreenBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GreenButton_MouseClick);
            // 
            // NormalIndigoBtn
            // 
            this.NormalIndigoBtn.BackColor = System.Drawing.Color.Transparent;
            this.NormalIndigoBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.indigobutton_normal;
            this.NormalIndigoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalIndigoBtn.Location = new System.Drawing.Point(204, 52);
            this.NormalIndigoBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NormalIndigoBtn.Name = "NormalIndigoBtn";
            this.NormalIndigoBtn.Size = new System.Drawing.Size(45, 45);
            this.NormalIndigoBtn.TabIndex = 8;
            this.NormalIndigoBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IndigoButton_MouseClick);
            // 
            // SelectedButtonLbl1
            // 
            this.SelectedButtonLbl1.AutoSize = true;
            this.SelectedButtonLbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedButtonLbl1.Location = new System.Drawing.Point(264, 36);
            this.SelectedButtonLbl1.Name = "SelectedButtonLbl1";
            this.SelectedButtonLbl1.Size = new System.Drawing.Size(89, 20);
            this.SelectedButtonLbl1.TabIndex = 7;
            this.SelectedButtonLbl1.Text = "Mouse Left";
            // 
            // JoystickIDCmb
            // 
            this.JoystickIDCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JoystickIDCmb.FormattingEnabled = true;
            this.JoystickIDCmb.Items.AddRange(new object[] {
            "None",
            "Button1",
            "Button2",
            "Button3",
            "Button4",
            "Button5",
            "Button6",
            "Button7",
            "Button8",
            "Button9",
            "Button10",
            "Button11",
            "Button12",
            "Button13",
            "Button14",
            "Button15",
            "Button16",
            "Button17",
            "Button18",
            "Button19",
            "Button20",
            "Button21",
            "Button22",
            "Button23"});
            this.JoystickIDCmb.Location = new System.Drawing.Point(268, 88);
            this.JoystickIDCmb.Name = "JoystickIDCmb";
            this.JoystickIDCmb.Size = new System.Drawing.Size(121, 21);
            this.JoystickIDCmb.TabIndex = 8;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(313, 186);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(313, 215);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 10;
            this.OkBtn.Text = "&Ok";
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // NormalDangerBtn
            // 
            this.NormalDangerBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.dangerbutton_normal;
            this.NormalDangerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalDangerBtn.Location = new System.Drawing.Point(213, 36);
            this.NormalDangerBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NormalDangerBtn.Name = "NormalDangerBtn";
            this.NormalDangerBtn.Size = new System.Drawing.Size(45, 45);
            this.NormalDangerBtn.TabIndex = 7;
            this.NormalDangerBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DangerButton_MouseClick);
            // 
            // SelectedButtonLbl2
            // 
            this.SelectedButtonLbl2.AutoSize = true;
            this.SelectedButtonLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedButtonLbl2.Location = new System.Drawing.Point(264, 61);
            this.SelectedButtonLbl2.Name = "SelectedButtonLbl2";
            this.SelectedButtonLbl2.Size = new System.Drawing.Size(142, 20);
            this.SelectedButtonLbl2.TabIndex = 7;
            this.SelectedButtonLbl2.Text = "For Danger Button";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Horizontal Axis :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Vertical Axis :";
            // 
            // HAxisCmb
            // 
            this.HAxisCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HAxisCmb.FormattingEnabled = true;
            this.HAxisCmb.Items.AddRange(new object[] {
            "None",
            "X",
            "Y",
            "Z",
            "RX",
            "RY",
            "SL0",
            "SL1"});
            this.HAxisCmb.Location = new System.Drawing.Point(140, 9);
            this.HAxisCmb.Name = "HAxisCmb";
            this.HAxisCmb.Size = new System.Drawing.Size(50, 21);
            this.HAxisCmb.TabIndex = 33;
            this.HAxisCmb.SelectedIndexChanged += new System.EventHandler(this.HAxisCmb_SelectedIndexChanged);
            // 
            // VAxisCmb
            // 
            this.VAxisCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VAxisCmb.FormattingEnabled = true;
            this.VAxisCmb.Items.AddRange(new object[] {
            "None",
            "X",
            "Y",
            "Z",
            "RX",
            "RY",
            "SL0",
            "SL1"});
            this.VAxisCmb.Location = new System.Drawing.Point(313, 9);
            this.VAxisCmb.Name = "VAxisCmb";
            this.VAxisCmb.Size = new System.Drawing.Size(50, 21);
            this.VAxisCmb.TabIndex = 34;
            this.VAxisCmb.SelectedIndexChanged += new System.EventHandler(this.VAxisCmb_SelectedIndexChanged);
            // 
            // ActionPressRdo
            // 
            this.ActionPressRdo.AutoSize = true;
            this.ActionPressRdo.Location = new System.Drawing.Point(268, 116);
            this.ActionPressRdo.Name = "ActionPressRdo";
            this.ActionPressRdo.Size = new System.Drawing.Size(51, 17);
            this.ActionPressRdo.TabIndex = 39;
            this.ActionPressRdo.TabStop = true;
            this.ActionPressRdo.Text = "Press";
            this.ActionPressRdo.UseVisualStyleBackColor = true;
            this.ActionPressRdo.CheckedChanged += new System.EventHandler(this.ActionRdo_CheckedChanged);
            // 
            // ActionReleaseRdo
            // 
            this.ActionReleaseRdo.AutoSize = true;
            this.ActionReleaseRdo.Location = new System.Drawing.Point(325, 116);
            this.ActionReleaseRdo.Name = "ActionReleaseRdo";
            this.ActionReleaseRdo.Size = new System.Drawing.Size(64, 17);
            this.ActionReleaseRdo.TabIndex = 39;
            this.ActionReleaseRdo.TabStop = true;
            this.ActionReleaseRdo.Text = "Release";
            this.ActionReleaseRdo.UseVisualStyleBackColor = true;
            this.ActionReleaseRdo.CheckedChanged += new System.EventHandler(this.ActionRdo_CheckedChanged);
            // 
            // ActionClickRdo
            // 
            this.ActionClickRdo.AutoSize = true;
            this.ActionClickRdo.Location = new System.Drawing.Point(268, 133);
            this.ActionClickRdo.Name = "ActionClickRdo";
            this.ActionClickRdo.Size = new System.Drawing.Size(48, 17);
            this.ActionClickRdo.TabIndex = 39;
            this.ActionClickRdo.TabStop = true;
            this.ActionClickRdo.Text = "Click";
            this.ActionClickRdo.UseVisualStyleBackColor = true;
            this.ActionClickRdo.CheckedChanged += new System.EventHandler(this.ActionRdo_CheckedChanged);
            // 
            // ActionToggleRdo
            // 
            this.ActionToggleRdo.AutoSize = true;
            this.ActionToggleRdo.Location = new System.Drawing.Point(325, 133);
            this.ActionToggleRdo.Name = "ActionToggleRdo";
            this.ActionToggleRdo.Size = new System.Drawing.Size(58, 17);
            this.ActionToggleRdo.TabIndex = 39;
            this.ActionToggleRdo.TabStop = true;
            this.ActionToggleRdo.Text = "Toggle";
            this.ActionToggleRdo.UseVisualStyleBackColor = true;
            this.ActionToggleRdo.CheckedChanged += new System.EventHandler(this.ActionRdo_CheckedChanged);
            // 
            // NormalJoystickCfgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(405, 245);
            this.Controls.Add(this.ActionToggleRdo);
            this.Controls.Add(this.ActionClickRdo);
            this.Controls.Add(this.ActionReleaseRdo);
            this.Controls.Add(this.ActionPressRdo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HAxisCmb);
            this.Controls.Add(this.VAxisCmb);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.NormalDangerBtn);
            this.Controls.Add(this.JoystickIDCmb);
            this.Controls.Add(this.SelectedButtonLbl2);
            this.Controls.Add(this.SelectedButtonLbl1);
            this.Controls.Add(this.NormalControllerPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NormalJoystickCfgForm";
            this.Text = "Config Normal Joystick";
            this.NormalControllerPnl.ResumeLayout(false);
            this.NormalCircleBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NormalMovingPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel NormalControllerPnl;
        private System.Windows.Forms.Panel NormalCircleBtn;
        private System.Windows.Forms.PictureBox NormalMovingPart;
        private System.Windows.Forms.Panel NormalBlueBtn;
        private System.Windows.Forms.Panel NormalGreenBtn;
        private System.Windows.Forms.Panel NormalIndigoBtn;
        private System.Windows.Forms.Panel NormalDangerBtn;
        private System.Windows.Forms.Label SelectedButtonLbl1;
        private System.Windows.Forms.Label SelectedButtonLbl2;
        private System.Windows.Forms.ComboBox JoystickIDCmb;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox HAxisCmb;
        private System.Windows.Forms.ComboBox VAxisCmb;
        private System.Windows.Forms.RadioButton ActionPressRdo;
        private System.Windows.Forms.RadioButton ActionReleaseRdo;
        private System.Windows.Forms.RadioButton ActionClickRdo;
        private System.Windows.Forms.RadioButton ActionToggleRdo;
    }
}