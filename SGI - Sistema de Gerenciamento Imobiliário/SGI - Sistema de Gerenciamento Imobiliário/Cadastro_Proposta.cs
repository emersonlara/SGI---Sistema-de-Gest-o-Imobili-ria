using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    public partial class Cadastro_Proposta : Form
    {
        public Cadastro_Proposta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            imovel imoveis = new imovel();

            List<string> mostrar = new List<string>();

            mostrar = imoveis.PesquisaImovel();

            for(int i = 0; i < mostrar.Count; i++)
            {
                if (i == 0)
                {
                    richTextBox1.AppendText(mostrar[i]);
                }
                else
                {
                    richTextBox1.AppendText("\n" + mostrar[i]);
                }
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            imovel imoveis = new imovel();
            try
            {
                string cod_imovel = textBox1.Text;

                string mensagem = imoveis.MudaStatusVendas(int.Parse(cod_imovel));

                MessageBox.Show(mensagem);
            }
            catch
            {
                MessageBox.Show("Digite o código do imovél para fazer a proposta");
            }
        }
    }
}
