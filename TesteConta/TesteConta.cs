using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Count;
using NUnit.Framework;

namespace TesteConta
{
    [TestFixture] // informa que é uma classe de teste
    public class TesteConta
    {
        Conta conta;

        /* outra alternativa é o [OneTimeSetUp] or [OneTimeTearDown]
         * será executado um vez...
         */

        [SetUp]//atributo que faz com que um metodo seja chamado antes da execução de cada teste
        public void SetUp()
        {
           conta = new Conta("0009", 200);
            
        }

        [TearDown]

        public void TearDown()
        {
            //codigo executado apos cada teste unitário
            conta = null;
        }
        [Test] //estrutura basica nunit
        public void testSacar()//td teste unitario deve ser public void 
        {
            //Conta conta = new Conta("0009", 200);

            bool resultado = conta.Sacar(120);

            Assert.IsTrue(resultado);// classe da nunit para verificar os metodos
            //is false

        }

        [Test]
        public void testSacarSemSaldo()
        {
            //Conta conta = new Conta("0009", 200);

            bool resultado = conta.Sacar(250);

            Assert.IsFalse(resultado);
        }

        [Test]
        [Ignore("testando")]// atributo nunit para ignorar o teste
        //string para informar o pq de estar ignorando
        // o atributo tb pode ser colocado na classe 

        public void testSacarValorNegativo()
        {
            //Conta conta = new Conta("0009", 200);

            bool resultado = conta.Sacar(-100);

            Assert.IsFalse(resultado);
        }

        public void testAssert()
        {
            //para treinar a classe assert

            string s = "";

            Assert.IsEmpty(s);//verificar se uma string esta vazia 

            //Assert.GreaterOrEqual(a, b);...
        }
    }
}
