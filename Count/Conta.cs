using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count
{
    public class Conta
    {
        public static void Main(string[] args)
        {
            
        }
        private string cpf;
        private decimal saldo;
        private IValidadorCredito validadorCredito;

        //exemplo de injetar a depoendencia por construtor
        public Conta(string cpf, decimal saldo /*IValidadorCredito validado*/)
        {
            this.cpf = cpf;
            this.saldo = saldo;
        }

        public void SetValidadorCredito(IValidadorCredito validador)
        {
            this.validadorCredito = validador;//atraves desse metodo que vai injeta a dependencia
        }

        public decimal GetSaldo()
        {
            return saldo;
        }

        public void Depositar(decimal valor)
        {
            this.saldo += valor;
        }

        public bool Sacar(decimal valor)
        {
           // Thread.Sleep(5000);// fazer o teste demorar mais FORÇAR
            if (valor <= 0)
            {
                //throw new ArgumentOutOfRangeException();
                return false;
            }

            if (saldo < valor)
            {
                return false;
            }
            else
            {

                this.saldo -= valor;
                return true;
            }
        }

        public bool SolicitarEmprestimo(decimal valor)
        {
            //bool resultado = validadorCredito.ValidarCredito(this.cpf, valor);

            bool resultado = false;

            //logica antes de ir para suposta exceção
            if (valor >= this.saldo * 10)
            {
                return resultado;
            }

            try
            {
                resultado = validadorCredito.ValidarCredito(this.cpf, valor);
            }
            catch (InvalidOperationException)
            {
                return resultado;
            }

            if (resultado)
            {
                this.saldo += valor;
            }

            return resultado;
        }
    }
}
