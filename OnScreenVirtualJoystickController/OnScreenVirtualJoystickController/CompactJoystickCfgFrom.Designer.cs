namespace OnScreenVirtualJoystickController
{
    partial class CompactJoystickCfgFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompactJoystickCfgFrom));
            this.CompactControllerPnl = new System.Windows.Forms.Panel();
            this.CompactCircleBtn = new System.Windows.Forms.Panel();
            this.CompactBlueBtn = new ShapeControl.CustomControl1();
            this.CompactIndigoBtn = new ShapeControl.CustomControl1();
            this.CompactGreenBtn = new ShapeControl.CustomControl1();
            this.CompactDangerBtn = new ShapeControl.CustomControl1();
            this.CompactMovingPart = new ShapeControl.CustomControl1();
            this.SelectedButtonLbl2 = new System.Windows.Forms.Label();
            this.SelectedButtonLbl1 = new System.Windows.Forms.Label();
            this.JoystickIDCmb = new System.Windows.Forms.ComboBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HAxisCmb = new System.Windows.Forms.ComboBox();
            this.VAxisCmb = new System.Windows.Forms.ComboBox();
            this.ActionToggleRdo = new System.Windows.Forms.RadioButton();
            this.ActionClickRdo = new System.Windows.Forms.RadioButton();
            this.ActionReleaseRdo = new System.Windows.Forms.RadioButton();
            this.ActionPressRdo = new System.Windows.Forms.RadioButton();
            this.CompactControllerPnl.SuspendLayout();
            this.CompactCircleBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompactControllerPnl
            // 
            this.CompactControllerPnl.AutoSize = true;
            this.CompactControllerPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CompactControllerPnl.Controls.Add(this.CompactCircleBtn);
            this.CompactControllerPnl.Location = new System.Drawing.Point(12, 43);
            this.CompactControllerPnl.Name = "CompactControllerPnl";
            this.CompactControllerPnl.Size = new System.Drawing.Size(199, 199);
            this.CompactControllerPnl.TabIndex = 13;
            // 
            // CompactCircleBtn
            // 
            this.CompactCircleBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.curcle_compact;
            this.CompactCircleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CompactCircleBtn.CausesValidation = false;
            this.CompactCircleBtn.Controls.Add(this.CompactBlueBtn);
            this.CompactCircleBtn.Controls.Add(this.CompactIndigoBtn);
            this.CompactCircleBtn.Controls.Add(this.CompactGreenBtn);
            this.CompactCircleBtn.Controls.Add(this.CompactDangerBtn);
            this.CompactCircleBtn.Controls.Add(this.CompactMovingPart);
            this.CompactCircleBtn.Location = new System.Drawing.Point(0, 0);
            this.CompactCircleBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CompactCircleBtn.Name = "CompactCircleBtn";
            this.CompactCircleBtn.Size = new System.Drawing.Size(199, 199);
            this.CompactCircleBtn.TabIndex = 9;
            this.CompactCircleBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CircleButton_MouseClick);
            // 
            // CompactBlueBtn
            // 
            this.CompactBlueBtn.AnimateBorder = false;
            this.CompactBlueBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompactBlueBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CompactBlueBtn.BackgroundImage")));
            this.CompactBlueBtn.Blink = false;
            this.CompactBlueBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CompactBlueBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.CompactBlueBtn.BorderWidth = 3;
            this.CompactBlueBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CompactBlueBtn.Connector = ShapeControl.ConnecterType.Center;
            this.CompactBlueBtn.Direction = ShapeControl.LineDirection.None;
            this.CompactBlueBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.CompactBlueBtn.Location = new System.Drawing.Point(31, 30);
            this.CompactBlueBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CompactBlueBtn.Name = "CompactBlueBtn";
            this.CompactBlueBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.CompactBlueBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("CompactBlueBtn.ShapeImage")));
            this.CompactBlueBtn.ShapeImageRotation = 0;
            this.CompactBlueBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("CompactBlueBtn.ShapeImageTexture")));
            this.CompactBlueBtn.ShapeStorageLoadFile = "";
            this.CompactBlueBtn.ShapeStorageSaveFile = "";
            this.CompactBlueBtn.Size = new System.Drawing.Size(70, 70);
            this.CompactBlueBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompactBlueBtn.TabIndex = 5;
            this.CompactBlueBtn.Tag2 = "";
            this.CompactBlueBtn.UseGradient = false;
            this.CompactBlueBtn.Vibrate = false;
            this.CompactBlueBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BlueButton_MouseClick);
            // 
            // CompactIndigoBtn
            // 
            this.CompactIndigoBtn.AnimateBorder = false;
            this.CompactIndigoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompactIndigoBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CompactIndigoBtn.BackgroundImage")));
            this.CompactIndigoBtn.Blink = false;
            this.CompactIndigoBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CompactIndigoBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.CompactIndigoBtn.BorderWidth = 3;
            this.CompactIndigoBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CompactIndigoBtn.Connector = ShapeControl.ConnecterType.Center;
            this.CompactIndigoBtn.Direction = ShapeControl.LineDirection.None;
            this.CompactIndigoBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.CompactIndigoBtn.Location = new System.Drawing.Point(99, 98);
            this.CompactIndigoBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CompactIndigoBtn.Name = "CompactIndigoBtn";
            this.CompactIndigoBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.CompactIndigoBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("CompactIndigoBtn.ShapeImage")));
            this.CompactIndigoBtn.ShapeImageRotation = 0;
            this.CompactIndigoBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("CompactIndigoBtn.ShapeImageTexture")));
            this.CompactIndigoBtn.ShapeStorageLoadFile = "";
            this.CompactIndigoBtn.ShapeStorageSaveFile = "";
            this.CompactIndigoBtn.Size = new System.Drawing.Size(70, 70);
            this.CompactIndigoBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompactIndigoBtn.TabIndex = 8;
            this.CompactIndigoBtn.Tag2 = "";
            this.CompactIndigoBtn.UseGradient = false;
            this.CompactIndigoBtn.Vibrate = false;
            this.CompactIndigoBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IndigoButton_MouseClick);
            // 
            // CompactGreenBtn
            // 
            this.CompactGreenBtn.AnimateBorder = false;
            this.CompactGreenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompactGreenBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CompactGreenBtn.BackgroundImage")));
            this.CompactGreenBtn.Blink = false;
            this.CompactGreenBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CompactGreenBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.CompactGreenBtn.BorderWidth = 3;
            this.CompactGreenBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CompactGreenBtn.Connector = ShapeControl.ConnecterType.Center;
            this.CompactGreenBtn.Direction = ShapeControl.LineDirection.None;
            this.CompactGreenBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.CompactGreenBtn.Location = new System.Drawing.Point(31, 98);
            this.CompactGreenBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CompactGreenBtn.Name = "CompactGreenBtn";
            this.CompactGreenBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.CompactGreenBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("CompactGreenBtn.ShapeImage")));
            this.CompactGreenBtn.ShapeImageRotation = 0;
            this.CompactGreenBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("CompactGreenBtn.ShapeImageTexture")));
            this.CompactGreenBtn.ShapeStorageLoadFile = "";
            this.CompactGreenBtn.ShapeStorageSaveFile = "";
            this.CompactGreenBtn.Size = new System.Drawing.Size(70, 70);
            this.CompactGreenBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompactGreenBtn.TabIndex = 6;
            this.CompactGreenBtn.Tag2 = "";
            this.CompactGreenBtn.UseGradient = false;
            this.CompactGreenBtn.Vibrate = false;
            this.CompactGreenBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GreenButton_MouseClick);
            // 
            // CompactDangerBtn
            // 
            this.CompactDangerBtn.AnimateBorder = false;
            this.CompactDangerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompactDangerBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CompactDangerBtn.BackgroundImage")));
            this.CompactDangerBtn.Blink = false;
            this.CompactDangerBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CompactDangerBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.CompactDangerBtn.BorderWidth = 3;
            this.CompactDangerBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CompactDangerBtn.Connector = ShapeControl.ConnecterType.Center;
            this.CompactDangerBtn.Direction = ShapeControl.LineDirection.None;
            this.CompactDangerBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.CompactDangerBtn.Location = new System.Drawing.Point(99, 30);
            this.CompactDangerBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CompactDangerBtn.Name = "CompactDangerBtn";
            this.CompactDangerBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.CompactDangerBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("CompactDangerBtn.ShapeImage")));
            this.CompactDangerBtn.ShapeImageRotation = 0;
            this.CompactDangerBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("CompactDangerBtn.ShapeImageTexture")));
            this.CompactDangerBtn.ShapeStorageLoadFile = "";
            this.CompactDangerBtn.ShapeStorageSaveFile = "";
            this.CompactDangerBtn.Size = new System.Drawing.Size(70, 70);
            this.CompactDangerBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompactDangerBtn.TabIndex = 7;
            this.CompactDangerBtn.Tag2 = "";
            this.CompactDangerBtn.UseGradient = false;
            this.CompactDangerBtn.Vibrate = false;
            this.CompactDangerBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DangerButton_MouseClick);
            // 
            // CompactMovingPart
            // 
            this.CompactMovingPart.AnimateBorder = false;
            this.CompactMovingPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompactMovingPart.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.movingpart_compat;
            this.CompactMovingPart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CompactMovingPart.Blink = false;
            this.CompactMovingPart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CompactMovingPart.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.CompactMovingPart.BorderWidth = 3;
            this.CompactMovingPart.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CompactMovingPart.Connector = ShapeControl.ConnecterType.Center;
            this.CompactMovingPart.Direction = ShapeControl.LineDirection.None;
            this.CompactMovingPart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.CompactMovingPart.Location = new System.Drawing.Point(83, 167);
            this.CompactMovingPart.Name = "CompactMovingPart";
            this.CompactMovingPart.Shape = ShapeControl.ShapeType.Ellipse;
            this.CompactMovingPart.ShapeImage = null;
            this.CompactMovingPart.ShapeImageRotation = 0;
            this.CompactMovingPart.ShapeImageTexture = null;
            this.CompactMovingPart.ShapeStorageLoadFile = "";
            this.CompactMovingPart.ShapeStorageSaveFile = "";
            this.CompactMovingPart.Size = new System.Drawing.Size(30, 30);
            this.CompactMovingPart.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CompactMovingPart.TabIndex = 14;
            this.CompactMovingPart.Tag2 = "";
            this.CompactMovingPart.UseGradient = false;
            this.CompactMovingPart.Vibrate = false;
            // 
            // SelectedButtonLbl2
            // 
            this.SelectedButtonLbl2.AutoSize = true;
            this.SelectedButtonLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedButtonLbl2.Location = new System.Drawing.Point(219, 65);
            this.SelectedButtonLbl2.Name = "SelectedButtonLbl2";
            this.SelectedButtonLbl2.Size = new System.Drawing.Size(142, 20);
            this.SelectedButtonLbl2.TabIndex = 7;
            this.SelectedButtonLbl2.Text = "For Danger Button";
            // 
            // SelectedButtonLbl1
            // 
            this.SelectedButtonLbl1.AutoSize = true;
            this.SelectedButtonLbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedButtonLbl1.Location = new System.Drawing.Point(219, 40);
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
            "Button23",
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
            this.JoystickIDCmb.Location = new System.Drawing.Point(223, 92);
            this.JoystickIDCmb.Name = "JoystickIDCmb";
            this.JoystickIDCmb.Size = new System.Drawing.Size(121, 21);
            this.JoystickIDCmb.TabIndex = 8;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(268, 219);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 10;
            this.OkBtn.Text = "&Ok";
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(268, 190);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 9);
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
            this.label1.Location = new System.Drawing.Point(198, 9);
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
            this.HAxisCmb.Location = new System.Drawing.Point(138, 9);
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
            this.VAxisCmb.Location = new System.Drawing.Point(303, 9);
            this.VAxisCmb.Name = "VAxisCmb";
            this.VAxisCmb.Size = new System.Drawing.Size(50, 21);
            this.VAxisCmb.TabIndex = 34;
            this.VAxisCmb.SelectedIndexChanged += new System.EventHandler(this.VAxisCmb_SelectedIndexChanged);
            // 
            // ActionToggleRdo
            // 
            this.ActionToggleRdo.AutoSize = true;
            this.ActionToggleRdo.Location = new System.Drawing.Point(280, 143);
            this.ActionToggleRdo.Name = "ActionToggleRdo";
            this.ActionToggleRdo.Size = new System.Drawing.Size(58, 17);
            this.ActionToggleRdo.TabIndex = 40;
            this.ActionToggleRdo.TabStop = true;
            this.ActionToggleRdo.Text = "Toggle";
            this.ActionToggleRdo.UseVisualStyleBackColor = true;
            this.ActionToggleRdo.CheckedChanged += new System.EventHandler(this.ActionRdo_CheckedChanged);
            // 
            // ActionClickRdo
            // 
            this.ActionClickRdo.AutoSize = true;
            this.ActionClickRdo.Location = new System.Drawing.Point(223, 143);
            this.ActionClickRdo.Name = "ActionClickRdo";
            this.ActionClickRdo.Size = new System.Drawing.Size(48, 17);
            this.ActionClickRdo.TabIndex = 41;
            this.ActionClickRdo.TabStop = true;
            this.ActionClickRdo.Text = "Click";
            this.ActionClickRdo.UseVisualStyleBackColor = true;
            this.ActionClickRdo.CheckedChanged += new System.EventHandler(this.ActionRdo_CheckedChanged);
            // 
            // ActionReleaseRdo
            // 
            this.ActionReleaseRdo.AutoSize = true;
            this.ActionReleaseRdo.Location = new System.Drawing.Point(280, 126);
            this.ActionReleaseRdo.Name = "ActionReleaseRdo";
            this.ActionReleaseRdo.Size = new System.Drawing.Size(64, 17);
            this.ActionReleaseRdo.TabIndex = 42;
            this.ActionReleaseRdo.TabStop = true;
            this.ActionReleaseRdo.Text = "Release";
            this.ActionReleaseRdo.UseVisualStyleBackColor = true;
            this.ActionReleaseRdo.CheckedChanged += new System.EventHandler(this.ActionRdo_CheckedChanged);
            // 
            // ActionPressRdo
            // 
            this.ActionPressRdo.AutoSize = true;
            this.ActionPressRdo.Location = new System.Drawing.Point(223, 126);
            this.ActionPressRdo.Name = "ActionPressRdo";
            this.ActionPressRdo.Size = new System.Drawing.Size(51, 17);
            this.ActionPressRdo.TabIndex = 43;
            this.ActionPressRdo.TabStop = true;
            this.ActionPressRdo.Text = "Press";
            this.ActionPressRdo.UseVisualStyleBackColor = true;
            this.ActionPressRdo.CheckedChanged += new System.EventHandler(this.ActionRdo_CheckedChanged);
            // 
            // CompactJoystickCfgFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(365, 251);
            this.Controls.Add(this.ActionToggleRdo);
            this.Controls.Add(this.ActionClickRdo);
            this.Controls.Add(this.ActionReleaseRdo);
            this.Controls.Add(this.ActionPressRdo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HAxisCmb);
            this.Controls.Add(this.VAxisCmb);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.JoystickIDCmb);
            this.Controls.Add(this.SelectedButtonLbl1);
            this.Controls.Add(this.SelectedButtonLbl2);
            this.Controls.Add(this.CompactControllerPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CompactJoystickCfgFrom";
            this.Text = "Config Compact Joystick";
            this.CompactControllerPnl.ResumeLayout(false);
            this.CompactCircleBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CompactControllerPnl;
        private System.Windows.Forms.Panel CompactCircleBtn;
        private ShapeControl.CustomControl1 CompactIndigoBtn;
        private ShapeControl.CustomControl1 CompactGreenBtn;
        private ShapeControl.CustomControl1 CompactBlueBtn;
        private ShapeControl.CustomControl1 CompactDangerBtn;
        private ShapeControl.CustomControl1 CompactMovingPart;
        private System.Windows.Forms.Label SelectedButtonLbl2;
        private System.Windows.Forms.Label SelectedButtonLbl1;
        private System.Windows.Forms.ComboBox JoystickIDCmb;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox HAxisCmb;
        private System.Windows.Forms.ComboBox VAxisCmb;
        private System.Windows.Forms.RadioButton ActionToggleRdo;
        private System.Windows.Forms.RadioButton ActionClickRdo;
        private System.Windows.Forms.RadioButton ActionReleaseRdo;
        private System.Windows.Forms.RadioButton ActionPressRdo;
    }
}