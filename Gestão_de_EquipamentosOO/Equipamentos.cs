using System;   
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_EquipamentosOO
{
     public  class Equipamentos
    {
        public const int CAPACIDADE_REGISTROS = 100;
        public static int[] idsEquipamento = new int[CAPACIDADE_REGISTROS];

        public static string[] nomesEquipamento = new string[CAPACIDADE_REGISTROS];
        public static double[] precosEquipamento = new double[CAPACIDADE_REGISTROS];
        public static string[] numerosSerieEquipamento = new string[CAPACIDADE_REGISTROS];
        public static DateTime[] datasFabricacaoEquipamento = new DateTime[CAPACIDADE_REGISTROS];
        public static string[] fabricantesEquipamento = new string[CAPACIDADE_REGISTROS];

        private static int IdEquipamento;

        public static string ObterOpcaoCadastroEquipamentos()
        {
            Console.WriteLine("Digite 1 para inserir novo equipamento");
            Console.WriteLine("Digite 2 para visualizar equipamentos");
            Console.WriteLine("Digite 3 para editar um equipamento");
            Console.WriteLine("Digite 4 para excluir um equipamento");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public static void EditarEquipamento()
        {
            Console.Clear();

            VisualizarEquipamentos();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            RegistrarEquipamento(idSelecionado);
        }

        public static void ExcluirEquipamento()
        {
            Console.Clear();

            VisualizarEquipamentos();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < idsEquipamento.Length; i++)
            {
                if (idsEquipamento[i] == idSelecionado)
                {
                    idsEquipamento[i] = 0;
                    nomesEquipamento[i] = null;
                    precosEquipamento[i] = 0;
                    numerosSerieEquipamento[i] = null;
                    datasFabricacaoEquipamento[i] = DateTime.MinValue;
                    fabricantesEquipamento[i] = null;

                    break;
                }
            }
        }

        public static void VisualizarEquipamentos()
        {
            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-55} | {2,-35}", "Id", "Nome", "Fabricante");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            int numeroEquipamentosCadastrados = 0;

            for (int i = 0; i < idsEquipamento.Length; i++)
            {
                if (idsEquipamento[i] > 0)
                {
                    Console.Write("{0,-10} | {1,-55} | {2,-35}",
                       idsEquipamento[i], nomesEquipamento[i], fabricantesEquipamento[i]);

                    Console.WriteLine();

                    numeroEquipamentosCadastrados++;
                }
            }

            if (numeroEquipamentosCadastrados == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum equipmaneto cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public static void RegistrarEquipamento(int idEquipamentoSelecionado)
        {
            Console.Clear();

            int posicao = ObterPosicaoParaEquipamentos(idEquipamentoSelecionado);

            string nome = "";
            bool nomeInvalido = false;
            do
            {
                Console.Write("Digite o nome do equipamento: ");
                nome = Console.ReadLine();
                if (nome.Length < 6)
                {
                    nomeInvalido = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nome inválido. No mínimo 6 caracteres");
                    Console.ResetColor(); ;
                }

            } while (nomeInvalido);


            Console.Write("Digite o preço do equipamento: ");
            double preco = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número do equipamento: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite a data de fabricação do equipamento: ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            idsEquipamento[posicao] = IdEquipamento;
            nomesEquipamento[posicao] = nome;
            precosEquipamento[posicao] = preco;
            numerosSerieEquipamento[posicao] = numeroSerie;
            datasFabricacaoEquipamento[posicao] = dataFabricacao;
            fabricantesEquipamento[posicao] = fabricante;
        }
        private static int ObterPosicaoParaEquipamentos(int idEquipamentoSelecionado)
        {
            int posicao = 0;

            for (int i = 0; i < idsEquipamento.Length; i++)
            {
                if (idEquipamentoSelecionado == 0 && idsEquipamento[i] == 0) //inserindo...
                {
                    IdEquipamento++;
                    posicao = i;
                    break;
                }
                else if (idEquipamentoSelecionado == idsEquipamento[i]) //editando...
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
    }
}
