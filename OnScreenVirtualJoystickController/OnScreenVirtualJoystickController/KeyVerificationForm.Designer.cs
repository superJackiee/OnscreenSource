namespace OnScreenVirtualJoystickController
{
    partial class KeyVerificationForm 
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

        public void setProductID(string value)
        {
            ProductIDLbl.Text = value;
            //string new_value = productID_label.Text;
            //new_value += ' ' + value;
            //productID_label.Text = new_value;
        }

        public void setFailedMessage()
        {
            failed_label.Text = "Please input valid license key.";
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ok_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.productID_label = new System.Windows.Forms.Label();
            this.license_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.failed_label = new System.Windows.Forms.Label();
            this.ProductIDLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ok_btn
            // 
            this.ok_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ok_btn.Location = new System.Drawing.Point(174, 81);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(70, 23);
            this.ok_btn.TabIndex = 0;
            this.ok_btn.Text = "OK";
            this.ok_btn.UseVisualStyleBackColor = false;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.Gray;
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Location = new System.Drawing.Point(248, 81);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(70, 23);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "CANCEL";
            this.cancel_btn.UseVisualStyleBackColor = false;
            // 
            // productID_label
            // 
            this.productID_label.AutoSize = true;
            this.productID_label.Location = new System.Drawing.Point(12, 18);
            this.productID_label.Name = "productID_label";
            this.productID_label.Size = new System.Drawing.Size(58, 13);
            this.productID_label.TabIndex = 2;
            this.productID_label.Text = "ProductID:";
            // 
            // license_textbox
            // 
            this.license_textbox.Location = new System.Drawing.Point(86, 43);
            this.license_textbox.Name = "license_textbox";
            this.license_textbox.Size = new System.Drawing.Size(242, 20);
            this.license_textbox.TabIndex = 3;
            this.license_textbox.TextChanged += new System.EventHandler(this.license_textbox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "License Key:";
            // 
            // failed_label
            // 
            this.failed_label.AutoSize = true;
            this.failed_label.ForeColor = System.Drawing.Color.DarkRed;
            this.failed_label.Location = new System.Drawing.Point(15, 84);
            this.failed_label.Name = "failed_label";
            this.failed_label.Size = new System.Drawing.Size(0, 13);
            this.failed_label.TabIndex = 5;
            // 
            // ProductIDLbl
            // 
            this.ProductIDLbl.AutoSize = true;
            this.ProductIDLbl.Location = new System.Drawing.Point(86, 18);
            this.ProductIDLbl.Name = "ProductIDLbl";
            this.ProductIDLbl.Size = new System.Drawing.Size(0, 13);
            this.ProductIDLbl.TabIndex = 6;
            // 
            // KeyVerificationForm
            // 
            this.AcceptButton = this.ok_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.ProductIDLbl);
            this.Controls.Add(this.failed_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.license_textbox);
            this.Controls.Add(this.productID_label);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.ok_btn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 150);
            this.Name = "KeyVerificationForm";
            this.ShowIcon = false;
            this.Text = "Input License Key";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label productID_label;
        private System.Windows.Forms.TextBox license_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label failed_label;
        private System.Windows.Forms.Label ProductIDLbl;
    }
}