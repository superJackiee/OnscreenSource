namespace OnScreenVirtualJoystickController
{
    partial class TouchControllerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TouchControllerForm));
            this.MouseButtonlbl = new System.Windows.Forms.Label();
            this.TouchControllerPnl = new System.Windows.Forms.Panel();
            this.TouchBlueBtn = new ShapeControl.CustomControl1();
            this.TouchDangerBtn = new ShapeControl.CustomControl1();
            this.TouchGreenBtn = new ShapeControl.CustomControl1();
            this.TouchIndigoBtn = new ShapeControl.CustomControl1();
            this.TouchCircleBtn = new System.Windows.Forms.Panel();
            this.TouchTouchBoardPnl = new ShapeControl.CustomControl1();
            this.TouchMovingPart = new ShapeControl.CustomControl1();
            this.MousePositionTimer = new System.Windows.Forms.Timer(this.components);
            this.TouchControllerBorderPnl = new ShapeControl.CustomControl1();
            this.TouchControllerPnl.SuspendLayout();
            this.TouchCircleBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // MouseButtonlbl
            // 
            this.MouseButtonlbl.AutoSize = true;
            this.MouseButtonlbl.BackColor = System.Drawing.Color.Red;
            this.MouseButtonlbl.Enabled = false;
            this.MouseButtonlbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MouseButtonlbl.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MouseButtonlbl.ForeColor = System.Drawing.Color.Lime;
            this.MouseButtonlbl.Location = new System.Drawing.Point(0, 0);
            this.MouseButtonlbl.Margin = new System.Windows.Forms.Padding(0);
            this.MouseButtonlbl.Name = "MouseButtonlbl";
            this.MouseButtonlbl.Size = new System.Drawing.Size(0, 29);
            this.MouseButtonlbl.TabIndex = 16;
            // 
            // TouchControllerPnl
            // 
            this.TouchControllerPnl.Controls.Add(this.TouchBlueBtn);
            this.TouchControllerPnl.Controls.Add(this.TouchDangerBtn);
            this.TouchControllerPnl.Controls.Add(this.TouchGreenBtn);
            this.TouchControllerPnl.Controls.Add(this.TouchIndigoBtn);
            this.TouchControllerPnl.Controls.Add(this.TouchCircleBtn);
            this.TouchControllerPnl.Location = new System.Drawing.Point(10, 10);
            this.TouchControllerPnl.Margin = new System.Windows.Forms.Padding(0);
            this.TouchControllerPnl.Name = "TouchControllerPnl";
            this.TouchControllerPnl.Size = new System.Drawing.Size(360, 360);
            this.TouchControllerPnl.TabIndex = 17;
            // 
            // TouchBlueBtn
            // 
            this.TouchBlueBtn.AnimateBorder = false;
            this.TouchBlueBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchBlueBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TouchBlueBtn.BackgroundImage")));
            this.TouchBlueBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TouchBlueBtn.Blink = false;
            this.TouchBlueBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchBlueBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TouchBlueBtn.BorderWidth = 0;
            this.TouchBlueBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchBlueBtn.Connector = ShapeControl.ConnecterType.Center;
            this.TouchBlueBtn.Direction = ShapeControl.LineDirection.None;
            this.TouchBlueBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TouchBlueBtn.Location = new System.Drawing.Point(183, 2);
            this.TouchBlueBtn.Margin = new System.Windows.Forms.Padding(0);
            this.TouchBlueBtn.Name = "TouchBlueBtn";
            this.TouchBlueBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.TouchBlueBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("TouchBlueBtn.ShapeImage")));
            this.TouchBlueBtn.ShapeImageRotation = 180;
            this.TouchBlueBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("TouchBlueBtn.ShapeImageTexture")));
            this.TouchBlueBtn.ShapeStorageLoadFile = "";
            this.TouchBlueBtn.ShapeStorageSaveFile = "";
            this.TouchBlueBtn.Size = new System.Drawing.Size(177, 177);
            this.TouchBlueBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchBlueBtn.TabIndex = 12;
            this.TouchBlueBtn.Tag2 = "";
            this.TouchBlueBtn.UseGradient = false;
            this.TouchBlueBtn.Vibrate = false;
            // 
            // TouchDangerBtn
            // 
            this.TouchDangerBtn.AnimateBorder = false;
            this.TouchDangerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchDangerBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TouchDangerBtn.BackgroundImage")));
            this.TouchDangerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TouchDangerBtn.Blink = false;
            this.TouchDangerBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchDangerBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TouchDangerBtn.BorderWidth = 3;
            this.TouchDangerBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchDangerBtn.Connector = ShapeControl.ConnecterType.Center;
            this.TouchDangerBtn.Direction = ShapeControl.LineDirection.None;
            this.TouchDangerBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TouchDangerBtn.Location = new System.Drawing.Point(2, 2);
            this.TouchDangerBtn.Margin = new System.Windows.Forms.Padding(0);
            this.TouchDangerBtn.Name = "TouchDangerBtn";
            this.TouchDangerBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.TouchDangerBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("TouchDangerBtn.ShapeImage")));
            this.TouchDangerBtn.ShapeImageRotation = 0;
            this.TouchDangerBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("TouchDangerBtn.ShapeImageTexture")));
            this.TouchDangerBtn.ShapeStorageLoadFile = "";
            this.TouchDangerBtn.ShapeStorageSaveFile = "";
            this.TouchDangerBtn.Size = new System.Drawing.Size(177, 177);
            this.TouchDangerBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchDangerBtn.TabIndex = 12;
            this.TouchDangerBtn.Tag2 = "";
            this.TouchDangerBtn.UseGradient = false;
            this.TouchDangerBtn.Vibrate = false;
            // 
            // TouchGreenBtn
            // 
            this.TouchGreenBtn.AnimateBorder = false;
            this.TouchGreenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchGreenBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TouchGreenBtn.BackgroundImage")));
            this.TouchGreenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TouchGreenBtn.Blink = false;
            this.TouchGreenBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchGreenBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TouchGreenBtn.BorderWidth = 3;
            this.TouchGreenBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchGreenBtn.Connector = ShapeControl.ConnecterType.Center;
            this.TouchGreenBtn.Direction = ShapeControl.LineDirection.None;
            this.TouchGreenBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TouchGreenBtn.Location = new System.Drawing.Point(182, 182);
            this.TouchGreenBtn.Margin = new System.Windows.Forms.Padding(0);
            this.TouchGreenBtn.Name = "TouchGreenBtn";
            this.TouchGreenBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.TouchGreenBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("TouchGreenBtn.ShapeImage")));
            this.TouchGreenBtn.ShapeImageRotation = 0;
            this.TouchGreenBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("TouchGreenBtn.ShapeImageTexture")));
            this.TouchGreenBtn.ShapeStorageLoadFile = "";
            this.TouchGreenBtn.ShapeStorageSaveFile = "";
            this.TouchGreenBtn.Size = new System.Drawing.Size(177, 177);
            this.TouchGreenBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchGreenBtn.TabIndex = 12;
            this.TouchGreenBtn.Tag2 = "";
            this.TouchGreenBtn.UseGradient = false;
            this.TouchGreenBtn.Vibrate = false;
            // 
            // TouchIndigoBtn
            // 
            this.TouchIndigoBtn.AnimateBorder = false;
            this.TouchIndigoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchIndigoBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TouchIndigoBtn.BackgroundImage")));
            this.TouchIndigoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TouchIndigoBtn.Blink = false;
            this.TouchIndigoBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchIndigoBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TouchIndigoBtn.BorderWidth = 3;
            this.TouchIndigoBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchIndigoBtn.Connector = ShapeControl.ConnecterType.Center;
            this.TouchIndigoBtn.Direction = ShapeControl.LineDirection.None;
            this.TouchIndigoBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TouchIndigoBtn.Location = new System.Drawing.Point(2, 182);
            this.TouchIndigoBtn.Name = "TouchIndigoBtn";
            this.TouchIndigoBtn.Shape = ShapeControl.ShapeType.Rectangle;
            this.TouchIndigoBtn.ShapeImage = ((System.Drawing.Image)(resources.GetObject("TouchIndigoBtn.ShapeImage")));
            this.TouchIndigoBtn.ShapeImageRotation = 0;
            this.TouchIndigoBtn.ShapeImageTexture = ((System.Drawing.Image)(resources.GetObject("TouchIndigoBtn.ShapeImageTexture")));
            this.TouchIndigoBtn.ShapeStorageLoadFile = "";
            this.TouchIndigoBtn.ShapeStorageSaveFile = "";
            this.TouchIndigoBtn.Size = new System.Drawing.Size(177, 177);
            this.TouchIndigoBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchIndigoBtn.TabIndex = 12;
            this.TouchIndigoBtn.Tag2 = "";
            this.TouchIndigoBtn.UseGradient = false;
            this.TouchIndigoBtn.Vibrate = false;
            // 
            // TouchCircleBtn
            // 
            this.TouchCircleBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TouchCircleBtn.BackgroundImage")));
            this.TouchCircleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TouchCircleBtn.Controls.Add(this.TouchTouchBoardPnl);
            this.TouchCircleBtn.Controls.Add(this.TouchMovingPart);
            this.TouchCircleBtn.Location = new System.Drawing.Point(0, 0);
            this.TouchCircleBtn.Margin = new System.Windows.Forms.Padding(0);
            this.TouchCircleBtn.Name = "TouchCircleBtn";
            this.TouchCircleBtn.Size = new System.Drawing.Size(360, 360);
            this.TouchCircleBtn.TabIndex = 2;
            // 
            // TouchTouchBoardPnl
            // 
            this.TouchTouchBoardPnl.AnimateBorder = false;
            this.TouchTouchBoardPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchTouchBoardPnl.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.touch_board;
            this.TouchTouchBoardPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TouchTouchBoardPnl.Blink = false;
            this.TouchTouchBoardPnl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchTouchBoardPnl.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TouchTouchBoardPnl.BorderWidth = 3;
            this.TouchTouchBoardPnl.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchTouchBoardPnl.Connector = ShapeControl.ConnecterType.Center;
            this.TouchTouchBoardPnl.Direction = ShapeControl.LineDirection.None;
            this.TouchTouchBoardPnl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TouchTouchBoardPnl.Location = new System.Drawing.Point(50, 50);
            this.TouchTouchBoardPnl.Name = "TouchTouchBoardPnl";
            this.TouchTouchBoardPnl.Shape = ShapeControl.ShapeType.Ellipse;
            this.TouchTouchBoardPnl.ShapeImage = null;
            this.TouchTouchBoardPnl.ShapeImageRotation = 0;
            this.TouchTouchBoardPnl.ShapeImageTexture = null;
            this.TouchTouchBoardPnl.ShapeStorageLoadFile = "";
            this.TouchTouchBoardPnl.ShapeStorageSaveFile = "";
            this.TouchTouchBoardPnl.Size = new System.Drawing.Size(260, 260);
            this.TouchTouchBoardPnl.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchTouchBoardPnl.TabIndex = 18;
            this.TouchTouchBoardPnl.Tag2 = "";
            this.TouchTouchBoardPnl.UseGradient = false;
            this.TouchTouchBoardPnl.Vibrate = false;
            this.TouchTouchBoardPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.TouchTouchBoardPnl_Paint);
            this.TouchTouchBoardPnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TouchTouchBoardPnl_MouseDown);
            this.TouchTouchBoardPnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TouchTouchBoardPnl_MouseMove);
            this.TouchTouchBoardPnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TouchTouchBoardPnl_MouseUp);
            // 
            // TouchMovingPart
            // 
            this.TouchMovingPart.AnimateBorder = false;
            this.TouchMovingPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchMovingPart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TouchMovingPart.BackgroundImage")));
            this.TouchMovingPart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TouchMovingPart.Blink = false;
            this.TouchMovingPart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchMovingPart.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TouchMovingPart.BorderWidth = 3;
            this.TouchMovingPart.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchMovingPart.Connector = ShapeControl.ConnecterType.Center;
            this.TouchMovingPart.Direction = ShapeControl.LineDirection.None;
            this.TouchMovingPart.Enabled = false;
            this.TouchMovingPart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TouchMovingPart.Location = new System.Drawing.Point(164, 15);
            this.TouchMovingPart.Name = "TouchMovingPart";
            this.TouchMovingPart.Shape = ShapeControl.ShapeType.Ellipse;
            this.TouchMovingPart.ShapeImage = null;
            this.TouchMovingPart.ShapeImageRotation = 0;
            this.TouchMovingPart.ShapeImageTexture = null;
            this.TouchMovingPart.ShapeStorageLoadFile = "";
            this.TouchMovingPart.ShapeStorageSaveFile = "";
            this.TouchMovingPart.Size = new System.Drawing.Size(30, 30);
            this.TouchMovingPart.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchMovingPart.TabIndex = 12;
            this.TouchMovingPart.Tag2 = "";
            this.TouchMovingPart.UseGradient = false;
            this.TouchMovingPart.Vibrate = false;
            // 
            // MousePositionTimer
            // 
            this.MousePositionTimer.Interval = 25;
            this.MousePositionTimer.Tick += new System.EventHandler(this.MousePositionTimer_Tick);
            // 
            // TouchControllerBorderPnl
            // 
            this.TouchControllerBorderPnl.AnimateBorder = false;
            this.TouchControllerBorderPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchControllerBorderPnl.Blink = false;
            this.TouchControllerBorderPnl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchControllerBorderPnl.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.TouchControllerBorderPnl.BorderWidth = 10;
            this.TouchControllerBorderPnl.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TouchControllerBorderPnl.Connector = ShapeControl.ConnecterType.Center;
            this.TouchControllerBorderPnl.Direction = ShapeControl.LineDirection.None;
            this.TouchControllerBorderPnl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.TouchControllerBorderPnl.Location = new System.Drawing.Point(0, 0);
            this.TouchControllerBorderPnl.Margin = new System.Windows.Forms.Padding(0);
            this.TouchControllerBorderPnl.Name = "TouchControllerBorderPnl";
            this.TouchControllerBorderPnl.Shape = ShapeControl.ShapeType.Rectangle;
            this.TouchControllerBorderPnl.ShapeImage = null;
            this.TouchControllerBorderPnl.ShapeImageRotation = 0;
            this.TouchControllerBorderPnl.ShapeImageTexture = null;
            this.TouchControllerBorderPnl.ShapeStorageLoadFile = "";
            this.TouchControllerBorderPnl.ShapeStorageSaveFile = "";
            this.TouchControllerBorderPnl.Size = new System.Drawing.Size(380, 380);
            this.TouchControllerBorderPnl.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TouchControllerBorderPnl.TabIndex = 18;
            this.TouchControllerBorderPnl.Tag2 = "";
            this.TouchControllerBorderPnl.UseGradient = false;
            this.TouchControllerBorderPnl.Vibrate = false;
            this.TouchControllerBorderPnl.Click += new System.EventHandler(this.TouchControllerBorderPnl_Click);
            // 
            // TouchControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(517, 431);
            this.Controls.Add(this.MouseButtonlbl);
            this.Controls.Add(this.TouchControllerPnl);
            this.Controls.Add(this.TouchControllerBorderPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 1600);
            this.Name = "TouchControllerForm";
            this.Load += new System.EventHandler(this.TouchControllerForm_Load);
            this.VisibleChanged += new System.EventHandler(this.TouchControllerForm_VisibleChanged);
            this.TouchControllerPnl.ResumeLayout(false);
            this.TouchCircleBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel TouchCircleBtn;
        private ShapeControl.CustomControl1 TouchDangerBtn;
        private ShapeControl.CustomControl1 TouchGreenBtn;
        private ShapeControl.CustomControl1 TouchIndigoBtn;
        private ShapeControl.CustomControl1 TouchBlueBtn;
        private ShapeControl.CustomControl1 TouchMovingPart;
        private System.Windows.Forms.Label MouseButtonlbl;
        private System.Windows.Forms.Panel TouchControllerPnl;
        private ShapeControl.CustomControl1 TouchTouchBoardPnl;
        private System.Windows.Forms.Timer MousePositionTimer;
        private ShapeControl.CustomControl1 TouchControllerBorderPnl;
    }
}