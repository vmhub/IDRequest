using IDTaotlus.Helpers;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;
using System;
using System.Data.SQLite;

namespace IDTaotlus
{
    public partial class Output : Form
    {
        const string conStr = @"Data Source =fakeDB.sqlite;version=3;";
        private bool opened = false;
        private IDRequest idreq;
        private byte[] buffer;
        private MemoryStream ms = null;
        public Output(IDRequest re)
        {
            idreq = re;
            InitializeComponent();

        }
        /*
          * Prepares the form to be used.
          * Valmistab vormi kasutamiseks.
          */
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            if (idreq.reqId == 0)
            {
                idreq.reqId = Convert.ToUInt32(HelperMethods.getReqId(idreq));
            }
            if (idreq.prevDoc != null)
            {
                if (idreq.prevDoc.docid == 0)
                {
                    idreq.prevDoc.docid = Convert.ToUInt32(HelperMethods.getDocId(idreq));
                }
            }
            dispense.DataSource = new BindingSource(Dispense.POD, null);
            dispense.DisplayMember = "Key";
            dispense.ValueMember = "Value";
            dispense.DropDownStyle = ComboBoxStyle.DropDownList;
            gender.DataSource = new BindingSource(MFselect.MF, null);
            gender.DisplayMember = "Key";
            gender.ValueMember = "Value";
            gender.DropDownStyle = ComboBoxStyle.DropDownList;
            dispense.Width = HelperMethods.dropWidth(dispense);
            fill();

        }
        /*Picture redraw.
         * Pildi ümberjoonistamine.
         */
        private void redraw(byte[] photo)
        {
            if (photo != null)
            {
                if (ms == null)
                {
                    ms = new MemoryStream(photo);
                }
                else
                {
                    ms.Dispose();
                    ms = new MemoryStream(photo);
                }
                pictureBox1.Image = Image.FromStream(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Refresh();
            }
        }
        /*Fills the form with object data.
         * Täidab vormi objekti andmetega.
         */
        private void fill()
        {
            fname.Text = idreq.firstName;
            lname.Text = idreq.lastName;
            isik.Text = idreq.isikukood.ToString();
            gender.SelectedIndex = gender.FindStringExact(MFselect.MF.FirstOrDefault(x => x.Value == (idreq.gender)).Key);
            nationality.Text = idreq.nationality;
            county.Text = idreq.county;
            birthday.Text = idreq.bDay;
            country.Text = idreq.country;
            pin.Text = idreq.pin.ToString();
            address.Text = idreq.address;
            representative.Text = idreq.representative;
            dispense.SelectedIndex = dispense.FindStringExact(Dispense.POD.FirstOrDefault(x => x.Value == (idreq.delivery)).Key);
            redraw(idreq.photo);
            Documents doc = idreq.prevDoc;
            if (doc != null)
            {
                docnumber.Text = doc.docNumber;
                issdate.Text = doc.issDate;
                expdate.Text = doc.expDate;
            }
        }
        /*Gives the user ability to edit data.
         * Annab võimaluse andmeid muutma.
         */
        private void edit(object sender, EventArgs e)
        {
            enableCtrls(false);
            gender.Enabled = dispense.Enabled = true;
            opened = true;
        }
        /*Main method used by edit() to edit data.
         * Peamine meetod mida kasutab edit() andmete muutmiseks.
         */
        private void enableCtrls(bool b)
        {
            foreach (TextBox item in reqBox.Controls.OfType<TextBox>())
            {
                item.ReadOnly = b;
            }
            if (idreq.prevDoc != null)
            {
                foreach (TextBox item in idBox.Controls.OfType<TextBox>())
                {
                    item.ReadOnly = b;
                }
            }
        }

        /*Updates all records in IDREQUEST and DOCUMENTS tables.
         * Uuenab IDREQUEST ja DOCUMENTS andmeid .
         */
        private void update(object sender, EventArgs e)
        {
            if (opened)
            {
                bool validForm = false;
                validForm = docnumber.ReadOnly ? Validators.validate(reqBox) : (Validators.validate(idBox) && Validators.validate(reqBox));
                if (validForm)
                {
                    object docid = DBNull.Value;

                    fillObj();
                    using (SQLiteConnection con = new SQLiteConnection(conStr))
                    {
                        try
                        {
                            con.Open();
                        }
                        catch (Exception ec) { HelperMethods.Log(ec.ToString()); }

                        if (!docnumber.ReadOnly)
                        {
                            Documents doc = idreq.prevDoc;
                            docid = doc.docid.ToString();
                            using (SQLiteCommand cmd = new SQLiteCommand(@"update documents set isikukood = @isik, docnumber = @docnum,
                        expdate = @exp, issdate = @iss WHERE
                        docid = @docid", con))
                            {
                                try
                                {
                                    cmd.Parameters.AddWithValue("@exp", doc.expDate);
                                    cmd.Parameters.AddWithValue("@iss", doc.issDate);
                                    cmd.Parameters.AddWithValue("@docnum", doc.docNumber);
                                    cmd.Parameters.AddWithValue("@docid", docid);
                                    cmd.Parameters.AddWithValue("@isik", idreq.isikukood);
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex) { HelperMethods.Log(ex.ToString()); }
                            }
                        }
                        using (SQLiteCommand cmd = new SQLiteCommand(@"update idrequest set fname = @fname, lname = @lname, isikukood = @isik, gender = @gen,
                         nationality = @nat, bday = @bday, address = @addr, photo = @photo, prevdoc = @docid, county = @county, country = @country, pin = @pin, delivery = @deliv, representative = @reppie WHERE
                         reqid = @reqid", con))
                        {
                            try
                            {
                                cmd.Parameters.Add("@photo", System.Data.DbType.Binary, idreq.photo.Length);
                                cmd.Parameters["@photo"].Value = idreq.photo;
                                cmd.Parameters.AddWithValue("@reqid", idreq.reqId);
                                cmd.Parameters.AddWithValue("@isik", idreq.isikukood);
                                cmd.Parameters.AddWithValue("@fname", idreq.firstName);
                                cmd.Parameters.AddWithValue("@lname", idreq.lastName);
                                cmd.Parameters.AddWithValue("@gen", idreq.gender);
                                cmd.Parameters.AddWithValue("@nat", idreq.nationality);
                                cmd.Parameters.AddWithValue("@bday", idreq.bDay);
                                cmd.Parameters.AddWithValue("@addr", idreq.address);
                                cmd.Parameters.AddWithValue("@county", idreq.county);
                                cmd.Parameters.AddWithValue("@country", idreq.country);
                                cmd.Parameters.AddWithValue("@pin", idreq.pin);
                                cmd.Parameters.AddWithValue("@deliv", idreq.delivery);
                                cmd.Parameters.AddWithValue("@docid", docid);
                                cmd.Parameters.AddWithValue("@reppie", idreq.representative);
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex) { HelperMethods.Log(ex.ToString()); }
                        }
                    }
                    fill();
                    opened = false;
                    enableCtrls(true);
                    gender.Enabled = dispense.Enabled = false;
                }
            }
            else MessageBox.Show("Palun redigeerige andmeid", "Teade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /*Fills the object with form data.
         * Täidab objekti vormi andmetega.
         */
        private void fillObj()
        {
            idreq.photo = buffer == null ? idreq.photo : buffer;
            idreq.firstName = fname.Text;
            idreq.lastName = lname.Text;
            idreq.isikukood = Convert.ToUInt32(isik.Text);
            idreq.gender = (byte)gender.SelectedValue;
            idreq.nationality = nationality.Text;
            idreq.county = county.Text;
            idreq.bDay = birthday.Text;
            idreq.country = country.Text;
            idreq.pin = Convert.ToUInt16(pin.Text);
            idreq.address = address.Text;
            idreq.representative = representative.Text;
            idreq.delivery = (UInt16)dispense.SelectedValue;
            if (idreq.prevDoc != null)
            {
                idreq.prevDoc.docNumber = docnumber.Text;
                idreq.prevDoc.issDate = issdate.Text;
                idreq.prevDoc.expDate = expdate.Text;
            }
        }
        /*Allows the user to add a photo.
     * Annab kasutajale võimaluse sisestada pilti.
     */
        private void addPhoto(object sender, EventArgs e)
        {
            opened = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.gif, *.jpg)|*.gif;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                }
            }
            redraw(buffer);
        }
        /*Validators.
        * Validaatorid.
        */
        private void num_valid(object sender, KeyPressEventArgs e)
        {
            Validators.onlyNum(e);
        }

        private void an_valid(object sender, KeyPressEventArgs e)
        {
            Validators.alphaNum(e);
        }

        private void let_valid(object sender, KeyPressEventArgs e)
        {
            Validators.onlyLetter(e);
        }

    }
}
