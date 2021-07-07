using System;
using System.Collections.Generic;

namespace App.Transf.Bancarias
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
                    Conhecer();
                    break;
                    case "2":
                    ListarContas();
                    break;
                    case "3":
                    InserirContas();
                    break;
                    case "4":
                    Transferir();
                    break;
                    case "5":
                    Sacar();
                    break;
                    case "6":
                    Depositar();
                    break;
                    case "C":
                    Console.Clear();
                    break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por ser cliente DIO Bank, volte sempre!!");
            Console.ReadLine();
        }

        private static void Conhecer()
        {
            Console.WriteLine("O MATT BANK surgiu como uma maneira de SIMPLIFICAR a vida dos nossos clientes, \n tirar as burocracias e conectar as soluções que você precisa em um só lugar!");
            Console.WriteLine("Nascemos em 2021, na era da INFORMAÇÃO e da AGILIDADE! \n Geramos valor não só para nossos clientes, mas também para os nossos colaboradores, investidores e para a sociedade como um todo.");
            Console.WriteLine("O MATT BANK é o que há de mais novo em soluções financeiras! Não fique para trás, seja MATT BANK!!!");
            Console.WriteLine("Fique por dentro das nossas novidades baixando o nosso APP e nos seguindo em nossas redes sociais!");
        }

        private static void ListarContas()
        {
           Console.WriteLine("Listar Contas");

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
        private static void InserirContas()
        {
            Console.WriteLine("Inserir uma nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta (tipoConta: (TipoConta)entradaTipoConta,
                                         saldo: entradaSaldo, 
                                         credito: entradaCredito,
                                         nome: entradaNome);

            listContas.Add(novaConta);
        }
        private static void Transferir()
        {
           Console.Write("Digite o numero da conta de origem: ");
           int indiceContaOrigem = int.Parse(Console.ReadLine());

           Console.Write("Digite o número da conde de destino: ");
           int indiceContaDestino = int.Parse(Console.ReadLine());

           Console.Write("Digite o valor da transferencia: ");
           double valorTransferencia = double.Parse(Console.ReadLine());

           listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de deposito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("****** BEM VINDO AO MATT BANK ******");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Conheça o MATT BANK");
            Console.WriteLine("2- Listar contas");
            Console.WriteLine("3- Inserir nova conta");
            Console.WriteLine("4- Transferir");
            Console.WriteLine("5- Sacar");
            Console.WriteLine("6- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

