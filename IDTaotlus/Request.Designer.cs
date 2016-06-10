using IDTaotlus.Helpers;

namespace IDTaotlus
{
    partial class Request
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Request));
            this.fname = new System.Windows.Forms.TextBox();
            this.isik = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.birthday = new System.Windows.Forms.TextBox();
            this.nationality = new System.Windows.Forms.TextBox();
            this.docnumber = new System.Windows.Forms.TextBox();
            this.pin = new System.Windows.Forms.TextBox();
            this.country = new System.Windows.Forms.TextBox();
            this.county = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dispense = new System.Windows.Forms.ComboBox();
            this.issdate = new System.Windows.Forms.TextBox();
            this.expdate = new System.Windows.Forms.TextBox();
            this.prevdoc = new System.Windows.Forms.CheckBox();
            this.gender = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.representative = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.docGrp = new System.Windows.Forms.GroupBox();
            this.idReqPush = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.addph = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.docGrp.SuspendLayout();
            this.idReqPush.SuspendLayout();
            this.SuspendLayout();
            // 
            // fname
            // 
            this.fname.Location = new System.Drawing.Point(117, 28);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(82, 20);
            this.fname.TabIndex = 2;
            this.fname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.let_valid);
            // 
            // isik
            // 
            this.isik.Location = new System.Drawing.Point(117, 84);
            this.isik.MaxLength = 11;
            this.isik.Name = "isik";
            this.isik.Size = new System.Drawing.Size(82, 20);
            this.isik.TabIndex = 3;
            this.isik.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_valid);
            // 
            // lname
            // 
            this.lname.Location = new System.Drawing.Point(117, 54);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(82, 20);
            this.lname.TabIndex = 4;
            this.lname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.let_valid);
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(117, 234);
            this.address.Multiline = true;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(82, 56);
            this.address.TabIndex = 8;
            // 
            // birthday
            // 
            this.birthday.Location = new System.Drawing.Point(117, 171);
            this.birthday.Name = "birthday";
            this.birthday.Size = new System.Drawing.Size(82, 20);
            this.birthday.TabIndex = 7;
            // 
            // nationality
            // 
            this.nationality.Location = new System.Drawing.Point(117, 142);
            this.nationality.Name = "nationality";
            this.nationality.Size = new System.Drawing.Size(82, 20);
            this.nationality.TabIndex = 6;
            this.nationality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.let_valid);
            // 
            // docnumber
            // 
            this.docnumber.Enabled = false;
            this.docnumber.Location = new System.Drawing.Point(117, 22);
            this.docnumber.Name = "docnumber";
            this.docnumber.Size = new System.Drawing.Size(82, 20);
            this.docnumber.TabIndex = 15;
            this.docnumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.an_valid);
            // 
            // pin
            // 
            this.pin.Location = new System.Drawing.Point(289, 83);
            this.pin.MaxLength = 5;
            this.pin.Name = "pin";
            this.pin.Size = new System.Drawing.Size(82, 20);
            this.pin.TabIndex = 12;
            this.pin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num_valid);
            // 
            // country
            // 
            this.country.Location = new System.Drawing.Point(289, 57);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(82, 20);
            this.country.TabIndex = 11;
            this.country.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.let_valid);
            // 
            // county
            // 
            this.county.Location = new System.Drawing.Point(289, 28);
            this.county.Name = "county";
            this.county.Size = new System.Drawing.Size(82, 20);
            this.county.TabIndex = 10;
            this.county.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.let_valid);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Sünniaeg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Kodakondsus";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Sugu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Isikukood";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Perenimi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Eesnimi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(222, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Maakond";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Riik";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(222, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Postiindeks";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 210);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Pilt";
            // 
            // dispense
            // 
            this.dispense.FormattingEnabled = true;
            this.dispense.Location = new System.Drawing.Point(26, 315);
            this.dispense.Name = "dispense";
            this.dispense.Size = new System.Drawing.Size(173, 21);
            this.dispense.TabIndex = 33;
            // 
            // issdate
            // 
            this.issdate.Enabled = false;
            this.issdate.Location = new System.Drawing.Point(117, 48);
            this.issdate.Name = "issdate";
            this.issdate.Size = new System.Drawing.Size(82, 20);
            this.issdate.TabIndex = 35;
            // 
            // expdate
            // 
            this.expdate.Enabled = false;
            this.expdate.Location = new System.Drawing.Point(117, 74);
            this.expdate.Name = "expdate";
            this.expdate.Size = new System.Drawing.Size(82, 20);
            this.expdate.TabIndex = 36;
            // 
            // prevdoc
            // 
            this.prevdoc.AutoSize = true;
            this.prevdoc.Location = new System.Drawing.Point(264, 113);
            this.prevdoc.Name = "prevdoc";
            this.prevdoc.Size = new System.Drawing.Size(155, 17);
            this.prevdoc.TabIndex = 37;
            this.prevdoc.Text = "Eelmine dokument olemas?";
            this.prevdoc.UseVisualStyleBackColor = true;
            this.prevdoc.CheckedChanged += new System.EventHandler(this.checkPrev);
            // 
            // gender
            // 
            this.gender.FormattingEnabled = true;
            this.gender.Location = new System.Drawing.Point(131, 109);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(68, 21);
            this.gender.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Kehtiv kuni";
            // 
            // representative
            // 
            this.representative.Location = new System.Drawing.Point(287, 296);
            this.representative.Multiline = true;
            this.representative.Name = "representative";
            this.representative.Size = new System.Drawing.Size(111, 42);
            this.representative.TabIndex = 41;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(26, 239);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(85, 56);
            this.textBox1.TabIndex = 43;
            this.textBox1.Text = "Aadress (tänav,maja,korter,linn või küla,vald)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Dokumendi väljastamine";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Dokumendi number";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "Välja antud";
            // 
            // docGrp
            // 
            this.docGrp.Controls.Add(this.label12);
            this.docGrp.Controls.Add(this.label14);
            this.docGrp.Controls.Add(this.docnumber);
            this.docGrp.Controls.Add(this.issdate);
            this.docGrp.Controls.Add(this.expdate);
            this.docGrp.Controls.Add(this.label1);
            this.docGrp.Location = new System.Drawing.Point(220, 136);
            this.docGrp.Name = "docGrp";
            this.docGrp.Size = new System.Drawing.Size(216, 100);
            this.docGrp.TabIndex = 49;
            this.docGrp.TabStop = false;
            this.docGrp.Text = "Eelmine ID";
            // 
            // idReqPush
            // 
            this.idReqPush.Controls.Add(this.textBox2);
            this.idReqPush.Controls.Add(this.label7);
            this.idReqPush.Controls.Add(this.docGrp);
            this.idReqPush.Controls.Add(this.fname);
            this.idReqPush.Controls.Add(this.isik);
            this.idReqPush.Controls.Add(this.label8);
            this.idReqPush.Controls.Add(this.lname);
            this.idReqPush.Controls.Add(this.textBox1);
            this.idReqPush.Controls.Add(this.nationality);
            this.idReqPush.Controls.Add(this.birthday);
            this.idReqPush.Controls.Add(this.representative);
            this.idReqPush.Controls.Add(this.address);
            this.idReqPush.Controls.Add(this.gender);
            this.idReqPush.Controls.Add(this.county);
            this.idReqPush.Controls.Add(this.prevdoc);
            this.idReqPush.Controls.Add(this.country);
            this.idReqPush.Controls.Add(this.addph);
            this.idReqPush.Controls.Add(this.pin);
            this.idReqPush.Controls.Add(this.dispense);
            this.idReqPush.Controls.Add(this.label2);
            this.idReqPush.Controls.Add(this.label3);
            this.idReqPush.Controls.Add(this.label15);
            this.idReqPush.Controls.Add(this.label4);
            this.idReqPush.Controls.Add(this.label9);
            this.idReqPush.Controls.Add(this.label5);
            this.idReqPush.Controls.Add(this.label10);
            this.idReqPush.Controls.Add(this.label6);
            this.idReqPush.Controls.Add(this.label11);
            this.idReqPush.Location = new System.Drawing.Point(12, 12);
            this.idReqPush.Name = "idReqPush";
            this.idReqPush.Size = new System.Drawing.Size(444, 359);
            this.idReqPush.TabIndex = 50;
            this.idReqPush.TabStop = false;
            this.idReqPush.Text = "ID Taotlus";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(264, 257);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(155, 33);
            this.textBox2.TabIndex = 50;
            this.textBox2.Text = "Taotleja esindaja nimi ja iskikukood: (võib tühjaks jääda)";
            // 
            // addph
            // 
            this.addph.Image = global::IDTaotlus.Properties.Resources.Camera_icon;
            this.addph.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addph.Location = new System.Drawing.Point(117, 205);
            this.addph.Name = "addph";
            this.addph.Size = new System.Drawing.Size(82, 23);
            this.addph.TabIndex = 34;
            this.addph.Text = "Sisesta pilt";
            this.addph.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addph.UseVisualStyleBackColor = true;
            this.addph.Click += new System.EventHandler(this.addPhoto);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::IDTaotlus.Properties.Resources.Accept_icon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(192, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 34);
            this.button1.TabIndex = 32;
            this.button1.Text = "Esita taotlust";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.pushReq);
            // 
            // Request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 415);
            this.Controls.Add(this.idReqPush);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Request";
            this.Text = "ID Taotlus";
            this.docGrp.ResumeLayout(false);
            this.docGrp.PerformLayout();
            this.idReqPush.ResumeLayout(false);
            this.idReqPush.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.TextBox isik;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.TextBox birthday;
        private System.Windows.Forms.TextBox nationality;
        private System.Windows.Forms.TextBox docnumber;
        private System.Windows.Forms.TextBox pin;
        private System.Windows.Forms.TextBox country;
        private System.Windows.Forms.TextBox county;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox dispense;
        private System.Windows.Forms.Button addph;
        private System.Windows.Forms.TextBox issdate;
        private System.Windows.Forms.TextBox expdate;
        private System.Windows.Forms.CheckBox prevdoc;
        private System.Windows.Forms.ComboBox gender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox representative;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox docGrp;
        private System.Windows.Forms.GroupBox idReqPush;
        private System.Windows.Forms.TextBox textBox2;
    }
}