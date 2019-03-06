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
    public partial class Pesquisa_Data_Locacao : Form
    {
        public Pesquisa_Data_Locacao()
        {
            InitializeComponent();
        }

        private void Pesquisa_Data_Locacao_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            locacao pesquisa_locacao = new locacao();
            string data_pesquisa = dateTimePicker1.Text;
            List<string> pesquisa = new List<string>();
            pesquisa = pesquisa_locacao.RetornaLocacaoporData(data_pesquisa);

            if (pesquisa.Count == 0)
            {
                richTextBox1.AppendText("Não possui nenhuma venda nesta data!");
            }
            for (int i = 0; i < pesquisa.Count; i++)
            {
                richTextBox1.AppendText(pesquisa[i] + "\n\n");
            }
        }
    }
}
