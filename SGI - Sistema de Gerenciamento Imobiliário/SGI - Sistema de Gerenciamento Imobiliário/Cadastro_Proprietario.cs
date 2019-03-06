using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    public partial class Cadastro_Proprietario : Form
    {
        Thread nova_thread;
        public Cadastro_Proprietario()
        {
            InitializeComponent();
            proprietario proprietario = new proprietario();
            textBox1.Text = proprietario.GeraCod(proprietario.PesquisaCod());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            proprietario proprietario = new proprietario();
            proprietario.codigo = int.Parse(textBox1.Text);
            /*int next_codigo = int.Parse(textBox1.Text);
            ++next_codigo;
            textBox1.Text = Convert.ToString(next_codigo);*/
            
            proprietario.nome = textBox2.Text;
            proprietario.endereco = textBox3.Text;
            proprietario.telefone = textBox4.Text;

            if (proprietario.nome == "" || proprietario.endereco == "" || proprietario.telefone == "")
            {
                MessageBox.Show("Preencha todos os campos para ser realizado o cadastro");
            }
            else
            {

                if (proprietario.Pesquisa())
                {
                    proprietario.Escreve();
                    MessageBox.Show("Cadastro Realizado");
                    textBox1.Text = proprietario.GeraCod(textBox1.Text);//Função que Gera o código do próximo proprietário
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("O proprietário já está cadastrado na base de dados");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            nova_thread = new Thread(retornaMenu);
            nova_thread.SetApartmentState(ApartmentState.STA);
            nova_thread.Start();
        }

        private void retornaMenu()
        {
            Application.Run(new Form1());
        }
    }
}
