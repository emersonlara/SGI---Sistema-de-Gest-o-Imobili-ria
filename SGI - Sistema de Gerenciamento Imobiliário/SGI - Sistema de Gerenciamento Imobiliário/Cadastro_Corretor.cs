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
    public partial class Cadastro_Corretor : Form
    {
        Thread nova_thread;
        public Cadastro_Corretor()
        {
            InitializeComponent();
            corretor corretor = new corretor();
            textBox1.Text = corretor.GeraCod(corretor.PesquisaCod());
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

        private void button1_Click(object sender, EventArgs e)
        {
            corretor corretor = new corretor();
            corretor.codigo = int.Parse(textBox1.Text);
            /*int next_codigo = int.Parse(textBox1.Text);
            ++next_codigo;
            textBox1.Text = Convert.ToString(next_codigo);*/

            corretor.nome = textBox2.Text;
            corretor.telefone = textBox3.Text;
            corretor.salario = double.Parse(textBox4.Text);

            if (corretor.Pesquisa())
            {
                corretor.Escreve();
                MessageBox.Show("Cadastro Realizado");
                textBox1.Text = corretor.GeraCod(textBox1.Text);//Função que Gera o código do próximo proprietário
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("O corretor já está cadastrado na base de dados");
            }
        }
    }
}
