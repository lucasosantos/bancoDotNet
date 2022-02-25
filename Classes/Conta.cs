using System;
namespace bancoDotNet
{
    public class Conta
    {
        public TipoConta TipoConta {get; set;}

        public string Nome {set; get;} = "";

        public double Credito {get;set;}

        public double Saldo {get; set;}

        public int Numero {get; set;}

        public double CreditoTotal {get; set;}

        public double Juros {get; set;}

        public Conta(TipoConta tipo, double saldo, double credito, string nome, int numero, double juros){
            this.TipoConta = tipo;
            this.Saldo = saldo;
            this.Credito = credito;
            this.CreditoTotal = credito;
            this.Nome = nome;
            this.Numero = numero;
            this.Juros = juros;
        }

        public Conta(){

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo da Conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: R$ " + this.Saldo + " | ";
            retorno += "Credito: R$ " + this.Credito;
            return retorno;
        }

        public bool Sacar(double valor) {
            if (valor <= (this.Credito + this.Saldo)) {
                if (valor <= this.Saldo) {
                    this.Saldo -= valor;
                } else {
                    double valor2 = (valor - this.Saldo);
                    this.Saldo = 0;
                    this.Credito -= valor2;
                }
                return true;
            } else {
                return false;
            }
        }

        public void Depositar(double valor) {
            if (Credito < CreditoTotal) {
                double jurosCobrado = Juros*valor;
                Console.WriteLine("");
                Console.WriteLine("Você pagou R$ " + jurosCobrado + " de juros pela utilização do crédito!");
                Console.WriteLine("");
                valor = valor-jurosCobrado;
                double diferencaCredito = CreditoTotal - Credito;
                if (valor <= diferencaCredito) {
                    this.Credito += valor;
                } else {
                    double diferencaValor = valor - diferencaCredito;
                    this.Credito = CreditoTotal;
                    this.Saldo = diferencaValor;
                }
            } else {
                this.Saldo += valor;
            }
        }

        public bool Transferir(double valor, Conta contaDeposito) {
            if (valor <= this.Saldo) {
                this.Saldo -= valor;
                contaDeposito.Depositar(valor);
                return true;
            } else {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
        }

    }
}