namespace OnScreenVirtualJoystickController
{
    partial class ButtonForm
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
            this.ButtonBtn = new ShapeControl.CustomControl1();
            this.ResizeTopLeft = new System.Windows.Forms.Panel();
            this.ResizeTopCenter = new System.Windows.Forms.Panel();
            this.ResizeTopRight = new System.Windows.Forms.Panel();
            this.ResizeMiddleRight = new System.Windows.Forms.Panel();
            this.ResizeBottomRight = new System.Windows.Forms.Panel();
            this.ResizeBottomCenter = new System.Windows.Forms.Panel();
            this.ResizeBottomLeft = new System.Windows.Forms.Panel();
            this.ResizeMiddleLeft = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ButtonBtn
            // 
            this.ButtonBtn.AnimateBorder = false;
            this.ButtonBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ButtonBtn.Blink = false;
            this.ButtonBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ButtonBtn.BorderWidth = 0;
            this.ButtonBtn.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonBtn.Connector = ShapeControl.ConnecterType.Center;
            this.ButtonBtn.Direction = ShapeControl.LineDirection.None;
            this.ButtonBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonBtn.Location = new System.Drawing.Point(10, 10);
            this.ButtonBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonBtn.Name = "ButtonBtn";
            this.ButtonBtn.Shape = ShapeControl.ShapeType.Ellipse;
            this.ButtonBtn.ShapeImage = null;
            this.ButtonBtn.ShapeImageRotation = 0;
            this.ButtonBtn.ShapeImageTexture = null;
            this.ButtonBtn.ShapeStorageLoadFile = "";
            this.ButtonBtn.ShapeStorageSaveFile = "";
            this.ButtonBtn.Size = new System.Drawing.Size(350, 350);
            this.ButtonBtn.SurroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonBtn.TabIndex = 1;
            this.ButtonBtn.Tag2 = "";
            this.ButtonBtn.UseGradient = false;
            this.ButtonBtn.Vibrate = false;
            this.ButtonBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonBtn_MouseDown);
            this.ButtonBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonBtn_MouseMove);
            this.ButtonBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonBtn_MouseUp);
            // 
            // ResizeTopLeft
            // 
            this.ResizeTopLeft.BackColor = System.Drawing.Color.Black;
            this.ResizeTopLeft.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ResizeTopLeft.Location = new System.Drawing.Point(0, 0);
            this.ResizeTopLeft.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeTopLeft.Name = "ResizeTopLeft";
            this.ResizeTopLeft.Size = new System.Drawing.Size(10, 10);
            this.ResizeTopLeft.TabIndex = 2;
            this.ResizeTopLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeTopLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeTopLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeTopCenter
            // 
            this.ResizeTopCenter.BackColor = System.Drawing.Color.Black;
            this.ResizeTopCenter.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.ResizeTopCenter.Location = new System.Drawing.Point(180, 0);
            this.ResizeTopCenter.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeTopCenter.Name = "ResizeTopCenter";
            this.ResizeTopCenter.Size = new System.Drawing.Size(10, 10);
            this.ResizeTopCenter.TabIndex = 2;
            this.ResizeTopCenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeTopCenter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeTopCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeTopRight
            // 
            this.ResizeTopRight.BackColor = System.Drawing.Color.Black;
            this.ResizeTopRight.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.ResizeTopRight.Location = new System.Drawing.Point(360, 0);
            this.ResizeTopRight.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeTopRight.Name = "ResizeTopRight";
            this.ResizeTopRight.Size = new System.Drawing.Size(10, 10);
            this.ResizeTopRight.TabIndex = 2;
            this.ResizeTopRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeTopRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeTopRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeMiddleRight
            // 
            this.ResizeMiddleRight.BackColor = System.Drawing.Color.Black;
            this.ResizeMiddleRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.ResizeMiddleRight.Location = new System.Drawing.Point(360, 180);
            this.ResizeMiddleRight.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeMiddleRight.Name = "ResizeMiddleRight";
            this.ResizeMiddleRight.Size = new System.Drawing.Size(10, 10);
            this.ResizeMiddleRight.TabIndex = 2;
            this.ResizeMiddleRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeMiddleRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeMiddleRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeBottomRight
            // 
            this.ResizeBottomRight.BackColor = System.Drawing.Color.Black;
            this.ResizeBottomRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ResizeBottomRight.Location = new System.Drawing.Point(360, 360);
            this.ResizeBottomRight.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeBottomRight.Name = "ResizeBottomRight";
            this.ResizeBottomRight.Size = new System.Drawing.Size(10, 10);
            this.ResizeBottomRight.TabIndex = 2;
            this.ResizeBottomRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeBottomRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeBottomRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeBottomCenter
            // 
            this.ResizeBottomCenter.BackColor = System.Drawing.Color.Black;
            this.ResizeBottomCenter.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.ResizeBottomCenter.Location = new System.Drawing.Point(180, 360);
            this.ResizeBottomCenter.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeBottomCenter.Name = "ResizeBottomCenter";
            this.ResizeBottomCenter.Size = new System.Drawing.Size(10, 10);
            this.ResizeBottomCenter.TabIndex = 2;
            this.ResizeBottomCenter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeBottomCenter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeBottomCenter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeBottomLeft
            // 
            this.ResizeBottomLeft.BackColor = System.Drawing.Color.Black;
            this.ResizeBottomLeft.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.ResizeBottomLeft.Location = new System.Drawing.Point(0, 360);
            this.ResizeBottomLeft.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeBottomLeft.Name = "ResizeBottomLeft";
            this.ResizeBottomLeft.Size = new System.Drawing.Size(10, 10);
            this.ResizeBottomLeft.TabIndex = 2;
            this.ResizeBottomLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeBottomLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeBottomLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ResizeMiddleLeft
            // 
            this.ResizeMiddleLeft.BackColor = System.Drawing.Color.Black;
            this.ResizeMiddleLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.ResizeMiddleLeft.Location = new System.Drawing.Point(0, 180);
            this.ResizeMiddleLeft.Margin = new System.Windows.Forms.Padding(0);
            this.ResizeMiddleLeft.Name = "ResizeMiddleLeft";
            this.ResizeMiddleLeft.Size = new System.Drawing.Size(10, 10);
            this.ResizeMiddleLeft.TabIndex = 2;
            this.ResizeMiddleLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.ResizeMiddleLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.ResizeMiddleLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            // 
            // ButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(370, 370);
            this.Controls.Add(this.ResizeMiddleLeft);
            this.Controls.Add(this.ResizeBottomLeft);
            this.Controls.Add(this.ResizeBottomCenter);
            this.Controls.Add(this.ResizeBottomRight);
            this.Controls.Add(this.ResizeMiddleRight);
            this.Controls.Add(this.ResizeTopRight);
            this.Controls.Add(this.ResizeTopCenter);
            this.Controls.Add(this.ResizeTopLeft);
            this.Controls.Add(this.ButtonBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ButtonForm";
            this.Text = "ButtonForm";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Activated += new System.EventHandler(this.ButtonForm_Activated);
            this.Deactivate += new System.EventHandler(this.ButtonForm_Deactivate);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Resize_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private ShapeControl.CustomControl1 ButtonBtn;
        private System.Windows.Forms.Panel ResizeTopLeft;
        private System.Windows.Forms.Panel ResizeTopCenter;
        private System.Windows.Forms.Panel ResizeTopRight;
        private System.Windows.Forms.Panel ResizeMiddleRight;
        private System.Windows.Forms.Panel ResizeBottomRight;
        private System.Windows.Forms.Panel ResizeBottomCenter;
        private System.Windows.Forms.Panel ResizeBottomLeft;
        private System.Windows.Forms.Panel ResizeMiddleLeft;
    }
}