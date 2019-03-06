using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    public class venda
    {
        /*
        #region Constantes
        public const int INDICE_ATRIBUTO_CODIGO = 0;
        public const int INDICE_ATRIBUTO_DATA_VENDA = 1;
        public const int INDICE_ATRIBUTO_VALOR = 2;

        private const char SEPARADOR = '|';
        private const string BASE_DADOS_VENDAS = "vendas.txt";

        #endregion

        public int codigo { get; set; }
        public decimal valor { get; set; }
        public DateTime? data_venda { get; set; }

        public venda()
        {

        }

        public venda(string registro)
        {
            string[] atributos = registro.Split(SEPARADOR);

            codigo = int.Parse(atributos[INDICE_ATRIBUTO_CODIGO]);

            valor = decimal.Parse(atributos[INDICE_ATRIBUTO_VALOR]);

            if (string.IsNullOrEmpty(atributos[INDICE_ATRIBUTO_DATA_VENDA]))
                data_venda = null;
            else
                data_venda = DateTime.Parse(atributos[INDICE_ATRIBUTO_DATA_VENDA]);
        }

        public static List<venda> retornar_todas()
        {
            List<string> registros = File.ReadLines(BASE_DADOS_VENDAS).ToList();
            List<venda> vendas = new List<venda>();

            foreach (var registro in registros)
            {
                vendas.Add(
                    new venda(registro));
            }

            return vendas;
        }

        public static venda retornar_por_codigo(int codigo)
        {
            List<venda> vendas = retornar_todas();

            return vendas.Where(v => v.codigo == codigo).FirstOrDefault<venda>();
        }

        public static void salvar(venda venda)
        {
            List<venda> vendas = retornar_todas();

            int indiceVenda = vendas.FindIndex(v => v.codigo == venda.codigo);

            if (indiceVenda == -1)
                vendas.Add(venda);
            else
                vendas[indiceVenda] = venda;

            List<string> linhas = new List<string>();
            

            foreach (venda v in vendas)
                linhas.Add(formatar_linha(v));

            File.WriteAllLines(BASE_DADOS_VENDAS, linhas);
        }

        public static void gravar_nova(venda venda)
        {
            File.AppendAllLines(BASE_DADOS_VENDAS, new List<string> { formatar_linha(venda) });
        }

        public static void atualizar(List<venda> vendas)
        {
            IEnumerable<string> linhas = vendas.Select(v => formatar_linha(v));
            File.WriteAllLines(BASE_DADOS_VENDAS, linhas);
        }

        private static string formatar_linha(venda venda)
        {
            string dataFormatada = venda.data_venda == null ? string.Empty : venda.data_venda.Value.ToString("dd/MM/yyyy");
            return $"{venda.codigo}|{dataFormatada}|{venda.valor}|";
        }
        */


        public int cod_venda;
        public int cod_imovel;
        public int cod_cliente;
        public int cod_corretor;
        public double valor_venda;
        public double taxa_administrativa;
        public double valor_proprietario;
        public string data;

        public bool Pesquisa()
        {
            using (StreamReader ler = new StreamReader("vendas.txt", true))//A estrutura USING fecha automaticamente o arquivo após encerrar as suas linhas de código
            {

                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');
                    //Para fazer os campos de pesquisa basta utilizar esse mesmo código utilizando apenas a comparação de nome
                    if (Convert.ToString(this.cod_imovel) == campos[1] && Convert.ToString(this.cod_cliente) == campos[2]) //Evitar duplicação de dados 
                    {
                        return false;
                    }

                }




            }
            return true;
        }



        public void Escreve()
        {
            using (StreamWriter escrever = new StreamWriter("vendas.txt", true))
            {
                escrever.WriteLine(this.cod_venda + "|" + this.cod_imovel + "|" + this.cod_cliente + "|" + this.cod_corretor + "|" + this.valor_venda + "|" + this.taxa_administrativa + "|" + this.valor_proprietario + "|" + this.data + "|");
            }
        }

        public string GeraCod(string cod)
        {
            int next_codigo = int.Parse(cod);
            ++next_codigo;
            return Convert.ToString(next_codigo);
        }

        public string PesquisaCod()
        {
            try
            {
                string[] readText = File.ReadAllLines("vendas.txt");
                string ultima_linha = readText[readText.Length - 1];
                string[] campos = ultima_linha.Split('|');

                if (campos[0] == "")
                {
                    return "0";
                }

                return campos[0];
            }
            catch//Se os campos do try derem erro, o catch captura e executa seus comandos
            {
                return "0";
            }

        }

         

        public bool ValidaVendaCorretor(string cod_cliente)//Pesquisa Venda Correto
        {
            using (StreamReader ler = new StreamReader("vendas.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (cod_cliente == campos[3])
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public List<string> PesquisaVendaCorretor(string nome)//Pesquisa Venda Corretor(NAO TO USANDO)
        {

            using (StreamReader ler = new StreamReader("vendas.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (nome == campos[3])
                    {
                        List<string> cliente_pesquisado = new List<string>();
                        cliente_pesquisado = campos.ToList<string>();
                        
                        return cliente_pesquisado;
                    }
                }


            }
            //List<string> imoveis = File.ReadLines("imoveis.txt").ToList();
            List<string> deu_erro = new List<string>();
            deu_erro.Add("Erro");
            return deu_erro;

        }

        public List<string> RetornaVendas(int cod_corretor)
        {
            List<string> vendas_corretor = new List<string>();
            using (StreamReader ler = new StreamReader("vendas.txt", true))//A estrutura USING fecha automaticamente o arquivo após encerrar as suas linhas de código
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    string compara = Convert.ToString(cod_corretor);
                    //Para fazer os campos de pesquisa basta utilizar esse mesmo código utilizando apenas a comparação de nome
                    if (compara == campos[3]) //Evitar duplicação de dados 
                    {
                        vendas_corretor.Add("Código da venda: " + campos[0] + "\nCódigo do Imóvel: " + campos[1] + "\nCódigo do Cliente: " + campos[2] + "\nCódigo do Corretor: " + campos[3] + "\nValor da Venda: R$ " + campos[4] + "\nTaxa Administrativa: R$ " + campos[5] + "\nValor Total do Proprietário: R$" + campos[6] + "\nData da Venda: " + campos[7]);
                    }

                }

                
            }
            return vendas_corretor;
        }

        public List<string> RetornaVendasporData(string date)//Vendas por Data
        {
            List<string> vendas_corretor = new List<string>();
            using (StreamReader ler = new StreamReader("vendas.txt", true))//A estrutura USING fecha automaticamente o arquivo após encerrar as suas linhas de código
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    //string compara = Convert.ToString(cod_corretor);
                    //Para fazer os campos de pesquisa basta utilizar esse mesmo código utilizando apenas a comparação de nome
                    if (date == campos[7]) //Evitar duplicação de dados 
                    {
                        vendas_corretor.Add("Código da venda: " + campos[0] + "\nCódigo do Imóvel: " + campos[1] + "\nCódigo do Cliente: " + campos[2] + "\nCódigo do Corretor: " + campos[3] + "\nValor da Venda: R$ " + campos[4] + "\nTaxa Administrativa: R$ " + campos[5] + "\nValor Total do Proprietário: R$" + campos[6] + "|");
                    }

                }


            }
            return vendas_corretor;
        }

    }
}
