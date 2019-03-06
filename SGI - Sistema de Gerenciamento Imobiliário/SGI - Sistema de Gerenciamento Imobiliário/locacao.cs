using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    class locacao
    {
        public int codigo;
        public int codigo_imovel;
        public int codigo_cliente;
        public string nome_cliete;
        public string data;
        public string duracao;
        public double valor;
        public double taxa;
        public double valor_proprietario;

        public bool Pesquisa()
        {
            using (StreamReader ler = new StreamReader("locacoes2.txt", true))//A estrutura USING fecha automaticamente o arquivo após encerrar as suas linhas de código
            {
                
                    while (!ler.EndOfStream)
                    {
                        string linha = ler.ReadLine();

                        string[] campos = linha.Split('|');
                        //Para fazer os campos de pesquisa basta utilizar esse mesmo código utilizando apenas a comparação de nome
                        if (Convert.ToString(this.codigo_imovel) == campos[1] && Convert.ToString(this.codigo_cliente) == campos[2]) //Evitar duplicação de dados 
                        {
                            return false;
                        }

                    }
                
                

                
            }
            return true;
        }



        public void Escreve()
        {
            using (StreamWriter escrever = new StreamWriter("locacoes2.txt", true))
            {
                escrever.WriteLine(this.codigo + "|" + this.codigo_imovel + "|" + this.codigo_cliente + "|" + this.nome_cliete + "|"+this.data+"|"+this.duracao+"|"+this.valor+"|"+this.taxa+"|"+this.valor_proprietario);
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
                string[] readText = File.ReadAllLines("locacoes2.txt");
                string ultima_linha = readText[readText.Length - 1];
                string[] campos = ultima_linha.Split('|');

                if(campos[0] == "")
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

        public List<string> RetornaLocacaoporData(string date)//Vendas por Locação
        {
            List<string> vendas_corretor = new List<string>();
            using (StreamReader ler = new StreamReader("locacoes2.txt", true))//A estrutura USING fecha automaticamente o arquivo após encerrar as suas linhas de código
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    //string compara = Convert.ToString(cod_corretor);
                    //Para fazer os campos de pesquisa basta utilizar esse mesmo código utilizando apenas a comparação de nome
                    if(date == campos[4]) //Evitar duplicação de dados 
                    {
                        vendas_corretor.Add("Código da Locação: " + campos[0] + "\nCódigo do Imóvel: " + campos[1] + "\nCódigo do Cliente: " + campos[2] + "\nNome do Cliente: " + campos[3] + "\nDuração: " + campos[5] + "\nValor: R$" + campos[6] + "\nTaxa Administrativa: R$ " + campos[7] + "\nValor Total do Proprietário: R$" + campos[8]);
                    }

                }


            }
            return vendas_corretor;
        }

    }
}
