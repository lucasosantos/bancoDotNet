using System;

namespace bancoDotNet
{
    public class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args){
            Console.WriteLine("---------------------------");
            Console.WriteLine("------ Banco DotNet -------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("----------- Olá -----------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("");
            string resposta = "";

            do {
                resposta = ObterOpcaoInicial();

                switch (resposta)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        EntrarNaConta();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    default:
                        break;
                }

            } while (resposta != "X");
            Console.WriteLine("");
            Console.WriteLine("---------------------------");
            Console.WriteLine("---- Até a proxima! :D ----");
            Console.WriteLine("---------------------------");

        }

        public static void ImprimirCabecalho(string titulo) {
            Console.WriteLine("---------------------------");
            Console.WriteLine("------ " + titulo + " -------");
            Console.WriteLine("---------------------------");
        }

        public static void ListarContas(){
            ImprimirCabecalho("Lista de Contas");
            Console.WriteLine("");
            foreach (Conta conta in listaContas) {
                Console.WriteLine(conta.Numero + " -- " + conta.ToString());
            }
            Console.WriteLine("");
        }

        public static void ImprimirTitulo(string titulo) {
            Console.WriteLine("");
            Console.WriteLine("- " + titulo + " -");
            Console.WriteLine("");
        }

        public static void ImprimirMensagem(string msg) {
            Console.WriteLine("");
            Console.WriteLine("--------- Mensagem! ---------");
            Console.WriteLine("- "+ msg +" -");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
        }

        public static string ObterOpcaoInicial(){
            ImprimirCabecalho("Informe a Opção Desejada:");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Entrar em uma Conta");
            Console.WriteLine("c - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");
            string resposta = Console.ReadLine().ToUpper();

            return resposta;
        }

        public static void InserirConta(){
            ImprimirCabecalho("Criar Nova Conta");
            ImprimirTitulo("Tipo da Conta (1 - Fisica | 2 - Juridica):");
            int tipo = int.Parse(Console.ReadLine());
            ImprimirTitulo("Nome do Cliente:");
            string nome = Console.ReadLine();
            ImprimirTitulo("Saldo Inicial:");
            double saldo = double.Parse(Console.ReadLine());
            ImprimirTitulo("Credito Inicial:");
            double credito = double.Parse(Console.ReadLine());
            ImprimirTitulo("Juros Para Utilização do Credito:");
            double juros = double.Parse(Console.ReadLine());
            Console.WriteLine(juros);
            int numero;

            do {
                ImprimirTitulo("Número da Conta:");
                numero = int.Parse(Console.ReadLine());
            } while (!NumeroLivre(numero));
            
            Conta novaConta = new Conta((TipoConta)tipo, saldo, credito, nome, numero, juros);
            listaContas.Add(novaConta);
            ImprimirMensagem("Conta Criado com Sucesso!");
        }

        public static Boolean NumeroLivre(int numero) {
            bool livre = true;
            foreach (var item in listaContas)
            {
                if (item.Numero == numero) {
                    ImprimirMensagem("Número já usado!");
                    livre = false;
                }
            }
            return livre;
        }

        public static void EntrarNaConta(){
            ImprimirCabecalho("Sua Conta");
            ImprimirTitulo("N° da Conta:");
            int numConta = int.Parse(Console.ReadLine());
            Conta contaSelecionada = getConta(numConta);
            ImprimirTitulo("Olá" + " -- " + contaSelecionada.Nome);
            Console.WriteLine("");
            Console.WriteLine(contaSelecionada.ToString());
            Console.WriteLine("");
            string resposta = "";
            do {
                resposta = ObterOpcaoConta();

                switch (resposta)
                {
                    case "1":
                        Console.WriteLine("");
                        Console.WriteLine(contaSelecionada.ToString());
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");
                        Console.WriteLine("Informe o valor:");
                        Console.WriteLine("");
                        double valor = double.Parse(Console.ReadLine());
                        contaSelecionada.Depositar(valor);
                        ImprimirMensagem("Deposito Realizado com Sucesso!");
                        break;
                    case "3":
                        Console.WriteLine("");
                        Console.WriteLine("Informe o valor:");
                        Console.WriteLine("");
                        double valorSaque = double.Parse(Console.ReadLine());
                        contaSelecionada.Sacar(valorSaque);
                        ImprimirMensagem("Saque Realizado com Sucesso!");
                        break;
                    case "4":
                        Console.WriteLine("");
                        Console.WriteLine("Informe a Conta de Destino:");
                        Console.WriteLine("");
                        int contaDestino = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        Console.WriteLine("Informe o valor:");
                        Console.WriteLine("");
                        double valorTransferencia = double.Parse(Console.ReadLine());
                        if (contaSelecionada.Transferir(valorTransferencia, getConta(contaDestino))) {
                            ImprimirMensagem("Transferencia Realizado com Sucesso!");
                        } else {
                            ImprimirMensagem("Transferencia Não Finalizada!");
                        }
                        break;
                    default:
                        break;
                }

            } while (resposta != "X");
        }

        public static Conta getConta(int numero) {
            Conta conta = new Conta();
            foreach (var item in listaContas)
            {
                if (item.Numero == numero) {
                    conta = item;
                }
            }
            return conta;
        }

        public static string ObterOpcaoConta(){
            Console.WriteLine("");
            ImprimirCabecalho("Informe a Opção Desejada:");
            Console.WriteLine("");
            Console.WriteLine("1 - Imprimir Saldo e Crédito");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("4 - Transferir");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");
            string resposta = Console.ReadLine().ToUpper();

            return resposta;
        }

    }
}