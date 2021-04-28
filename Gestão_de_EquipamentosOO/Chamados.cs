using System;
using System.Collections.Generic;
using System.Text;

namespace Gestão_de_EquipamentosOO
{
    class Chamados
    {
        public const int CAPACIDADE_REGISTROS = 100;
        public static int[] idsChamado = new int[CAPACIDADE_REGISTROS];

        public static string[] titulosChamado = new string[CAPACIDADE_REGISTROS];
        public static string[] descricoesChamado = new string[CAPACIDADE_REGISTROS];
        public static int[] idsEquipamentoChamado = new int[CAPACIDADE_REGISTROS];
        public static DateTime[] datasAberturaChamado = new DateTime[CAPACIDADE_REGISTROS];

        public static int IdChamado;
      
       public static void ExcluirChamado()
        {
            Console.Clear();

            VisualizarChamados();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < Equipamentos.idsEquipamento.Length; i++)
            {
                if (idsChamado[i] == idSelecionado)
                {
                    idsChamado[i] = 0;
                    idsEquipamentoChamado[i] = 0;
                    titulosChamado[i] = null;
                    descricoesChamado[i] = null;
                    datasAberturaChamado[i] = DateTime.MinValue;

                    break;
                }
            }
        }

        public static void EditarChamado()
        {
            Console.Clear();

            VisualizarChamados();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            RegistrarChamado(idSelecionado);
        }

        public static void VisualizarChamados()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}", "Id", "Equipamento", "Título", "Dias em Aberto");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            int numeroChamadosRegistrados = 0;

            for (int indiceChamados = 0; indiceChamados < idsChamado.Length; indiceChamados++)
            {
                if (idsChamado[indiceChamados] > 0)
                {
                    string nomeEquipamento = "";

                    for (int indiceEquipamentos = 0; indiceEquipamentos < Equipamentos.idsEquipamento.Length; indiceEquipamentos++)
                    {
                        if (Equipamentos.idsEquipamento[indiceEquipamentos] == idsEquipamentoChamado[indiceChamados])
                        {
                            nomeEquipamento = Equipamentos.nomesEquipamento[indiceEquipamentos];
                            break;
                        }
                    }

                    TimeSpan diasEmAberto = DateTime.Now - datasAberturaChamado[indiceChamados];

                    Console.Write("{0,-10} | {1,-30} | {2,-55} | {3,-25}",
                       idsChamado[indiceChamados],
                       nomeEquipamento,
                       titulosChamado[indiceChamados],
                       diasEmAberto.ToString("dd"));

                    Console.WriteLine();

                    numeroChamadosRegistrados++;
                }
            }

            if (numeroChamadosRegistrados == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum chamado registrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public static void RegistrarChamado(int idChamadoSelecionado)
        {
            Console.Clear();

            int posicao = ObterPosicaoParaChamados(idChamadoSelecionado);

            Equipamentos.VisualizarEquipamentos();

            Console.Write("Digite o Id do equipamento para manutenção: ");
            int idEquipamentoChamado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o titulo do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            idsChamado[posicao] = IdChamado;
            idsEquipamentoChamado[posicao] = idEquipamentoChamado;
            titulosChamado[posicao] = titulo;
            descricoesChamado[posicao] = descricao;
            datasAberturaChamado[posicao] = dataFabricacao;

        }

        public static int ObterPosicaoParaChamados(int idChamadoSelecionado)
        {
            int posicao = 0;

            for (int i = 0; i < idsChamado.Length; i++)
            {
                if (idChamadoSelecionado == 0 && idsChamado[i] == 0) //inserindo...
                {
                    IdChamado++;
                    posicao = i;
                    break;
                }
                else if (idChamadoSelecionado == idsChamado[i]) //editando...
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }

        public static string ObterOpcaoControleChamados()
        {
            Console.WriteLine("Digite 1 para inserir novo chamado");
            Console.WriteLine("Digite 2 para visualizar chamados");
            Console.WriteLine("Digite 3 para editar um chamado");
            Console.WriteLine("Digite 4 para excluir um chamado");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
