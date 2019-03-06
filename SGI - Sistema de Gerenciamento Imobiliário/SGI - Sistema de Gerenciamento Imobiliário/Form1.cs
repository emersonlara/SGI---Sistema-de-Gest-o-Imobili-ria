using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; // O programa chama um novo ambiente(Threading)

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    public partial class Form1 : Form
    {
        Thread nova_thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            nova_thread = new Thread(novoForm);// Estância o objeto Thread que irá chamar o método novoForm
            nova_thread.SetApartmentState(ApartmentState.STA);//Forma de abertura da Thread
            nova_thread.Start();//Inicializa a Thread
        }

        private void novoForm()
        {
            Application.Run(new Cadastro_Proprietario()); //Cria uma nova aplicação e estância o objeto Cadastro_Proprietário
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            nova_thread = new Thread(cadastroCliente);
            nova_thread.SetApartmentState(ApartmentState.STA);
            nova_thread.Start();
        }

        private void cadastroCliente()
        {
            Application.Run(new Form2());//Cadastra Cliente
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            nova_thread = new Thread(cadastroCorretor);
            nova_thread.SetApartmentState(ApartmentState.STA);
            nova_thread.Start();
        }

        private void cadastroCorretor()
        {
            Application.Run(new Cadastro_Corretor());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            nova_thread = new Thread(cadastroImovel);
            nova_thread.SetApartmentState(ApartmentState.STA);
            nova_thread.Start();
        }

        private void cadastroImovel()
        {
            Application.Run(new Cadastro_Imovel());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Abre um novo Form de cadastro de locação.
            using (Cadastro_Locacao cadastroLocacao = new Cadastro_Locacao())
            {
                cadastroLocacao.ShowDialog();
            }

            // Remover
            /*this.Close();
            nova_thread = new Thread(cadastroLocacao);
            nova_thread.SetApartmentState(ApartmentState.STA);
            nova_thread.Start();*/
        }

        private void cadastroLocacao()
        {
            Application.Run(new Cadastro_Locacao());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (Cadastro_de_Vendas cadastroVendas = new Cadastro_de_Vendas())
            {
                cadastroVendas.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (Cadastro_Proposta cadastroProposta = new Cadastro_Proposta())
            {
                cadastroProposta.ShowDialog();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (Pesquisa_Cliente pesquisa_cliente = new Pesquisa_Cliente())
            {
                pesquisa_cliente.ShowDialog();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (Pesquisa_Proprietario pesquisa_proprietario = new Pesquisa_Proprietario())
            {
                pesquisa_proprietario.ShowDialog();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (Pesquisa_Corretor pesquisa_corretor = new Pesquisa_Corretor())
            {
                pesquisa_corretor.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (Pesquisa_Venda_Corretor pesquisa_venda_corretor = new Pesquisa_Venda_Corretor())
            {
                pesquisa_venda_corretor.ShowDialog();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            using (Pesquisa_Data_Venda pesquisa_data_venda = new Pesquisa_Data_Venda())
            {
                pesquisa_data_venda.ShowDialog();
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            using (Pesquisa_Data_Locacao pesquisa_data_locacao = new Pesquisa_Data_Locacao())
            {
                pesquisa_data_locacao.ShowDialog();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
