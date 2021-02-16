namespace OnScreenVirtualJoystickController
{
    partial class NormalControllerForm
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
            this.NormalControllerPnl = new System.Windows.Forms.Panel();
            this.NormalCircleBtn = new System.Windows.Forms.Panel();
            this.NormalMovingPart = new System.Windows.Forms.PictureBox();
            this.NormalBlueBtn = new System.Windows.Forms.Panel();
            this.NormalGreenBtn = new System.Windows.Forms.Panel();
            this.NormalIndigoBtn = new System.Windows.Forms.Panel();
            this.NormalDangerBtn = new System.Windows.Forms.Panel();
            this.MouseButtonlbl = new System.Windows.Forms.Label();
            this.NormalControllerBorderPnl = new ShapeControl.CustomControl1();
            this.MousePositionTimer = new System.Windows.Forms.Timer(this.components);
            this.MouseFollowDelayTimer = new System.Windows.Forms.Timer(this.components);
            this.VirtualMouse = new ShapeControl.CustomControl1();
            this.NormalControllerPnl.SuspendLayout();
            this.NormalCircleBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NormalMovingPart)).BeginInit();
            this.NormalControllerBorderPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // NormalControllerPnl
            // 
            this.NormalControllerPnl.AutoSize = true;
            this.NormalControllerPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NormalControllerPnl.BackColor = System.Drawing.Color.Transparent;
            this.NormalControllerPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalControllerPnl.Controls.Add(this.NormalCircleBtn);
            this.NormalControllerPnl.Controls.Add(this.NormalBlueBtn);
            this.NormalControllerPnl.Controls.Add(this.NormalGreenBtn);
            this.NormalControllerPnl.Controls.Add(this.NormalIndigoBtn);
            this.NormalControllerPnl.Controls.Add(this.NormalDangerBtn);
            this.NormalControllerPnl.Location = new System.Drawing.Point(10, 10);
            this.NormalControllerPnl.Margin = new System.Windows.Forms.Padding(0);
            this.NormalControllerPnl.Name = "NormalControllerPnl";
            this.NormalControllerPnl.Size = new System.Drawing.Size(430, 350);
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
            this.NormalCircleBtn.Size = new System.Drawing.Size(350, 350);
            this.NormalCircleBtn.TabIndex = 9;
            // 
            // NormalMovingPart
            // 
            this.NormalMovingPart.BackColor = System.Drawing.Color.Transparent;
            this.NormalMovingPart.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.movingpart_mornal;
            this.NormalMovingPart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalMovingPart.Enabled = false;
            this.NormalMovingPart.Location = new System.Drawing.Point(150, 150);
            this.NormalMovingPart.Name = "NormalMovingPart";
            this.NormalMovingPart.Size = new System.Drawing.Size(50, 50);
            this.NormalMovingPart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NormalMovingPart.TabIndex = 0;
            this.NormalMovingPart.TabStop = false;
            // 
            // NormalBlueBtn
            // 
            this.NormalBlueBtn.BackColor = System.Drawing.Color.Transparent;
            this.NormalBlueBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.bluebutton_normal;
            this.NormalBlueBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalBlueBtn.Location = new System.Drawing.Point(350, 270);
            this.NormalBlueBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NormalBlueBtn.Name = "NormalBlueBtn";
            this.NormalBlueBtn.Size = new System.Drawing.Size(80, 80);
            this.NormalBlueBtn.TabIndex = 5;
            // 
            // NormalGreenBtn
            // 
            this.NormalGreenBtn.BackColor = System.Drawing.Color.Transparent;
            this.NormalGreenBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.greenbutton_normal;
            this.NormalGreenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalGreenBtn.Location = new System.Drawing.Point(350, 180);
            this.NormalGreenBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NormalGreenBtn.Name = "NormalGreenBtn";
            this.NormalGreenBtn.Size = new System.Drawing.Size(80, 80);
            this.NormalGreenBtn.TabIndex = 6;
            // 
            // NormalIndigoBtn
            // 
            this.NormalIndigoBtn.BackColor = System.Drawing.Color.Transparent;
            this.NormalIndigoBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.indigobutton_normal;
            this.NormalIndigoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalIndigoBtn.Location = new System.Drawing.Point(350, 90);
            this.NormalIndigoBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NormalIndigoBtn.Name = "NormalIndigoBtn";
            this.NormalIndigoBtn.Size = new System.Drawing.Size(80, 80);
            this.NormalIndigoBtn.TabIndex = 8;
            // 
            // NormalDangerBtn
            // 
            this.NormalDangerBtn.BackgroundImage = global::OnScreenVirtualJoystickController.Properties.Resources.dangerbutton_normal;
            this.NormalDangerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalDangerBtn.Location = new System.Drawing.Point(350, 0);
            this.NormalDangerBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NormalDangerBtn.Name = "NormalDangerBtn";
            this.NormalDangerBtn.Size = new System.Drawing.Size(80, 80);
            this.NormalDangerBtn.TabIndex = 7;
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
            this.MouseButtonlbl.TabIndex = 15;
            // 
            // NormalControllerBorderPnl
            // 
            this.NormalControllerBorderPnl.AnimateBorder = false;
            this.NormalControllerBorderPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NormalControllerBorderPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NormalControllerBorderPnl.Blink = false;
            this.NormalControllerBorderPnl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.NormalControllerBorderPnl.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.NormalControllerBorderPnl.BorderWidth = 10;
            this.NormalControllerBorderPnl.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NormalControllerBorderPnl.Connector = ShapeControl.ConnecterType.Center;
            this.NormalControllerBorderPnl.Controls.Add(this.NormalControllerPnl);
            this.NormalControllerBorderPnl.Direction = ShapeControl.LineDirection.None;
            this.NormalControllerBorderPnl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.NormalControllerBorderPnl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NormalControllerBorderPnl.Location = new System.Drawing.Point(0, 0);
            this.NormalControllerBorderPnl.Name = "NormalControllerBorderPnl";
            this.NormalControllerBorderPnl.Shape = ShapeControl.ShapeType.Rectangle;
            this.NormalControllerBorderPnl.ShapeImage = null;
            this.NormalControllerBorderPnl.ShapeImageRotation = 0;
            this.NormalControllerBorderPnl.ShapeImageTexture = null;
            this.NormalControllerBorderPnl.ShapeStorageLoadFile = "";
            this.NormalControllerBorderPnl.ShapeStorageSaveFile = "";
            this.NormalControllerBorderPnl.Size = new System.Drawing.Size(450, 370);
            this.NormalControllerBorderPnl.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NormalControllerBorderPnl.TabIndex = 16;
            this.NormalControllerBorderPnl.Tag2 = "";
            this.NormalControllerBorderPnl.UseGradient = false;
            this.NormalControllerBorderPnl.Vibrate = false;
            this.NormalControllerBorderPnl.Click += new System.EventHandler(this.NormalControllerBorderPnl_Click);
            // 
            // MousePositionTimer
            // 
            this.MousePositionTimer.Interval = 25;
            this.MousePositionTimer.Tick += new System.EventHandler(this.MousePositionTimer_Tick);
            // 
            // MouseFollowDelayTimer
            // 
            this.MouseFollowDelayTimer.Interval = 3000;
            this.MouseFollowDelayTimer.Tick += new System.EventHandler(this.MouseFollowDelayTimer_Tick);
            // 
            // VirtualMouse
            // 
            this.VirtualMouse.AnimateBorder = false;
            this.VirtualMouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VirtualMouse.Blink = false;
            this.VirtualMouse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VirtualMouse.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.VirtualMouse.BorderWidth = 3;
            this.VirtualMouse.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VirtualMouse.Connector = ShapeControl.ConnecterType.Center;
            this.VirtualMouse.Direction = ShapeControl.LineDirection.None;
            this.VirtualMouse.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.VirtualMouse.Location = new System.Drawing.Point(491, 309);
            this.VirtualMouse.Name = "VirtualMouse";
            this.VirtualMouse.Shape = ShapeControl.ShapeType.Ellipse;
            this.VirtualMouse.ShapeImage = null;
            this.VirtualMouse.ShapeImageRotation = 0;
            this.VirtualMouse.ShapeImageTexture = null;
            this.VirtualMouse.ShapeStorageLoadFile = "";
            this.VirtualMouse.ShapeStorageSaveFile = "";
            this.VirtualMouse.Size = new System.Drawing.Size(25, 25);
            this.VirtualMouse.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.VirtualMouse.TabIndex = 17;
            this.VirtualMouse.Tag2 = "";
            this.VirtualMouse.UseGradient = false;
            this.VirtualMouse.Vibrate = false;
            this.VirtualMouse.Visible = false;
            // 
            // NormalControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(556, 412);
            this.Controls.Add(this.VirtualMouse);
            this.Controls.Add(this.MouseButtonlbl);
            this.Controls.Add(this.NormalControllerBorderPnl);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NormalControllerForm";
            this.Text = "NormalControllerForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NormalControllerForm_FormClosed);
            this.Load += new System.EventHandler(this.NormalControllerForm_Load);
            this.VisibleChanged += new System.EventHandler(this.NormalControllerForm_VisibleChanged);
            this.NormalControllerPnl.ResumeLayout(false);
            this.NormalCircleBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NormalMovingPart)).EndInit();
            this.NormalControllerBorderPnl.ResumeLayout(false);
            this.NormalControllerBorderPnl.PerformLayout();
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
        private System.Windows.Forms.Label MouseButtonlbl;
        private ShapeControl.CustomControl1 NormalControllerBorderPnl;
        private System.Windows.Forms.Timer MousePositionTimer;
        private System.Windows.Forms.Timer MouseFollowDelayTimer;
        private ShapeControl.CustomControl1 VirtualMouse;
    }
}