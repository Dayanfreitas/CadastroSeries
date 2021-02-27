using System;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {   
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {

            string op = ObterOpcaoUsuario();
            while (op != "X")
            {
                switch (op)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                op = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços !");
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor !!!");
            Console.WriteLine("Informe a opção desejada:");
            
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string op = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return op;
        }

        private static void ListarSeries() 
        {
            Console.WriteLine("Listar séries !");
            var lista = repositorio.Lista();

            if (lista.Count == 0) 
            {
                Console.WriteLine("Nenhum série cadastradas. ");
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie () 
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i , Enum.GetName(typeof(Genero), i ));
            }

            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            int ano  = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o descrição: ");
            string descricao = Console.ReadLine();
            

            Series novaSerie = new Series(repositorio.ProximoId(), (Genero)genero, nome, descricao, ano);


            repositorio.Insere(novaSerie);

        }
    }
}
