using NUnit.Framework;
using Moq;
using Count;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaTeste.Mock
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void testSolicitarEmprestimo()
        {
            var conta = new Conta("0002", 100);

            //instanciar um obj do tipo mock
            var mock = new Mock<IValidadorCredito>();//passa no generico a interface que sera o mock
                                                     //foi criada uma classe feita... o framework que fez

            //tb pd ser uma classe

            //setup no metodo que sera usado
            //expressão lambda
            //fazer o comportamento
            //mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.IsAny<decimal>())).Returns(true);//para preparar o mock

            //mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.Is<decimal>(i => i <=5000))).Returns(true);

            // para testar o try catch
            mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.IsAny<decimal>())).Throws<InvalidOperationException>();//tipo da exceção
            //sabe se esta recebendo bem uma exceção

            conta.SetValidadorCredito(mock.Object);//iserindo o obj fake
            //injetando a dependencia ACIMA  
            //mock.object--  é objeto verdadeiro
            int resultadoEsperado = 100;

            conta.SolicitarEmprestimo(5000);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);

        }

        //retorna o valor default
        // bool true or false
        //int 0
        //object null

        [Test]
        public void testSolicitarEmprestimoAcimaLimite()
        {
            string cpf = "0001";

            Conta conta = new Conta(cpf, 100);
            var mock = new Mock<IValidadorCredito>();
            conta.SetValidadorCredito(mock.Object);

            bool resultado = conta.SolicitarEmprestimo(1200);

            //metodo do mock
            //verificando que o determinado metodo nn foi verificado nenhuma vez
            //de jeito nenhum
            //times quer dizer vezes que determinado teste foi executado
            mock.Verify(x => x.ValidarCredito(It.IsAny<string>(), It.IsAny<decimal>()), Times.Never());
        }
       
    }
}