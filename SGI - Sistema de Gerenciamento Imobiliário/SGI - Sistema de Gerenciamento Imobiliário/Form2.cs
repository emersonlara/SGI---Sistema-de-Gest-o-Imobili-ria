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
    public partial class Form2 : Form
    {
        Thread nova_thread;
        public Form2()
        {
            InitializeComponent();
            cliente cliente = new cliente();
            textBox1.Text = cliente.GeraCod(cliente.PesquisaCod());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            nova_thread = new Thread(returnaMenu);
            nova_thread.SetApartmentState(ApartmentState.STA);
            nova_thread.Start();
        }

        private void returnaMenu()
        {
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cliente cliente = new cliente();
            cliente.codigo = int.Parse(textBox1.Text);
            /*int next_codigo = int.Parse(textBox1.Text);
            ++next_codigo;
            textBox1.Text = Convert.ToString(next_codigo);*/

            cliente.nome = textBox2.Text;
            cliente.endereco = textBox3.Text;
            cliente.telefone = textBox4.Text;
            cliente.data_nascimento = dateTimePicker1.Text;

            if (cliente.nome == "" || cliente.endereco == "" || cliente.telefone == "")
            {
                MessageBox.Show("Preencha todos os campos para cadastrar um novo cliente");
            }
            else
            {

                if (cliente.Pesquisa())
                {
                    cliente.Escreve();
                    MessageBox.Show("Cadastro Realizado");
                    textBox1.Text = cliente.GeraCod(textBox1.Text);//Função que Gera o código do próximo proprietário
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    dateTimePicker1.Value = DateTime.Now.ToUniversalTime();
                }

                else
                {
                    MessageBox.Show("O cliente já está cadastrado na base de dados");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
