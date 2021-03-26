using System;
using System.Collections.Generic;

namespace DIO.Bank
{
  class Program
  {
    static List<Conta> listContas = new List<Conta>();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarContas();
            break;
          case "2":
            InserirConta();
            break;
          case "3":
            Transferir();
            break;
          case "4":
            Sacar();
            break;
          case "5":
            Depositar();
            break;
          default:
            throw new ArgumentOutOfRangeException();

        }
        opcaoUsuario = ObterOpcaoUsuario();
      }

    }

    private static void ListarContas()
    {
      Console.WriteLine("Listar contas");

      if (listContas.Count == 0)
      {
        Console.WriteLine("Nenhuma conta cadastrada.");
        return;
      }

      for (int i = 0; i < listContas.Count; i++)
      {
        Conta conta = listContas[i];
        Console.Write("#{0} - ", i);
        Console.WriteLine(conta);
      }
    }

    private static void InserirConta()
    {
      Console.WriteLine("Inserir nova conta");

      Console.Write("Digite 1 para conta fisica ou 2 para conta juridica: ");
      int entradaTipoConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o nome do cliente: ");
      string entradaNome = Console.ReadLine();

      Console.Write("Digite o saldo inicial: ");
      double entradaSaldo = double.Parse(Console.ReadLine());

      Console.Write("Digite o crédito: ");
      double entradaCredito = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

      listContas.Add(novaConta);
    }

    private static void Transferir()
    {
      Console.Write("Digite o número da conta de origem: ");
      int contaOrigem = int.Parse(Console.ReadLine());

      Console.Write("Digite o número da conta de destino: ");
      int indiceContaDestino = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser transferido: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      listContas[contaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
    }

    private static void Sacar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser sacado: ");
      double valorSaque = double.Parse(Console.ReadLine());

      listContas[indiceConta].Sacar(valorSaque);
    }

    private static void Depositar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser depositado: ");
      double valorDeposito = double.Parse(Console.ReadLine());

      listContas[indiceConta].Depositar(valorDeposito);
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine();

      Console.WriteLine("1 - Listar contas");
      Console.WriteLine("2 - Inserir nova Conta");
      Console.WriteLine("3 - Transferir");
      Console.WriteLine("4 - Sacar");
      Console.WriteLine("5 - Depositar");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
