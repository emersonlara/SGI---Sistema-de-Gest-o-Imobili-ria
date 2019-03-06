using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    public partial class Pesquisa_Venda_Corretor : Form
    {
        public Pesquisa_Venda_Corretor()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            venda pesquisa = new venda();
            if (textBox1.Text != "")
            {
                if (!pesquisa.ValidaVendaCorretor(textBox1.Text))
                {
                    MessageBox.Show("Esse cliente não existe na base de dados");
                    textBox1.Text = "";


                }
                else
                {

                    using (StreamReader ler = new StreamReader("vendas.txt", true))
                    {
                        List<string> texto = new List<string>();
                        while (!ler.EndOfStream)
                        {
                            string linha = ler.ReadLine();

                            string[] campos = linha.Split('|');

                            if (textBox1.Text == campos[3])
                            {
                                for(int i = 0; i < campos.Length; i++)
                                {
                                    texto.Add(campos[i] + "|");
                                }
                                
                            }
                        }

                        for(int i = 0; i < texto.Count; i++)
                        {
                            richTextBox1.AppendText(texto[i]);
                        }


                    }

                    /*List<string> mostrar = new List<string>();

                    mostrar = pesquisa.PesquisaVendaCorretor(textBox1.Text);

                    //richTextBox1.AppendText("Código: " + mostrar[0] + "\nNome: " + mostrar[1] + "\nTelefone: " + mostrar[2] + "\nSalário: R$ " + mostrar[3]);
                    
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
                    
                    textBox1.Text = "";
                }
            }*/

            corretor corretores = new corretor();

            int cod_corretor = corretores.RetornaCodigo(textBox1.Text);

            if(cod_corretor == -1)
            {
                MessageBox.Show("Esse corretor não está cadastrado na base de dados");
                textBox1.Text = "";
            }
            else{
                richTextBox1.Text = "";
                venda vendas = new venda();

                List<string> pesquisa = new List<string>();
                pesquisa = vendas.RetornaVendas(cod_corretor);

                if(pesquisa.Count == 0)
                {
                    richTextBox1.AppendText("Esse corretor não possui nenhuma venda cadastrada");
                }
                for (int i = 0; i < pesquisa.Count; i++)
                {
                    richTextBox1.AppendText(pesquisa[i] + "\n\n\n");
                    richTextBox1.Enabled = true;
                } 
            }
        }
    }
}
