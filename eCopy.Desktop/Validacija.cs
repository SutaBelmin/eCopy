using System.Windows.Forms;

namespace eCopy.Desktop
{
    public class Validacija
    {
        public const string porObaveznaVrijednost = "Obavezna vrijednost!";

        public static bool ObaveznoPolje(Control control, ErrorProvider err, string poruka)
        {
            bool validno = true;

            if (control is TextBox && string.IsNullOrEmpty((control as TextBox).Text))
                validno = false;

            else if (control is ComboBox && (control as ComboBox).SelectedIndex == -1)
                validno = false;

            else if (control is PictureBox && (control as PictureBox).Image == null)
                validno = false;


            if (!validno)
            {
                err.SetError(control, poruka);
                return false;
            }

            err.Clear();
            return true;
        }

        public static bool JednakoPolje(Control control, Control control2, ErrorProvider err, string poruka)
        {
            bool validno = true;

            if (control is TextBox && control2 is TextBox 
                && (string.IsNullOrEmpty((control as TextBox).Text)
                || string.IsNullOrEmpty((control2 as TextBox).Text)))
                validno = false;

            else if((control as TextBox).Text != (control2 as TextBox).Text)
                validno = false;


            if (!validno)
            {
                err.SetError(control, poruka);
                return false;
            }

            err.Clear();
            return true;
        }
    }
}
