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
    public partial class Pesquisa_Data_Venda : Form
    {
        public Pesquisa_Data_Venda()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            venda pesquisa_venda = new venda();
            string data_pesquisa = dateTimePicker1.Text;
            List<string> pesquisa = new List<string>();
            pesquisa = pesquisa_venda.RetornaVendasporData(data_pesquisa);

            if(pesquisa.Count == 0)
            {
                richTextBox1.AppendText("Não possui nenhuma venda nesta data!");
            }
            for(int i = 0; i < pesquisa.Count; i++)
            {
                richTextBox1.AppendText(pesquisa[i] + "\n\n");
            }

            

        }
    }
}
