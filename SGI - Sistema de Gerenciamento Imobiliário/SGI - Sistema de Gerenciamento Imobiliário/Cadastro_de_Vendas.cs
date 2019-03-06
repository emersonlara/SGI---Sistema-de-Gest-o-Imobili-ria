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
    public partial class Cadastro_de_Vendas : Form
    {
        public Cadastro_de_Vendas()
        {
            InitializeComponent();
            venda vendas = new venda();
            string retorno = vendas.PesquisaCod();
        
            textBox1.Text = vendas.GeraCod(retorno);
        }

        private void Cadastro_de_Vendas_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            venda vendas = new venda();
            imovel atualiza = new imovel();
            vendas.cod_venda = int.Parse(textBox1.Text);
            /*int next_codigo = int.Parse(textBox1.Text);
            ++next_codigo;
            textBox1.Text = Convert.ToString(next_codigo);*/
            try
            {
                vendas.cod_imovel = int.Parse(textBox2.Text);
                vendas.cod_cliente = int.Parse(textBox3.Text);
                vendas.cod_corretor = int.Parse(textBox4.Text);
                vendas.valor_venda = double.Parse(textBox6.Text);
                vendas.taxa_administrativa = double.Parse(textBox7.Text);
                vendas.valor_proprietario = double.Parse(textBox8.Text);
                vendas.data = dateTimePicker1.Text;


                if (vendas.Pesquisa())
                {
                    vendas.Escreve();
                    MessageBox.Show("Venda Realizada");
                    int codigoImovel = int.Parse(textBox2.Text);
                    string mensagem = atualiza.MudaStatusVendasCompleta(codigoImovel);
                    MessageBox.Show(mensagem);
                    textBox1.Text = vendas.GeraCod(textBox1.Text);//Função que Gera o código do próximo proprietário
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";

                    dateTimePicker1.Value = DateTime.Now.ToUniversalTime();
                }
                else
                {
                    MessageBox.Show("A locação já está cadastrada na base de dados");
                }
            }
            catch
            {
                MessageBox.Show("Preencha todos os campos para efetuar a venda!");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cliente validaCliente = new cliente();

            if (textBox5.Text != "")
            {
                if (!validaCliente.ValidaNomeCliente(textBox5.Text))
                {
                    MessageBox.Show("Esse cliente não existe na base de dados, cadastre-o para fazer a venda");
                    textBox3.Text = "";
                    textBox5.Text = "";

                }
                else
                {
                    textBox3.Text = validaCliente.GeraCodVenda(textBox5.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imovel validaImovel = new imovel();

            if (textBox2.Text != "")
            {
                if (!validaImovel.ValidaNomeImovel(textBox2.Text))
                {
                    MessageBox.Show("Esse imovel não existe na base de dados, cadastre-o para fazer a venda");
                    textBox2.Text = "";
                    //textBox5.Text = "";

                }
                else
                {
                    textBox6.Text = validaImovel.GeraValoresVenda(textBox2.Text);
                    double valor = double.Parse(textBox6.Text);
                    double taxa = valor * 0.15;
                    textBox7.Text = Convert.ToString(taxa);
                    double proprietario = valor - taxa;
                    textBox8.Text = Convert.ToString(proprietario);
                }
            }
        }
    }
}
