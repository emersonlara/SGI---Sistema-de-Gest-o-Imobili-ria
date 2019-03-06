using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    class cliente
    {
        public int codigo;
        public string nome;
        public string endereco;
        public string telefone;
        public string data_nascimento;

        public bool Pesquisa()
        {
            using (StreamReader ler = new StreamReader("clientes.txt", true))//A estrutura USING fecha automaticamente o arquivo após encerrar as suas linhas de código
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');
                    //Para fazer os campos de pesquisa basta utilizar esse mesmo código utilizando apenas a comparação de nome
                    if (this.nome == campos[1] && this.endereco == campos[2] && this.telefone == campos[3] && this.data_nascimento == campos[4]) //Evitar duplicação de dados 
                    {
                        return false;
                    }

                }

                return true;
            }

        }



        public void Escreve()
        {
            using (StreamWriter escrever = new StreamWriter("clientes.txt", true))
            {
                escrever.WriteLine(this.codigo + "|" + this.nome + "|" + this.endereco + "|" + this.telefone + "|" + this.data_nascimento+"|");
            }
        }

        public string GeraCod(string cod)//Método que gera o próximo código caso um novo cliente seja cadastrado
        {
            int next_codigo = int.Parse(cod);
            ++next_codigo;
            return Convert.ToString(next_codigo);
        }

        public string PesquisaCod()//método que tem como finalidade atribuir o valor inicial do código após a aplicação ser iniciada
        {
            try
            {
                string[] readText = File.ReadAllLines("clientes.txt");
                string ultima_linha = readText[readText.Length - 1];
                string[] campos = ultima_linha.Split('|');

                return campos[0];
            }
            catch//Se os campos do try derem erro, o catch captura e executa seus comandos
            {
                return "0";
            }

        }

        public bool ValidaCodCliente(string cod_cliente)//Locacao
        {
            using (StreamReader ler = new StreamReader("clientes.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (cod_cliente == campos[0])
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool ValidaNomeCliente(string cod_cliente)//Venda
        {
            using (StreamReader ler = new StreamReader("clientes.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (cod_cliente == campos[1])
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public string GeraNome(string cod_cliente)
        {
            using (StreamReader ler = new StreamReader("clientes.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (cod_cliente == campos[0])
                    {
                        return campos[1];
                    }
                }


            }

            return "";


        }

        public string GeraCodVenda(string cod_cliente)//Venda
        {
            using (StreamReader ler = new StreamReader("clientes.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (cod_cliente == campos[1])
                    {
                        return campos[0];
                    }
                }


            }

            return "";


        }

        public List<string> PesquisaCliente(string nome)
        {

            using (StreamReader ler = new StreamReader("clientes.txt", true))
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



    }
}
