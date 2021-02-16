namespace OnScreenVirtualJoystickController
{
    partial class TouchJoystickCfgForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TouchJoystickCfgForm));
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.JoystickIDCmb = new System.Windows.Forms.ComboBox();
            this.SelectedButtonLbl1 = new System.Windows.Forms.Label();
            this.SelectedButtonLbl2 = new System.Windows.Forms.Label();
            this.TabletControllerPnl = new System.Windows.Forms.Panel();
            this.TabletDangerBtn = new ShapeControl.CustomControl1();
            this.TabletCircleBtn = new System.Windows.Forms.Panel();
            this.TabletTouchBoardPnl = new ShapeControl.CustomControl1();
            this.TabletMovingPart = new ShapeControl.CustomControl1();
            this.TabletBlueBtn = new ShapeControl.CustomControl1();
            this.TabletGreenBtn = new ShapeControl.CustomControl1();
            this.TabletIndigoBtn = new ShapeControl.CustomControl1();
            this.SelectedButtonLbl3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HAxisCmb = new System.Windows.Forms.ComboBox();
            this.VAxisCmb = new System.Windows.Forms.ComboBox();
            this.ActionToggleRdo = new System.Windows.Forms.RadioButton();
            this.ActionClickRdo = new System.Windows.Forms.RadioButton();
            this.ActionReleaseRdo = new System.Windows.Forms.RadioButton();
            this.ActionPressRdo = new System.Windows.Forms.RadioButton();
            this.TabletControllerPnl.SuspendLayout();
            this.TabletCircleBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(299, 189);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 23;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(299, 218);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 24;
            this.OkBtn.Text = "&Ok";
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
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
            this.JoystickIDCmb.Location = new System.Drawing.Point(232, 107);
            this.JoystickIDCmb.Name = "JoystickIDCmb";
            this.JoystickIDCmb.Size = new System.Drawing.Size(121, 21);
            this.JoystickIDCmb.TabIndex = 28;
            // 
            // SelectedButtonLbl1
            // 
            this.SelectedButtonLbl1.AutoSize = true;
            this.SelectedButtonLbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedButtonLbl1.Location = new System.Drawing.Point(228, 44);
            this.SelectedButtonLbl1.Name = "SelectedButtonLbl1";
            this.SelectedButtonLbl1.Size = new System.Drawing.Size(89, 20);
            this.SelectedButtonLbl1.TabIndex = 26;
            this.SelectedButtonLbl1.Text = "Mouse Left";
            // 
            // SelectedButtonLbl2
            // 
            this.SelectedButtonLbl2.AutoSize = true;
            this.SelectedButtonLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedButtonLbl2.Location = new System.Drawing.Point(228, 64);
            this.SelectedButtonLbl2.Name = "SelectedButtonLbl2";
            this.SelectedButtonLbl2.Size = new System.Drawing.Size(142, 20);
            this.SelectedButtonLbl2.TabIndex = 27;
            this.SelectedButtonLbl2.Text = "For Danger Button";
            // 
            // TabletControllerPnl
            // 
            this.TabletControllerPnl.Controls.Add(this.TabletDangerBtn);
            this.TabletControllerPnl.Controls.Add(this.TabletCircleBtn);
            this.TabletControllerPnl.Location = new System.Drawing.Point(9, 45);
            this.TabletControllerPnl.Margin = new System.Windows.Forms.Padding(0);
            this.TabletControllerPnl.Name = "TabletControllerPnl";
            this.TabletControllerPnl.Size = new System.Drawing.Size(200, 200);
            this.TabletControllerPnl.TabIndex = 25;
            // 
            // TabletDangerBtn
            // 
            this.TabletDangerBtn.AnimateBorder = false;
            this.TabletDangerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletDangerBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabletDangerBtn.BackgroundImage")));
            this.TabletDangerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TabletDangerBtn.Blink = false;
            this.TabletDangerBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletDangerBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TabletDangerBtn.BorderWidth = 3;
            this.TabletDangerBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletDangerBtn.Connector = ShapeControl.ConnecterType.Center;
            this.TabletDangerBtn.Direction = ShapeControl.LineDirection.None;
            this.TabletDangerBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TabletDangerBtn.Location = new System.Drawing.Point(2, 2);
            this.TabletDangerBtn.Margin = new System.Windows.Forms.Padding(0);
            this.TabletDangerBtn.Name = "TabletDangerBtn";
            this.TabletDangerBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.TabletDangerBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("TabletDangerBtn.ShapeImage")));
            this.TabletDangerBtn.ShapeImageRotation = 0;
            this.TabletDangerBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("TabletDangerBtn.ShapeImageTexture")));
            this.TabletDangerBtn.ShapeStorageLoadFile = "";
            this.TabletDangerBtn.ShapeStorageSaveFile = "";
            this.TabletDangerBtn.Size = new System.Drawing.Size(98, 98);
            this.TabletDangerBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletDangerBtn.TabIndex = 12;
            this.TabletDangerBtn.Tag2 = "";
            this.TabletDangerBtn.UseGradient = false;
            this.TabletDangerBtn.Vibrate = false;
            this.TabletDangerBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DangerButton_MouseClick);
            // 
            // TabletCircleBtn
            // 
            this.TabletCircleBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TabletCircleBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabletCircleBtn.BackgroundImage")));
            this.TabletCircleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TabletCircleBtn.Controls.Add(this.TabletTouchBoardPnl);
            this.TabletCircleBtn.Controls.Add(this.TabletMovingPart);
            this.TabletCircleBtn.Controls.Add(this.TabletBlueBtn);
            this.TabletCircleBtn.Controls.Add(this.TabletGreenBtn);
            this.TabletCircleBtn.Controls.Add(this.TabletIndigoBtn);
            this.TabletCircleBtn.Location = new System.Drawing.Point(0, 0);
            this.TabletCircleBtn.Margin = new System.Windows.Forms.Padding(0);
            this.TabletCircleBtn.Name = "TabletCircleBtn";
            this.TabletCircleBtn.Size = new System.Drawing.Size(200, 200);
            this.TabletCircleBtn.TabIndex = 2;
            this.TabletCircleBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CircleButton_MouseClick);
            // 
            // TabletTouchBoardPnl
            // 
            this.TabletTouchBoardPnl.AnimateBorder = false;
            this.TabletTouchBoardPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletTouchBoardPnl.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.touch_board;
            this.TabletTouchBoardPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TabletTouchBoardPnl.Blink = false;
            this.TabletTouchBoardPnl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletTouchBoardPnl.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TabletTouchBoardPnl.BorderWidth = 3;
            this.TabletTouchBoardPnl.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletTouchBoardPnl.Connector = ShapeControl.ConnecterType.Center;
            this.TabletTouchBoardPnl.Direction = ShapeControl.LineDirection.None;
            this.TabletTouchBoardPnl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TabletTouchBoardPnl.Location = new System.Drawing.Point(30, 30);
            this.TabletTouchBoardPnl.Name = "TabletTouchBoardPnl";
            this.TabletTouchBoardPnl.Shape = ShapeControl.ShapeType.Ellipse;
            this.TabletTouchBoardPnl.ShapeImage = null;
            this.TabletTouchBoardPnl.ShapeImageRotation = 0;
            this.TabletTouchBoardPnl.ShapeImageTexture = null;
            this.TabletTouchBoardPnl.ShapeStorageLoadFile = "";
            this.TabletTouchBoardPnl.ShapeStorageSaveFile = "";
            this.TabletTouchBoardPnl.Size = new System.Drawing.Size(140, 140);
            this.TabletTouchBoardPnl.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletTouchBoardPnl.TabIndex = 13;
            this.TabletTouchBoardPnl.Tag2 = "";
            this.TabletTouchBoardPnl.UseGradient = false;
            this.TabletTouchBoardPnl.Vibrate = false;
            this.TabletTouchBoardPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.TabletTouchBoardPnl_Paint);
            this.TabletTouchBoardPnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabletTouchBoardPnl_MouseDown);
            this.TabletTouchBoardPnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TabletTouchBoardPnl_MouseMove);
            this.TabletTouchBoardPnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TabletTouchBoardPnl_MouseUp);
            // 
            // TabletMovingPart
            // 
            this.TabletMovingPart.AnimateBorder = false;
            this.TabletMovingPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletMovingPart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabletMovingPart.BackgroundImage")));
            this.TabletMovingPart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TabletMovingPart.Blink = false;
            this.TabletMovingPart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletMovingPart.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TabletMovingPart.BorderWidth = 3;
            this.TabletMovingPart.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletMovingPart.Connector = ShapeControl.ConnecterType.Center;
            this.TabletMovingPart.Direction = ShapeControl.LineDirection.None;
            this.TabletMovingPart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TabletMovingPart.Location = new System.Drawing.Point(91, 8);
            this.TabletMovingPart.Name = "TabletMovingPart";
            this.TabletMovingPart.Shape = ShapeControl.ShapeType.Ellipse;
            this.TabletMovingPart.ShapeImage = null;
            this.TabletMovingPart.ShapeImageRotation = 0;
            this.TabletMovingPart.ShapeImageTexture = null;
            this.TabletMovingPart.ShapeStorageLoadFile = "";
            this.TabletMovingPart.ShapeStorageSaveFile = "";
            this.TabletMovingPart.Size = new System.Drawing.Size(17, 17);
            this.TabletMovingPart.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletMovingPart.TabIndex = 12;
            this.TabletMovingPart.Tag2 = "";
            this.TabletMovingPart.UseGradient = false;
            this.TabletMovingPart.Vibrate = false;
            // 
            // TabletBlueBtn
            // 
            this.TabletBlueBtn.AnimateBorder = false;
            this.TabletBlueBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletBlueBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabletBlueBtn.BackgroundImage")));
            this.TabletBlueBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TabletBlueBtn.Blink = false;
            this.TabletBlueBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletBlueBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TabletBlueBtn.BorderWidth = 0;
            this.TabletBlueBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletBlueBtn.Connector = ShapeControl.ConnecterType.Center;
            this.TabletBlueBtn.Direction = ShapeControl.LineDirection.None;
            this.TabletBlueBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TabletBlueBtn.Location = new System.Drawing.Point(101, 1);
            this.TabletBlueBtn.Margin = new System.Windows.Forms.Padding(0);
            this.TabletBlueBtn.Name = "TabletBlueBtn";
            this.TabletBlueBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.TabletBlueBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("TabletBlueBtn.ShapeImage")));
            this.TabletBlueBtn.ShapeImageRotation = 180;
            this.TabletBlueBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("TabletBlueBtn.ShapeImageTexture")));
            this.TabletBlueBtn.ShapeStorageLoadFile = "";
            this.TabletBlueBtn.ShapeStorageSaveFile = "";
            this.TabletBlueBtn.Size = new System.Drawing.Size(98, 98);
            this.TabletBlueBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletBlueBtn.TabIndex = 12;
            this.TabletBlueBtn.Tag2 = "";
            this.TabletBlueBtn.UseGradient = false;
            this.TabletBlueBtn.Vibrate = false;
            this.TabletBlueBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BlueButton_MouseClick);
            // 
            // TabletGreenBtn
            // 
            this.TabletGreenBtn.AnimateBorder = false;
            this.TabletGreenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletGreenBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabletGreenBtn.BackgroundImage")));
            this.TabletGreenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TabletGreenBtn.Blink = false;
            this.TabletGreenBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletGreenBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TabletGreenBtn.BorderWidth = 3;
            this.TabletGreenBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletGreenBtn.Connector = ShapeControl.ConnecterType.Center;
            this.TabletGreenBtn.Direction = ShapeControl.LineDirection.None;
            this.TabletGreenBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TabletGreenBtn.Location = new System.Drawing.Point(101, 101);
            this.TabletGreenBtn.Margin = new System.Windows.Forms.Padding(0);
            this.TabletGreenBtn.Name = "TabletGreenBtn";
            this.TabletGreenBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.TabletGreenBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("TabletGreenBtn.ShapeImage")));
            this.TabletGreenBtn.ShapeImageRotation = 0;
            this.TabletGreenBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("TabletGreenBtn.ShapeImageTexture")));
            this.TabletGreenBtn.ShapeStorageLoadFile = "";
            this.TabletGreenBtn.ShapeStorageSaveFile = "";
            this.TabletGreenBtn.Size = new System.Drawing.Size(98, 98);
            this.TabletGreenBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletGreenBtn.TabIndex = 12;
            this.TabletGreenBtn.Tag2 = "";
            this.TabletGreenBtn.UseGradient = false;
            this.TabletGreenBtn.Vibrate = false;
            this.TabletGreenBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GreenButton_MouseClick);
            // 
            // TabletIndigoBtn
            // 
            this.TabletIndigoBtn.AnimateBorder = false;
            this.TabletIndigoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletIndigoBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TabletIndigoBtn.BackgroundImage")));
            this.TabletIndigoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TabletIndigoBtn.Blink = false;
            this.TabletIndigoBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletIndigoBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TabletIndigoBtn.BorderWidth = 3;
            this.TabletIndigoBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TabletIndigoBtn.Connector = ShapeControl.ConnecterType.Center;
            this.TabletIndigoBtn.Direction = ShapeControl.LineDirection.None;
            this.TabletIndigoBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TabletIndigoBtn.Location = new System.Drawing.Point(2, 101);
            this.TabletIndigoBtn.Name = "TabletIndigoBtn";
            this.TabletIndigoBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.TabletIndigoBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("TabletIndigoBtn.ShapeImage")));
            this.TabletIndigoBtn.ShapeImageRotation = 0;
            this.TabletIndigoBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("TabletIndigoBtn.ShapeImageTexture")));
            this.TabletIndigoBtn.ShapeStorageLoadFile = "";
            this.TabletIndigoBtn.ShapeStorageSaveFile = "";
            this.TabletIndigoBtn.Size = new System.Drawing.Size(98, 98);
            this.TabletIndigoBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TabletIndigoBtn.TabIndex = 12;
            this.TabletIndigoBtn.Tag2 = "";
            this.TabletIndigoBtn.UseGradient = false;
            this.TabletIndigoBtn.Vibrate = false;
            this.TabletIndigoBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IndigoButton_MouseClick);
            // 
            // SelectedButtonLbl3
            // 
            this.SelectedButtonLbl3.AutoSize = true;
            this.SelectedButtonLbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedButtonLbl3.Location = new System.Drawing.Point(228, 84);
            this.SelectedButtonLbl3.Name = "SelectedButtonLbl3";
            this.SelectedButtonLbl3.Size = new System.Drawing.Size(146, 20);
            this.SelectedButtonLbl3.TabIndex = 27;
            this.SelectedButtonLbl3.Text = "Of Touch Controller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Horizontal Axis :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 32;
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
            this.HAxisCmb.TabIndex = 29;
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
            this.VAxisCmb.Location = new System.Drawing.Point(320, 9);
            this.VAxisCmb.Name = "VAxisCmb";
            this.VAxisCmb.Size = new System.Drawing.Size(50, 21);
            this.VAxisCmb.TabIndex = 30;
            this.VAxisCmb.SelectedIndexChanged += new System.EventHandler(this.VAxisCmb_SelectedIndexChanged);
            // 
            // ActionToggleRdo
            // 
            this.ActionToggleRdo.AutoSize = true;
            this.ActionToggleRdo.Location = new System.Drawing.Point(289, 151);
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
            this.ActionClickRdo.Location = new System.Drawing.Point(232, 151);
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
            this.ActionReleaseRdo.Location = new System.Drawing.Point(289, 134);
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
            this.ActionPressRdo.Location = new System.Drawing.Point(232, 134);
            this.ActionPressRdo.Name = "ActionPressRdo";
            this.ActionPressRdo.Size = new System.Drawing.Size(51, 17);
            this.ActionPressRdo.TabIndex = 43;
            this.ActionPressRdo.TabStop = true;
            this.ActionPressRdo.Text = "Press";
            this.ActionPressRdo.UseVisualStyleBackColor = true;
            this.ActionPressRdo.CheckedChanged += new System.EventHandler(this.ActionRdo_CheckedChanged);
            // 
            // TouchJoystickCfgForm
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(385, 253);
            this.Controls.Add(this.ActionToggleRdo);
            this.Controls.Add(this.ActionClickRdo);
            this.Controls.Add(this.ActionReleaseRdo);
            this.Controls.Add(this.ActionPressRdo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HAxisCmb);
            this.Controls.Add(this.VAxisCmb);
            this.Controls.Add(this.JoystickIDCmb);
            this.Controls.Add(this.SelectedButtonLbl1);
            this.Controls.Add(this.SelectedButtonLbl3);
            this.Controls.Add(this.SelectedButtonLbl2);
            this.Controls.Add(this.TabletControllerPnl);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TouchJoystickCfgForm";
            this.Text = "Config Tablet Joystick";
            this.TabletControllerPnl.ResumeLayout(false);
            this.TabletCircleBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.ComboBox JoystickIDCmb;
        private System.Windows.Forms.Label SelectedButtonLbl1;
        private System.Windows.Forms.Label SelectedButtonLbl2;
        private System.Windows.Forms.Panel TabletControllerPnl;
        private ShapeControl.CustomControl1 TabletDangerBtn;
        private System.Windows.Forms.Panel TabletCircleBtn;
        private ShapeControl.CustomControl1 TabletMovingPart;
        private ShapeControl.CustomControl1 TabletBlueBtn;
        private ShapeControl.CustomControl1 TabletGreenBtn;
        private ShapeControl.CustomControl1 TabletIndigoBtn;
        private ShapeControl.CustomControl1 TabletTouchBoardPnl;
        private System.Windows.Forms.Label SelectedButtonLbl3;
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