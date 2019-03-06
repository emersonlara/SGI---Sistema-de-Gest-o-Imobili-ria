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
    public partial class Cadastro_Imovel : Form
    {
        Thread nova_thread;
        public Cadastro_Imovel()
        {
            InitializeComponent();
            imovel imovel = new imovel();
            //textBox1.Text = imovel.GeraCod(imovel.PesquisaCod());
            textBox1.Text = imovel.GeraCod(imovel.PesquisaCod());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            imovel imovel = new imovel();
            try
            {
                if (imovel.ValidaProprietario(textBox2.Text))
                {
                    imovel.codigo_proprietario = int.Parse(textBox2.Text);
                    imovel.codigo = int.Parse(textBox1.Text);
                    imovel.endereco = textBox3.Text;
                    imovel.categoria = textBox4.Text;
                    imovel.tipo = comboBox1.Text;
                    imovel.quantidade_quartos = Convert.ToInt16(numericUpDown1.Value);//Int de 16 bit
                    imovel.quantidade_vagas = Convert.ToInt16(numericUpDown2.Value);
                    imovel.valor = double.Parse(textBox5.Text);
                    imovel.condominio = double.Parse(textBox6.Text);
                    imovel.status = comboBox2.Text;
                    imovel.observacoes = textBox7.Text;

                    if (imovel.Pesquisa())
                    {
                        imovel.Escreve();
                        MessageBox.Show("Cadastro Realizado");
                        textBox1.Text = imovel.GeraCod(textBox1.Text);//Função que Gera o código do próximo proprietário
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        numericUpDown1.Value = 0;
                        numericUpDown2.Value = 0;
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("O corretor já está cadastrado na base de dados");
                    }
                }
                else
                {
                    MessageBox.Show("Esse proprietário não está cadastrado na base de dados, faça o cadastro para continuar");
                }
            }
            catch
            {
                MessageBox.Show("Preencha todos os campos para cadastrar um imóvel");
            }

            //Chamar método que verifica se esse proprietário existe na base de dados
            
        }

        private void Cadastro_Imovel_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            nova_thread = new Thread(cadastraProprietario);
            nova_thread.SetApartmentState(ApartmentState.STA);
            nova_thread.Start();

        }

        private void cadastraProprietario()
        {
            Application.Run(new Cadastro_Proprietario());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Venda")
            {
                comboBox2.Text = "a vender";
            }
            else
            {
                comboBox2.Text = "a alugar";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
