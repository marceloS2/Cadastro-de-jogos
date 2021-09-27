using System;

namespace Dio.Jogos
{
 class Program
    {
      static JogosRepositorio repositorio = new JogosRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();
        
         while (opcaoUsuario.ToUpper() != "X")
          {

        
         switch (opcaoUsuario)
         {
            case "1":
               ListarJogos();
                break;
            case "2":
               InserirJogos();
                 break;
             case "3":
               AtualizarJogos();
				 break;
            case "4":
               ExcluirJogos();
                 break;
             case "5":
               VisualizarJogos();
                  break;
             case "C":
               Console.Clear();
                  break;
             default:

               throw new ArgumentOutOfRangeException();
          
             }
             opcaoUsuario = ObterOpcaoUsuario();

        
          }
          
          Console.WriteLine("Obrigado por utilizar nossos serviços.");
		    	Console.ReadLine();
       }
       private static void ListarJogos() //oque tiver no cs programs
       {
          Console.WriteLine("Listar Jogos");

          var Lista = repositorio.Lista(); //tudo que tiver no repositorio
           
           if (Lista.Count == 0 ) 
          {
            Console.WriteLine("Nenhum jogo cadastrado.");
             return;
          }
           foreach (var jogo in Lista)
         {
             var excluido = jogo.retornaExcluido();

           Console.WriteLine("#ID {0}: - {1} {2}", jogo.retornaId(), jogo.retornaTitulo(), (excluido ? "*Excluido*" : ""));
         }
       
       }
          private static void ExcluirJogos()
		{
			Console.Write("Digite o id da jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceJogo);
		}


         private static void VisualizarJogos()
		{
			Console.Write("Digite o id do Jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			var Jogo = repositorio.RetornaPorId(indiceJogo);

			Console.WriteLine(Jogo);
		}

       private static void AtualizarJogos()
		{
			Console.Write("Digite o id do Jogo: ");
			int indiceJogo = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Jogo: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do jogo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do jogo: ");
			string entradaDescricao = Console.ReadLine();

			Jogos atualizaJogo = new Jogos(id: indiceJogo,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceJogo, atualizaJogo);
		}
           private static void InserirJogos()
		{
			Console.WriteLine("Inserir novo jogo");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do jogos: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Jogo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Jogo: ");
			string entradaDescricao = Console.ReadLine();

			Jogos novojogo = new Jogos(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novojogo);

      }      
      
      
                private static string ObterOpcaoUsuario()
      {
         Console.WriteLine();
         Console.WriteLine("Vicio Game seja bem vindo:");
         Console.WriteLine("Informe a opção desejada:");
         
         Console.WriteLine("1- Listar Jogos");
         Console.WriteLine("2- Inseri novo Jogos");
         Console.WriteLine("3- Atualizar Jogos");
         Console.WriteLine("4- Excluir Jogos");
         Console.WriteLine("5- Visualizar Jogos");
		 Console.WriteLine("C- Limpar Tela");
         Console.WriteLine("X- Sair");
		 Console.WriteLine();

         String opcaoUsuario = Console.ReadLine().ToUpper();
         Console.WriteLine();
         return opcaoUsuario;



      }



   }
}
