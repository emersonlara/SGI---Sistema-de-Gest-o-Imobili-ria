using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGI___Sistema_de_Gerenciamento_Imobiliário
{
    class imovel
    {
        public int codigo;
        public int codigo_proprietario;
        public string endereco;
        public string categoria;
        public string tipo;
        public int quantidade_quartos;
        public int quantidade_vagas;
        public double valor;
        public double condominio;
        public string status;
        public string observacoes;
        public int ultimo_cod;

        // Trocar as variáveis públicas para propriedades. Atalho: prop + TAB + TAB
        //public int codigo { get;  set; }

        #region Constantes
        public const int INDICE_ATRIBUTO_CODIGO_IMOVEL = 0;
        public const int INDICE_ATRIBUTO_CODIGO_PROPRIETARIO = 1;
        public const int INDICE_ATRIBUTO_ENDERECO = 2;
        public const int INDICE_ATRIBUTO_CATEGORIA = 3;
        public const int INDICE_ATRIBUTO_TIPO = 4;
        public const int INDICE_ATRIBUTO_QUANTIDADE_QUARTOS = 5;
        public const int INDICE_ATRIBUTO_VAGAS = 6;
        public const int INDICE_ATRIBUTO_VALOR = 7;
        public const int INDICE_ATRIBUTO_STATUS = 8;
        public const int INDICE_ATRIBUTO_OBSERVACOES = 9;
        #endregion

        public bool Pesquisa()
        {
            using (StreamReader ler = new StreamReader("imoveis.txt", true))//A estrutura USING fecha automaticamente o arquivo após encerrar as suas linhas de código
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    if (linha != null)
                    {
                        return true;
                    }
                    else
                    {
                        string[] campos = linha.Split('|');
                        //Para fazer os campos de pesquisa basta utilizar esse mesmo código utilizando apenas a comparação de nome
                        if (Convert.ToString(this.codigo_proprietario) == campos[1] && this.endereco == campos[2] && this.categoria == campos[3] && this.tipo == campos[4] && Convert.ToString(this.valor) == campos[7]) //Evitar duplicação de dados 
                        {
                            return false;
                        }
                    }



                }

                return true;
            }

        }

        public void Escreve()
        {
            using (StreamWriter escrever = new StreamWriter("imoveis.txt", true))
            {
                escrever.WriteLine(this.codigo + "|" + this.codigo_proprietario + "|" + this.endereco + "|" + this.categoria + "|" + this.tipo + "|" + this.quantidade_quartos + "|" + this.quantidade_vagas + "|" + this.valor + "|" + this.condominio + "|" + this.status + "|" + this.observacoes + "|");
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
                string[] readText = File.ReadAllLines("imoveis.txt");
                string ultima_linha = readText[readText.Length - 1];
                string[] campos = ultima_linha.Split('|');


                return campos[0];
            }
            catch//Se os campos do try derem erro, o catch captura e executa seus comandos
            {
                return "0";
            }
        }







        //Para o cadastro de imóveis
        public bool ValidaProprietario(string cod_proprietario)
        {
            using (StreamReader ler = new StreamReader("proprietarios.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (campos[0] == cod_proprietario)
                    {
                        return true;
                    }

                }

                return false;
            }
        }

        public bool ValidaCodImovel(string cod_imovel)
        {
            using (StreamReader ler = new StreamReader("imoveis.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (cod_imovel == campos[0])
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public string MudaStatusLocacao(int cod_imovel)
        {
            // Lê as linhas do arquivo e guarda na lista.
            List<string> imoveis = File.ReadLines("imoveis.txt").ToList();

            int indiceImovel = cod_imovel - 1;

            // Encontra o imovel pesquisado e já dá um split para separar os atributos.
            string[] imovelPesquisado = imoveis[indiceImovel].Split('|');

            // Altera o status para alugado.
            if (imovelPesquisado[9] == "a alugar" && imovelPesquisado[4] == "Locação")
            {
                imovelPesquisado[9] = "alugado";
            }
            else
            {
                return "Esse imóvel não está apto para ser alugado";
            }
            //imovelPesquisado[9] = "alugado";

            // Atualiza o imóvel na posição da lista com os novos valores.
            // Usa o método string.Join para formatar a linha.
            imoveis[indiceImovel] = string.Join("|", imovelPesquisado);

            File.WriteAllLines("imoveis.txt", imoveis);

            return "Status Alterado com sucesso";
        }

        public string MudaStatusVendas(int cod_imovel)
        {
            // Lê as linhas do arquivo e guarda na lista.
            List<string> imoveis = File.ReadLines("imoveis.txt").ToList();

            int indiceImovel = cod_imovel - 1;

            // Encontra o imovel pesquisado e já dá um split para separar os atributos.
            string[] imovelPesquisado = imoveis[indiceImovel].Split('|');

            // Altera o status para alugado.
            if(imovelPesquisado[9] == "a vender" && imovelPesquisado[4] == "Venda")
            {
                imovelPesquisado[9] = "com proposta";
            }
            else
            {
                return "O imóvel não está a venda!";
            }
            //imovelPesquisado[9] = "com proposta";

            // Atualiza o imóvel na posição da lista com os novos valores.
            // Usa o método string.Join para formatar a linha.
            imoveis[indiceImovel] = string.Join("|", imovelPesquisado);

            File.WriteAllLines("imoveis.txt", imoveis);

            return "Status Alterado com sucesso";
        }

        public string MudaStatusVendasCompleta(int cod_imovel)
        {
            // Lê as linhas do arquivo e guarda na lista.
            List<string> imoveis = File.ReadLines("imoveis.txt").ToList();

            int indiceImovel = cod_imovel - 1;

            // Encontra o imovel pesquisado e já dá um split para separar os atributos.
            string[] imovelPesquisado = imoveis[indiceImovel].Split('|');

            // Altera o status para alugado.
            imovelPesquisado[9] = "vendido";

            // Atualiza o imóvel na posição da lista com os novos valores.
            // Usa o método string.Join para formatar a linha.
            imoveis[indiceImovel] = string.Join("|", imovelPesquisado);

            File.WriteAllLines("imoveis.txt", imoveis);

            return "Status Alterado com sucesso";
        }

        public List<string> PesquisaImovel()
        {
            List<string> imoveis = File.ReadLines("imoveis.txt").ToList();

            return imoveis;
        }

        public bool ValidaNomeImovel(string cod_imovel)//Venda
        {
            using (StreamReader ler = new StreamReader("imoveis.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (cod_imovel == campos[0])
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public string GeraValoresVenda(string cod_imovel)//Venda
        {
            using (StreamReader ler = new StreamReader("imoveis.txt", true))
            {
                while (!ler.EndOfStream)
                {
                    string linha = ler.ReadLine();

                    string[] campos = linha.Split('|');

                    if (cod_imovel == campos[0])
                    {
                        return campos[7];
                    }
                }


            }

            return "";


        }
    }
}
