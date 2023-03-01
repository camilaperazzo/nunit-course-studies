using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Count;

namespace ContaTeste
{
    class ContaTeste
    {
        static void Main(string[] args)
        {
            testContaSacar();
            testContaSacarSemValor();
        }
        public static void testContaSacar()
        {
            //Arrange
            Count.Conta conta = new Count.Conta("0001", 100);
            bool resultadoEsperado = true;

            //Act
            bool resultado = conta.Sacar(50);

            //Assert
            if (resultado == resultadoEsperado)
            {
                Console.WriteLine("testContaSacar: 0K!");
            }
            else
            {
                Console.WriteLine("testContaSacar: FAIL!");
            }
        }

        public static void testContaSacarSemValor()
        {
            //Arrange
            Count.Conta conta = new Count.Conta("0001", 100);
            bool resultadoEsperado = false;

            //Act
            bool resultado = conta.Sacar(120);

            //Assert
            if (resultado == resultadoEsperado)
            {
                Console.WriteLine("testContaSacarSemValor: OK!");
            }
            else
            {
                Console.WriteLine("testContaSacarSemValor: FAIL!");
            }
        }

    }
}
