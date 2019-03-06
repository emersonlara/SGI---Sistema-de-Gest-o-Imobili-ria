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
    public partial class Cadastro_Locacao : Form
    {
        Thread nova_thread;
        public Cadastro_Locacao()
        {
            InitializeComponent();
            locacao locacao = new locacao();
            string retorno = locacao.PesquisaCod();
            //MessageBox.Show(retorno);
            textBox1.Text = locacao.GeraCod(retorno);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Fecha o Form para voltar à tela anterior.
            Close();

            // Remover depois.
            /*this.Close();
            nova_thread = new Thread(retornaMenu);
            nova_thread.SetApartmentState(ApartmentState.STA);
            nova_thread.Start();*/
        }

        private void retornaMenu()
        {
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            locacao locacao = new locacao();
            imovel atualiza = new imovel();
            locacao.codigo = int.Parse(textBox1.Text);
            /*int next_codigo = int.Parse(textBox1.Text);
            ++next_codigo;
            textBox1.Text = Convert.ToString(next_codigo);*/
            try
            {
                locacao.codigo_imovel = int.Parse(textBox2.Text);
                locacao.codigo_cliente = int.Parse(textBox3.Text);
                locacao.nome_cliete = textBox4.Text;
                locacao.data = dateTimePicker1.Text;
                locacao.duracao = comboBox1.Text;
                locacao.valor = double.Parse(textBox5.Text);
                locacao.taxa = double.Parse(textBox6.Text);
                locacao.valor_proprietario = double.Parse(textBox7.Text);



                if (locacao.Pesquisa())
                {
                    int codigoImovel = int.Parse(textBox2.Text);
                    string mensagem = atualiza.MudaStatusLocacao(codigoImovel);
                    MessageBox.Show(mensagem);
                    if (mensagem != "Esse imóvel não está apto para ser alugado")
                    {


                        locacao.Escreve();
                        MessageBox.Show("Cadastro Realizado");
                        textBox1.Text = locacao.GeraCod(textBox1.Text);
                    }
                    //locacao.Escreve();
                    //MessageBox.Show("Cadastro Realizado");
                    /*int codigoImovel = int.Parse(textBox2.Text);
                    string mensagem = atualiza.MudaStatusLocacao(codigoImovel);
                    MessageBox.Show(mensagem);*/
                    //textBox1.Text = locacao.GeraCod(textBox1.Text);//Função que Gera o código do próximo proprietário
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    comboBox1.Text = "";
                    dateTimePicker1.Value = DateTime.Now.ToUniversalTime();
                }
                else
                {
                    MessageBox.Show("A locação já está cadastrada na base de dados");
                }
            }
            catch
            {
                MessageBox.Show("Todos os campos devem ser preenchidos para cadastrar uma nova locação");

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            imovel validaImovel = new imovel();

            if(textBox2.Text != "")
            {
                if (!validaImovel.ValidaCodImovel(textBox2.Text))
                {
                    MessageBox.Show("Esse imóvel não existe na base de dados, cadastre-o para fazer a locação");
                    textBox2.Text = "";
                }
            }

            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            cliente validaCliente = new cliente();

            if (textBox3.Text != "")
            {
                if (!validaCliente.ValidaCodCliente(textBox3.Text))
                {
                    MessageBox.Show("Esse cliente não existe na base de dados, cadastre-o para fazer a locação");
                    textBox3.Text = "";
                    textBox4.Text = "";
                    
                }
                else
                {
                    textBox4.Text = validaCliente.GeraNome(textBox3.Text);
                }
            }
            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "6 meses")
            {
                textBox6.Text = "15";
            }
            else if(comboBox1.Text == "1 ano")
            {
                textBox6.Text = "10";
            }
            else
            {
                textBox6.Text = "5";
            }

            if(textBox5.Text != "")
            {
                if (comboBox1.Text == "6 meses")
                {
                    double valor_final = double.Parse(textBox5.Text) * 0.85;
                    textBox7.Text = Convert.ToString(valor_final);
                }
                else if (comboBox1.Text == "1 ano")
                {
                    double valor_final = double.Parse(textBox5.Text) * 0.9;
                    textBox7.Text = Convert.ToString(valor_final);
                }
                else
                {
                    double valor_final = double.Parse(textBox5.Text) * 0.95;
                    textBox7.Text = Convert.ToString(valor_final);
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(textBox5.Text != "")
            {
                if (comboBox1.Text == "6 meses")
                {
                    double valor_final = double.Parse(textBox5.Text) * 0.85;
                    textBox7.Text = Convert.ToString(valor_final);
                }
                else if (comboBox1.Text == "1 ano")
                {
                    double valor_final = double.Parse(textBox5.Text) * 0.9;
                    textBox7.Text = Convert.ToString(valor_final);
                }
                else
                {
                    double valor_final = double.Parse(textBox5.Text) * 0.95;
                    textBox7.Text = Convert.ToString(valor_final);
                }
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
