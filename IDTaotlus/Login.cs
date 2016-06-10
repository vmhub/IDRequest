using System;
using System.Windows.Forms;
using IDTaotlus.Helpers;

namespace IDTaotlus
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /*
         * Check whether uername/password is valid and whether the user has already submitted a request.
         * Kontrollib kas selline kasutajatunnus/salasõna on olemas ja kas kasutajal on juba taotlus esitatud.
         */

        private void login(object sender, EventArgs e)
        {
            if (Validators.validate(loginBox))
            {
                string userid;
                string isikukood = HelperMethods.checkCred(out userid, username.Text, password.Text);

                if (isikukood == null || userid == null)
                    MessageBox.Show("Vale kasutajanimi või salasõna!", "Teade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    string stateVal = HelperMethods.checkState(isikukood);
                    if (stateVal == null || stateVal.Equals("0"))
                    {
                        Request req = new Request(isikukood, userid);
                        req.FormClosed += (o, ev) => { this.Close();};
                        this.Hide();
                        req.Show();
                    }
                    else
                    {
                        IDRequest id = HelperMethods.fillObj(isikukood);
                        Output outp = new Output(id);
                        outp.FormClosed += (o, ev) => { this.Close();};
                        this.Hide();
                        outp.Show();
                    }

                }
            }
        }
        /*Validators.
         * Validaatorid.
         */
        private void an_valid(object sender, KeyPressEventArgs e)
        {
            Validators.alphaNum(e);
        }


    }
}
