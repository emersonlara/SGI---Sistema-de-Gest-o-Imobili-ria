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
    public partial class Pesquisa_Cliente : Form
    {
        public Pesquisa_Cliente()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cliente pesquisa = new cliente();
            if (textBox1.Text != "")
            {
                if (!pesquisa.ValidaNomeCliente(textBox1.Text))
                {
                    MessageBox.Show("Esse cliente não existe na base de dados");
                    textBox1.Text = "";
                    

                }
                else
                {
                    richTextBox1.Text = "";

                    List<string> mostrar = new List<string>();

                    mostrar = pesquisa.PesquisaCliente(textBox1.Text);

                    richTextBox1.AppendText("Código: " + mostrar[0] + "\nNome: " + mostrar[1] + "\nEndereço: " + mostrar[2] + "\nTelefone: " + mostrar[3] + "\nData de Nascimento: " + mostrar[4]);
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
                }
            }
        }
    }
}
