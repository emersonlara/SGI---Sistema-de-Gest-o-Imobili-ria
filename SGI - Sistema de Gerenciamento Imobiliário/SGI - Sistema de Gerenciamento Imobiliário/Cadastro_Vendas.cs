using SGI___Sistema_de_Gerenciamento_Imobiliário.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    public partial class Cadastro_Vendas : Form
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Cadastro_Vendas
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Cadastro_Vendas";
            this.Load += new System.EventHandler(this.Cadastro_Vendas_Load);
            this.ResumeLayout(false);

        }

        private void Cadastro_Vendas_Load(object sender, EventArgs e)
        {

        }
        /*
public Cadastro_Vendas()
{
InitializeComponent();
}

private void button2_Click(object sender, EventArgs e)
{
var vendas = venda.retornar_todas();
LimparCampos();
textBox1.Text = Convert.ToString(vendas.Count + 1);
}

private void button3_Click(object sender, EventArgs e)
{
try
{
ValidarCampos();

venda novaVenda = new venda();
novaVenda.codigo = int.Parse(textBox1.Text);
novaVenda.valor = decimal.Parse(textBox2.Text);

if (string.IsNullOrWhiteSpace(textBox3.Text))
  novaVenda.data_venda = null;
else
  novaVenda.data_venda = DateTime.Parse(textBox3.Text);

venda.salvar(novaVenda);

LimparCampos();

MessageBox.Show("Alterações salvas com sucesso.", "Alterações salvas");
}
catch (ArgumentException ex)
{
MessageBox.Show(null, ex.Message, "Verificar Campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
}

private void LimparCampos()
{
textBox1.Text = string.Empty;
textBox2.Text = string.Empty;
textBox3.Text = string.Empty;
}

private void ValidarCampos()
{
if (string.IsNullOrWhiteSpace(textBox1.Text))
throw new ArgumentException("O código da venda não pode ser vazio.");

if (string.IsNullOrWhiteSpace(textBox2.Text))
throw new ArgumentException("O valor da venda não pode ser vazio.");

if (!string.IsNullOrWhiteSpace(textBox3.Text) && !Regex.IsMatch(textBox3.Text, "[0-9]{2}/[0-9]{2}/[0-9]{4}"))
throw new ArgumentException("A data está em um formato inválido");
}

private void textBox2_TextChanged(object sender, EventArgs e)
{
UtilitarioTextBox.SomenteValorMonetario(textBox2);
}

private void textBox1_TextChanged(object sender, EventArgs e)
{
UtilitarioTextBox.SomenteNumeros(textBox1);
}

private void button1_Click(object sender, EventArgs e)
{
if (string.IsNullOrWhiteSpace(textBox1.Text))
return;

venda vendaSelecionada = venda.retornar_por_codigo(
int.Parse(textBox1.Text));

LimparCampos();

if (vendaSelecionada == null)
{
MessageBox.Show(null, "Venda não encontrada.", "Venda não encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
return;
}

textBox1.Text = vendaSelecionada.codigo.ToString();

textBox2.Text = vendaSelecionada.valor.ToString();

if (vendaSelecionada.data_venda != null)
textBox3.Text = vendaSelecionada.data_venda.Value.ToString("dd/MM/yyyy");
}
*/
    }
}
