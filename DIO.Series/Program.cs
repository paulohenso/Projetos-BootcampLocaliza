using System;

namespace DIO.Series
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
      string opcaoUsario = ObterOpcaoUsuario();

      while (opcaoUsario.ToUpper() != "X")
      {
        switch (opcaoUsario)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSeries();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsario = ObterOpcaoUsuario();
      }
    }

    private static void ExcluirSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      repositorio.Exclui(indiceSerie);
    }

    private static void VisualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);

      Console.WriteLine(serie);
    }

    private static void AtualizarSerie()
    {
      Console.Write("Digite o id da séire: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.Write("Digite o gênero entre as opção acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Serie atualizarSerie = new Serie(id: indiceSerie,
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);
      repositorio.Atualiza(indiceSerie, atualizarSerie);
    }

    private static void InserirSeries()
    {
      Console.WriteLine("Inserir nova série");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.Write("Digite o gênero entre as opção acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);

      repositorio.Insere(novaSerie);

    }

    private static void ListarSeries()
    {
      Console.WriteLine("Listar séries");

      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada. ");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();
        Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
      }
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!!");
      Console.WriteLine();

      Console.WriteLine("1 - Listar séries");
      Console.WriteLine("2 - Inserir nova série");
      Console.WriteLine("3 - Atualizar série");
      Console.WriteLine("4 - Excluir série");
      Console.WriteLine("5 - Visualizar série");
      Console.WriteLine("C - Limpar tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcaoUsario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsario;
    }
  }
}
