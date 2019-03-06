using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    class proprietario
    {
        public int codigo;
        public string nome;
        public string endereco;
        public string telefone;

        public bool Pesquisa()
        {
            using (StreamReader ler = new StreamReader("proprietarios.txt", true))//A estrutura USING fecha automaticamente o arquivo após encerrar as suas linhas de código
            {
                while(!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');
                    //Para fazer os campos de pesquisa basta utilizar esse mesmo código utilizando apenas a comparação de nome
                    if((this.nome == campos[1] || this.endereco == campos[2] || this.telefone == campos[3])|| (this.nome == campos[1] && this.telefone == campos[3])|| (this.nome == campos[1] && this.endereco == campos[2])) //Evitar duplicação de dados 
                    {
                        return false; 
                    }
                    
                }

                return true;
            }

        }



        public void Escreve()
        {
            using (StreamWriter escrever = new StreamWriter("proprietarios.txt", true))
            {
                escrever.WriteLine(this.codigo + "|" + this.nome + "|" + this.endereco + "|" + this.telefone + "|");
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
                string[] readText = File.ReadAllLines("proprietarios.txt");
                string ultima_linha = readText[readText.Length - 1];
                string[] campos = ultima_linha.Split('|');

                return campos[0];
            }
            catch//Se os campos do try derem erro, o catch captura e executa seus comandos
            {
                return "0";
            }

        }

        public bool ValidaNomeProprietario(string cod_cliente)//Pesquisa Proprietário
        {
            using (StreamReader ler = new StreamReader("proprietarios.txt", true))
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

        public List<string> PesquisaProprietario(string nome)//Pesquisa Proprietário
        {

            using (StreamReader ler = new StreamReader("proprietarios.txt", true))
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
