using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário.Utilitarios
{
    public class UtilitarioTextBox
    {
        public static bool SomenteNumeros(TextBox textBox)
        {
            if (Regex.IsMatch(textBox.Text, "[^0-9]"))
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                textBox.SelectionStart = textBox.Text.Length;

                return false;
            }

            return true;
        }

        public static bool SomenteValorMonetario(TextBox textBox)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox.Text)) return true;

                double.Parse(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                textBox.SelectionStart = textBox.Text.Length;

                return false;
            }
        }
    }
}
