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
    public partial class Pesquisa_Corretor : Form
    {
        public Pesquisa_Corretor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            corretor pesquisa = new corretor();
            if (textBox1.Text != "")
            {
                if (!pesquisa.ValidaNomeCliente(textBox1.Text))
                {
                    MessageBox.Show("Esse corretor não existe na base de dados");
                    textBox1.Text = "";


                }
                else
                {
                    richTextBox1.Text = "";

                    List<string> mostrar = new List<string>();

                    mostrar = pesquisa.PesquisaCorretor(textBox1.Text);

                    richTextBox1.AppendText("Código: " + mostrar[0] + "\nNome: " + mostrar[1] + "\nTelefone: " + mostrar[2] + "\nSalário: R$ " + mostrar[3]);
                    /*
                    for (int i = 0; i < mostrar.Count; i++)
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
                    */
                    textBox1.Text = "";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
