using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonComponents
{
    /// <summary>
    /// Método(TextBox textBox)
    /// {
    ///     txt.Enter += AplyFloatCurrency.TirarMascara;
    ///     txt.Leave += AplyFloatCurrency.RetornarMarcarca;
    ///     txt.KeyPress += AplyFloatCurrency.AenpasValorNumerico;
    /// }
    /// 
    /// Chamar o esse método no método de inicialização do Form
    /// apontando par ao textbox que terá o valor currency
    ///InitializeComponent();
    ///    Método(textboxvalor);
    /// </summary>
    public static class AplyFloatCurrency
    {
        public static void RetornarMarcarca(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != string.Empty)
                if(!txt.Text.Contains("R$"))
                    txt.Text = double.Parse(txt.Text).ToString("C2");

        }

        public static void TirarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }

        public static void AenpasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else
                    e.Handled = true;

            }
        }
    }
}
