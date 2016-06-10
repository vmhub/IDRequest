using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using IDTaotlus.Helpers;
using System.Linq;
namespace IDTaotlus
{
    public partial class Request : Form
    {
        const string conStr = @"Data Source =fakeDB.sqlite;version=3;";
        readonly string isikukood;
        readonly string id;
        private byte[] buffer;
        public Request(string isik, string userid)
        {
            id = userid;
            isikukood = isik;
            InitializeComponent();

        }
        /*Gets possible user data from CITIZENS table based on identity number.
         * Võtab isikuga seotud andmeid CITIZENS table kasutades isikukoodi.
         */
        public void getCred()
        {
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand("select * from citizens where isikukood = @isik", con))
                {
                    try
                    {
                        con.Open();
                    }
                    catch (Exception ex) { HelperMethods.Log(ex.ToString()); }
                    try
                    {
                        cmd.Parameters.AddWithValue("@isik", isikukood);
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (dr.HasRows)
                                {
                                    fname.Text = dr["fname"].ToString();
                                    lname.Text = dr["lname"].ToString();
                                    gender.SelectedIndex = gender.FindStringExact(MFselect.MF.FirstOrDefault(x => x.Value == Convert.ToByte(dr["gender"])).Key);
                                    nationality.Text = dr["nationality"].ToString();
                                    isik.Text = dr["isikukood"].ToString();
                                    birthday.Text = dr["bday"].ToString();
                                    address.Text = dr["address"].ToString();         
                                    county.Text = dr["county"].ToString();
                                    country.Text = dr["country"].ToString();
                                    pin.Text = dr["pin"].ToString();
                                }
                            }
                        }

                    }
                    catch (Exception ec) { HelperMethods.Log(ec.ToString()); }
                }
            }
        }
        /*
         * Prepares the form to be used.
         * Valmistab vormi kasutamiseks.
         */ 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dispense.DataSource = new BindingSource(Dispense.POD, null);
            dispense.DisplayMember = "Key";
            dispense.ValueMember = "Value";
            dispense.DropDownStyle = ComboBoxStyle.DropDownList;
            gender.DataSource = new BindingSource(MFselect.MF, null);
            gender.DisplayMember = "Key";
            gender.ValueMember = "Value";
            gender.DropDownStyle = ComboBoxStyle.DropDownList;
            dispense.Width = HelperMethods.dropWidth(dispense);
            getCred();
        }
        /*Allows the user to add a photo.
        * Annab kasutajale võimaluse sisestada pilti.
        */ 
        private void addPhoto(object sender, EventArgs e)
        {
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

        }
        /*Allows the user to input previous document data.
         * Annab kasutajale võimaluse sisestada eelmise dokumendi andmed.
         */ 
        private void checkPrev(object sender, EventArgs e)
        { 
            if (prevdoc.Checked)
                docnumber.Enabled = issdate.Enabled = expdate.Enabled = true;
            else
            {
                docnumber.Enabled = issdate.Enabled = expdate.Enabled = false;
                docnumber.Text = issdate.Text = expdate.Text = "";
            }
        }
        /*Validates the form and maps the data to objects.
         * Kontrollib kas andmed olid korrektselt sisestatud ja täidab objekte andmetega.
         */
        private void pushReq(object sender, EventArgs e)
        {
            bool validForm=false;
            IDRequest idReq = null;
            validForm = prevdoc.Checked ? (Validators.validate(idReqPush) && Validators.validate(docGrp)) : Validators.validate(idReqPush);

            if (validForm)
            {
                if (buffer != null)
                {
                    idReq = new IDRequest
                    {
                        owner = Convert.ToUInt32(id),
                        firstName = fname.Text,
                        lastName = lname.Text,
                        isikukood = Convert.ToUInt32(isik.Text),
                        gender = (byte)gender.SelectedValue,
                        nationality = nationality.Text,
                        bDay = birthday.Text,
                        photo = buffer,
                        representative = representative.Text,
                        address = address.Text,
                        country = country.Text,
                        county = county.Text,
                        pin = Convert.ToUInt32(pin.Text),
                        delivery = (UInt16)dispense.SelectedValue,
                        reqState = Byte.Parse("1"),
                        prevDoc = null
                    };
                    if (prevdoc.Checked)
                    {
                        Documents docs = new Documents
                        {
                            isikukood = Convert.ToUInt32(this.isikukood),
                            docNumber = docnumber.Text,
                            expDate = expdate.Text,
                            issDate = issdate.Text
                        };
                        HelperMethods.insertDoc(docs);
                        idReq.prevDoc = docs;
                        HelperMethods.insertReq(idReq);
                    }
                    else HelperMethods.insertIdReq(idReq, DBNull.Value);
                }
                else
                {
                    MessageBox.Show("Sisesta pilt!", "Teade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Output outp = new Output(idReq);
                outp.FormClosed += (o, ev) => { this.Close();};
                this.Hide();
                outp.Show();
            }
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
