using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count
{
    public class ValidadorCreditoFake:IValidadorCredito// implemnetar a interface
    {
        public bool ValidarCredito(string cpf, decimal valor)
        {
            //nn acessa nenhum webservice

            return true;
        }
    }
}
