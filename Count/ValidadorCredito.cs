using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count
{
    internal class ValidadorCredito:IValidadorCredito// : ??

    {
        private readonly string cpf;

        public ValidadorCredito(string cpf)
        {
            this.cpf = cpf;
        }

        public bool ValidarCredito(string cpf, decimal valor)
        {
            bool StatusSerasa = VerificarSituacaoSerasa(cpf);
            bool StatusSPC = VerificarSituacaoSPC(cpf);

            return (StatusSerasa && StatusSPC);
        }

        private bool VerificarSituacaoSerasa(string cpf)
        {
            //chamada a um webservice para verificar situação Serasa
            return true;
        }

        private bool VerificarSituacaoSPC(string cpf)
        {
            //chamada a um webservice para verificar situação SPC
            return true;
        }
    }
}
