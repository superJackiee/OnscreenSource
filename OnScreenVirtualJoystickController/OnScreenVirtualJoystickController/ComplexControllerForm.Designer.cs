namespace OnScreenVirtualJoystickController
{
    partial class ComplexControllerForm
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
            this.MouseButtonlbl = new System.Windows.Forms.Label();
            this.ComplexControllerPnl = new System.Windows.Forms.Panel();
            this.ComplexCircleBtn = new ShapeControl.CustomControl1();
            this.ComplexMovingPart = new ShapeControl.CustomControl1();
            this.ComplexUpBtn = new System.Windows.Forms.Panel();
            this.ComplexDangerBtn = new System.Windows.Forms.Panel();
            this.ComplexDownBtn = new System.Windows.Forms.Panel();
            this.ComplexLeftBtn = new System.Windows.Forms.Panel();
            this.ComplexRightBtn = new System.Windows.Forms.Panel();
            this.ComplexBlueBtn = new System.Windows.Forms.Panel();
            this.ComplexGreenBtn = new System.Windows.Forms.Panel();
            this.ComplexIndigoBtn = new System.Windows.Forms.Panel();
            this.MousePositionTimer = new System.Windows.Forms.Timer(this.components);
            this.ComplexControllerBorderPnl = new ShapeControl.CustomControl1();
            this.MouseFollowDelayTimer = new System.Windows.Forms.Timer(this.components);
            this.ComplexControllerPnl.SuspendLayout();
            this.ComplexCircleBtn.SuspendLayout();
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
            this.MouseButtonlbl.TabIndex = 14;
            // 
            // ComplexControllerPnl
            // 
            this.ComplexControllerPnl.AutoSize = true;
            this.ComplexControllerPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ComplexControllerPnl.Controls.Add(this.ComplexCircleBtn);
            this.ComplexControllerPnl.Controls.Add(this.ComplexUpBtn);
            this.ComplexControllerPnl.Controls.Add(this.ComplexDangerBtn);
            this.ComplexControllerPnl.Controls.Add(this.ComplexDownBtn);
            this.ComplexControllerPnl.Controls.Add(this.ComplexLeftBtn);
            this.ComplexControllerPnl.Controls.Add(this.ComplexRightBtn);
            this.ComplexControllerPnl.Controls.Add(this.ComplexBlueBtn);
            this.ComplexControllerPnl.Controls.Add(this.ComplexGreenBtn);
            this.ComplexControllerPnl.Controls.Add(this.ComplexIndigoBtn);
            this.ComplexControllerPnl.Location = new System.Drawing.Point(10, 10);
            this.ComplexControllerPnl.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexControllerPnl.Name = "ComplexControllerPnl";
            this.ComplexControllerPnl.Size = new System.Drawing.Size(350, 350);
            this.ComplexControllerPnl.TabIndex = 15;
            // 
            // ComplexCircleBtn
            // 
            this.ComplexCircleBtn.AnimateBorder = false;
            this.ComplexCircleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ComplexCircleBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.curcle_complex;
            this.ComplexCircleBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ComplexCircleBtn.Blink = false;
            this.ComplexCircleBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ComplexCircleBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ComplexCircleBtn.BorderWidth = 2;
            this.ComplexCircleBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ComplexCircleBtn.Connector = ShapeControl.ConnecterType.Center;
            this.ComplexCircleBtn.Controls.Add(this.ComplexMovingPart);
            this.ComplexCircleBtn.Direction = ShapeControl.LineDirection.None;
            this.ComplexCircleBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.ComplexCircleBtn.Location = new System.Drawing.Point(95, 95);
            this.ComplexCircleBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexCircleBtn.Name = "ComplexCircleBtn";
            this.ComplexCircleBtn.Shape = ShapeControl.ShapeType.Ellipse;
            this.ComplexCircleBtn.ShapeImage = null;
            this.ComplexCircleBtn.ShapeImageRotation = 0;
            this.ComplexCircleBtn.ShapeImageTexture = null;
            this.ComplexCircleBtn.ShapeStorageLoadFile = "";
            this.ComplexCircleBtn.ShapeStorageSaveFile = "";
            this.ComplexCircleBtn.Size = new System.Drawing.Size(160, 160);
            this.ComplexCircleBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ComplexCircleBtn.TabIndex = 14;
            this.ComplexCircleBtn.Tag2 = "";
            this.ComplexCircleBtn.UseGradient = false;
            this.ComplexCircleBtn.Vibrate = false;
            // 
            // ComplexMovingPart
            // 
            this.ComplexMovingPart.AnimateBorder = false;
            this.ComplexMovingPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ComplexMovingPart.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.movingpart_complex;
            this.ComplexMovingPart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ComplexMovingPart.Blink = false;
            this.ComplexMovingPart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ComplexMovingPart.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ComplexMovingPart.BorderWidth = 3;
            this.ComplexMovingPart.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ComplexMovingPart.Connector = ShapeControl.ConnecterType.Center;
            this.ComplexMovingPart.Direction = ShapeControl.LineDirection.None;
            this.ComplexMovingPart.Enabled = false;
            this.ComplexMovingPart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.ComplexMovingPart.Location = new System.Drawing.Point(65, 65);
            this.ComplexMovingPart.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexMovingPart.Name = "ComplexMovingPart";
            this.ComplexMovingPart.Shape = ShapeControl.ShapeType.Ellipse;
            this.ComplexMovingPart.ShapeImage = null;
            this.ComplexMovingPart.ShapeImageRotation = 0;
            this.ComplexMovingPart.ShapeImageTexture = null;
            this.ComplexMovingPart.ShapeStorageLoadFile = "";
            this.ComplexMovingPart.ShapeStorageSaveFile = "";
            this.ComplexMovingPart.Size = new System.Drawing.Size(30, 30);
            this.ComplexMovingPart.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ComplexMovingPart.TabIndex = 0;
            this.ComplexMovingPart.Tag2 = "";
            this.ComplexMovingPart.UseGradient = false;
            this.ComplexMovingPart.Vibrate = false;
            // 
            // ComplexUpBtn
            // 
            this.ComplexUpBtn.BackColor = System.Drawing.Color.Transparent;
            this.ComplexUpBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.upbutton_complex;
            this.ComplexUpBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ComplexUpBtn.Location = new System.Drawing.Point(130, 0);
            this.ComplexUpBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexUpBtn.Name = "ComplexUpBtn";
            this.ComplexUpBtn.Size = new System.Drawing.Size(90, 113);
            this.ComplexUpBtn.TabIndex = 14;
            // 
            // ComplexDangerBtn
            // 
            this.ComplexDangerBtn.BackColor = System.Drawing.Color.Transparent;
            this.ComplexDangerBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.dangerbutton_complex;
            this.ComplexDangerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ComplexDangerBtn.Location = new System.Drawing.Point(0, 0);
            this.ComplexDangerBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexDangerBtn.Name = "ComplexDangerBtn";
            this.ComplexDangerBtn.Size = new System.Drawing.Size(130, 130);
            this.ComplexDangerBtn.TabIndex = 7;
            // 
            // ComplexDownBtn
            // 
            this.ComplexDownBtn.BackColor = System.Drawing.Color.Transparent;
            this.ComplexDownBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.downbutton_complex;
            this.ComplexDownBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ComplexDownBtn.Location = new System.Drawing.Point(130, 235);
            this.ComplexDownBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexDownBtn.Name = "ComplexDownBtn";
            this.ComplexDownBtn.Size = new System.Drawing.Size(90, 115);
            this.ComplexDownBtn.TabIndex = 13;
            // 
            // ComplexLeftBtn
            // 
            this.ComplexLeftBtn.BackColor = System.Drawing.Color.Transparent;
            this.ComplexLeftBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.leftbutton_complex;
            this.ComplexLeftBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ComplexLeftBtn.Location = new System.Drawing.Point(0, 130);
            this.ComplexLeftBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexLeftBtn.Name = "ComplexLeftBtn";
            this.ComplexLeftBtn.Size = new System.Drawing.Size(115, 90);
            this.ComplexLeftBtn.TabIndex = 12;
            // 
            // ComplexRightBtn
            // 
            this.ComplexRightBtn.BackColor = System.Drawing.Color.Transparent;
            this.ComplexRightBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.rightbutton_complex;
            this.ComplexRightBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ComplexRightBtn.Location = new System.Drawing.Point(235, 130);
            this.ComplexRightBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexRightBtn.Name = "ComplexRightBtn";
            this.ComplexRightBtn.Size = new System.Drawing.Size(115, 90);
            this.ComplexRightBtn.TabIndex = 11;
            // 
            // ComplexBlueBtn
            // 
            this.ComplexBlueBtn.BackColor = System.Drawing.Color.Transparent;
            this.ComplexBlueBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.bluebutton_complex;
            this.ComplexBlueBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ComplexBlueBtn.Location = new System.Drawing.Point(220, 0);
            this.ComplexBlueBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexBlueBtn.Name = "ComplexBlueBtn";
            this.ComplexBlueBtn.Size = new System.Drawing.Size(130, 130);
            this.ComplexBlueBtn.TabIndex = 5;
            // 
            // ComplexGreenBtn
            // 
            this.ComplexGreenBtn.BackColor = System.Drawing.Color.Transparent;
            this.ComplexGreenBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.greenbutton_complex;
            this.ComplexGreenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ComplexGreenBtn.Location = new System.Drawing.Point(220, 220);
            this.ComplexGreenBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexGreenBtn.Name = "ComplexGreenBtn";
            this.ComplexGreenBtn.Size = new System.Drawing.Size(130, 130);
            this.ComplexGreenBtn.TabIndex = 6;
            // 
            // ComplexIndigoBtn
            // 
            this.ComplexIndigoBtn.BackColor = System.Drawing.Color.Transparent;
            this.ComplexIndigoBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.indigobutton_complex;
            this.ComplexIndigoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ComplexIndigoBtn.Location = new System.Drawing.Point(0, 220);
            this.ComplexIndigoBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexIndigoBtn.Name = "ComplexIndigoBtn";
            this.ComplexIndigoBtn.Size = new System.Drawing.Size(130, 130);
            this.ComplexIndigoBtn.TabIndex = 8;
            // 
            // MousePositionTimer
            // 
            this.MousePositionTimer.Interval = 25;
            this.MousePositionTimer.Tick += new System.EventHandler(this.MousePositionTimer_Tick);
            // 
            // ComplexControllerBorderPnl
            // 
            this.ComplexControllerBorderPnl.AnimateBorder = false;
            this.ComplexControllerBorderPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ComplexControllerBorderPnl.Blink = false;
            this.ComplexControllerBorderPnl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ComplexControllerBorderPnl.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ComplexControllerBorderPnl.BorderWidth = 10;
            this.ComplexControllerBorderPnl.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ComplexControllerBorderPnl.Connector = ShapeControl.ConnecterType.Center;
            this.ComplexControllerBorderPnl.Direction = ShapeControl.LineDirection.None;
            this.ComplexControllerBorderPnl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.ComplexControllerBorderPnl.Location = new System.Drawing.Point(0, 0);
            this.ComplexControllerBorderPnl.Margin = new System.Windows.Forms.Padding(0);
            this.ComplexControllerBorderPnl.Name = "ComplexControllerBorderPnl";
            this.ComplexControllerBorderPnl.Shape = ShapeControl.ShapeType.Rectangle;
            this.ComplexControllerBorderPnl.ShapeImage = null;
            this.ComplexControllerBorderPnl.ShapeImageRotation = 0;
            this.ComplexControllerBorderPnl.ShapeImageTexture = null;
            this.ComplexControllerBorderPnl.ShapeStorageLoadFile = "";
            this.ComplexControllerBorderPnl.ShapeStorageSaveFile = "";
            this.ComplexControllerBorderPnl.Size = new System.Drawing.Size(370, 370);
            this.ComplexControllerBorderPnl.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ComplexControllerBorderPnl.TabIndex = 16;
            this.ComplexControllerBorderPnl.Tag2 = "";
            this.ComplexControllerBorderPnl.UseGradient = false;
            this.ComplexControllerBorderPnl.Vibrate = false;
            this.ComplexControllerBorderPnl.Click += new System.EventHandler(this.ComplexControllerBorderPnl_Click);
            // 
            // MouseFollowDelayTimer
            // 
            this.MouseFollowDelayTimer.Interval = 3000;
            this.MouseFollowDelayTimer.Tick += new System.EventHandler(this.MouseFollowDelayTimer_Tick);
            // 
            // ComplexControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(440, 429);
            this.Controls.Add(this.MouseButtonlbl);
            this.Controls.Add(this.ComplexControllerPnl);
            this.Controls.Add(this.ComplexControllerBorderPnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ComplexControllerForm";
            this.Text = "ComplexControllerForm";
            this.Load += new System.EventHandler(this.ComplexControllerForm_Load);
            this.VisibleChanged += new System.EventHandler(this.ComplexControllerForm_VisibleChanged);
            this.ComplexControllerPnl.ResumeLayout(false);
            this.ComplexCircleBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MouseButtonlbl;
        private System.Windows.Forms.Panel ComplexControllerPnl;
        private ShapeControl.CustomControl1 ComplexCircleBtn;
        private ShapeControl.CustomControl1 ComplexMovingPart;
        private System.Windows.Forms.Panel ComplexUpBtn;
        private System.Windows.Forms.Panel ComplexDownBtn;
        private System.Windows.Forms.Panel ComplexLeftBtn;
        private System.Windows.Forms.Panel ComplexRightBtn;
        private System.Windows.Forms.Panel ComplexBlueBtn;
        private System.Windows.Forms.Panel ComplexGreenBtn;
        private System.Windows.Forms.Panel ComplexIndigoBtn;
        private System.Windows.Forms.Panel ComplexDangerBtn;
        private System.Windows.Forms.Timer MousePositionTimer;
        private ShapeControl.CustomControl1 ComplexControllerBorderPnl;
        private System.Windows.Forms.Timer MouseFollowDelayTimer;
    }
}