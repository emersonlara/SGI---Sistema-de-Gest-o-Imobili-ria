using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    class corretor
    {
        public int codigo;
        public string nome;
        public string telefone;
        public double salario;

        public bool Pesquisa()
        {
            using (StreamReader ler = new StreamReader("corretores.txt", true))//A estrutura USING fecha automaticamente o arquivo após encerrar as suas linhas de código
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');
                    //Para fazer os campos de pesquisa basta utilizar esse mesmo código utilizando apenas a comparação de nome
                    if (this.nome == campos[1] || this.telefone == campos[2] ) //Evitar duplicação de dados 
                    {
                        return false;
                    }

                }

                return true;
            }

        }



        public void Escreve()
        {
            using (StreamWriter escrever = new StreamWriter("corretores.txt", true))
            {
                escrever.WriteLine(this.codigo + "|" + this.nome + "|" + this.telefone + "|" + this.salario + "|");
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
                string[] readText = File.ReadAllLines("corretores.txt");
                string ultima_linha = readText[readText.Length - 1];
                string[] campos = ultima_linha.Split('|');

                return campos[0];
            }
            catch//Se os campos do try derem erro, o catch captura e executa seus comandos
            {
                return "0";
            }

        }

        public bool ValidaNomeCliente(string nome)//Pesquisa Corretor
        {
            using (StreamReader ler = new StreamReader("corretores.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (nome == campos[1])
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public List<string> PesquisaCorretor(string nome)//Pesquisa Corretor
        {

            using (StreamReader ler = new StreamReader("corretores.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (nome == campos[1])
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

        public int RetornaCodigo(string nome)// Relatório de Vendas de Corretor
        {
            using (StreamReader ler = new StreamReader("corretores.txt", true))//A estrutura USING fecha automaticamente o arquivo após encerrar as suas linhas de código
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');
                    //Para fazer os campos de pesquisa basta utilizar esse mesmo código utilizando apenas a comparação de nome
                    if (nome == campos[1]) //Evitar duplicação de dados 
                    {
                        return int.Parse(campos[0]);
                    }

                }

                return -1;
            }
        }

        
    }
}
