using IDTaotlus.Helpers;

namespace IDTaotlus
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.GroupBox();
            this.username = new System.Windows.Forms.TextBox();
            this.logbtn = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.loginBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kasutajatunnus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Salasõna";
            // 
            // loginBox
            // 
            this.loginBox.Controls.Add(this.username);
            this.loginBox.Controls.Add(this.logbtn);
            this.loginBox.Controls.Add(this.password);
            this.loginBox.Controls.Add(this.label2);
            this.loginBox.Controls.Add(this.label1);
            this.loginBox.Location = new System.Drawing.Point(12, 12);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(201, 150);
            this.loginBox.TabIndex = 5;
            this.loginBox.TabStop = false;
            this.loginBox.Text = "Logi Sisse";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(100, 28);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(94, 20);
            this.username.TabIndex = 0;
            this.username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.an_valid);
            // 
            // logbtn
            // 
            this.logbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logbtn.Image = global::IDTaotlus.Properties.Resources.Accept_icon;
            this.logbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logbtn.Location = new System.Drawing.Point(100, 103);
            this.logbtn.Name = "logbtn";
            this.logbtn.Size = new System.Drawing.Size(94, 29);
            this.logbtn.TabIndex = 4;
            this.logbtn.Text = "Sisene";
            this.logbtn.UseVisualStyleBackColor = true;
            this.logbtn.Click += new System.EventHandler(this.login);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(100, 67);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(94, 20);
            this.password.TabIndex = 1;
            this.password.UseSystemPasswordChar = true;
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.an_valid);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 174);
            this.Controls.Add(this.loginBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "Sisene";
            this.loginBox.ResumeLayout(false);
            this.loginBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button logbtn;
        private System.Windows.Forms.GroupBox loginBox;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
    }
}

