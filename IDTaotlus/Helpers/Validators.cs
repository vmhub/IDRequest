using System.Linq;
using System.Windows.Forms;

namespace IDTaotlus.Helpers
{
    static class Validators
    {
        /* Doesn't allow to insert anything but alphanumeric characters.
         * Ei anna sisestada midagi peale numbreid ja tähte.
         */
        public static void alphaNum(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /* Doesn't allow to insert anything but numbers.
         * Ei anna sisestada midagi peale numbreid.
         */
        public static void onlyNum(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /* Doesn't allow to insert anything but letters.
         * Ei anna sisestada midagi peale tähte.
         */
        public static void onlyLetter(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       /*Checks if textbox is empty.
        * Kontrollib kas textbox on tühi.
        */ 
        public static bool validate(GroupBox gb)
        {
            foreach (TextBox tb in gb.Controls.OfType<TextBox>().Where(x => x.Enabled == true && x.Text.Trim().Length == 0 && !x.Name.Equals("representative"))) 
            {
                MessageBox.Show(tb.Name + " ei saa olla tühi!", "Teade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                return false;
            }
            
            return true;
        }


    }
}
