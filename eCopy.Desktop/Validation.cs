using System.ComponentModel;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace eCopy.Desktop
{
    public class Validation
    {

        public static bool requiredField(Control control, ErrorProvider err, string poruka)
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

        public static bool equalFields(Control control, Control control2, ErrorProvider err, string poruka)
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
                err.SetError(control2, poruka);
                return false;
            }

            err.Clear();
            return true;
        }

        public static bool UsernameValidation(Control control, ErrorProvider err)
        {
            string usernamePatern = @"^[a-zA-Z0-9]{4,}$";
            string usernameInput = (control as TextBox).Text.Trim();

            if (control is TextBox && string.IsNullOrEmpty((control as TextBox).Text))
            {
                err.SetError(control, "Enter some text");
                return false;
            }
            else if ((control as TextBox).Text.Length > 0 && usernameInput.Length != 0)
            {
                if (!Regex.IsMatch(usernameInput, usernamePatern))
                {
                    err.SetError(control, "Username must have a minimum length of 4 characters \nand can only contain letters and numbers.");
                    return false;
                }
            }

            err.Clear();
            return true;
        }

        public static bool EmailValidation(Control control, ErrorProvider err)
        {

            string emailPatern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string emailInput = (control as TextBox).Text.Trim();

            if (control is TextBox && string.IsNullOrEmpty((control as TextBox).Text))
            {
                err.SetError(control, "Enter some text");
                return false;
            }
            else if ((control as TextBox).Text.Length > 0 && emailInput.Length != 0)
            {
                if(!Regex.IsMatch(emailInput, emailPatern))
                {
                    err.SetError(control, "Invalid email");
                    return false;
                }
            }

            err.Clear();
            return true;
        }

        public static bool PhoneValidation(Control control, ErrorProvider err)
        {
            
            string phonePatern = @"^06\d{1}([-/ ])?\d{3}([- ])?\d{3,4}$";

            string phoneInput = (control as TextBox).Text.Trim();

            if (control is TextBox && string.IsNullOrEmpty((control as TextBox).Text))
            {
                err.SetError(control, "Enter some text");
                return false;
            }
            else if ((control as TextBox).Text.Length > 0 && phoneInput.Length != 0)
            {
                if (!Regex.IsMatch(phoneInput, phonePatern))
                {
                    err.SetError(control, "Invalid phone number!" +
                    "\n Please enter a valid Bosnian mobile phone number in one of the following formats:"+
                    "\n 06X/XXX-XXX or 06X/XXX-XXXX"+
                    "\n 06X XXX XXX or 06X XXX XXXX"+
                    "\n 06X-XXX-XXX or 06X-XXX-XXXX");

                    return false;
                }
            }

            err.Clear();
            return true;
        }

        public static bool PasswordValidation(Control control, ErrorProvider err)
        {
            string passwordPatern = @"^(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{8,}$";
            string passwordInput = (control as TextBox).Text.Trim();

            if (control is TextBox && string.IsNullOrEmpty((control as TextBox).Text))
            {
                err.SetError(control, "Enter some text");
                return false;
            }
            else if ((control as TextBox).Text.Length > 0 && passwordInput.Length != 0)
            {
                if (!Regex.IsMatch(passwordInput, passwordPatern))
                {
                    err.SetError(control, "Password must contain:\n" +
                       "At least one digit (0-9)\n" +
                       "At least one special character from !@#$%^&*\n" +
                       "At least one lowercase letter (a-z)\n" +
                       "At least one uppercase letter (A-Z)\n" +
                       "Minimum length of 8 characters");

                    return false;
                }
            }

            err.Clear();
            return true;
        }
    }
}
