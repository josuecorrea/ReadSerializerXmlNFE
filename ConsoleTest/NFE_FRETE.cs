using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public class NFE_FRETE : NFE_TRANSPORTADORA
    {
        public string _modFrete { get; set; }
    }

    public class NFE_TRANSPORTADORA : NFE_FRETE_VOLUME
    {
        public NFE_TRANSPORTADORA()
        {
            NFE_FRETE_VOLUME = new List<ConsoleTest.NFE_FRETE_VOLUME>();
        }

        public string CNPJ { get; set; }
        public string xNome { get; set; }
        public string IE { get; set; }
        public string xEnder { get; set; }
        public string xMun { get; set; }
        public string UF { get; set; }

        public List<NFE_FRETE_VOLUME> NFE_FRETE_VOLUME { get; set; }
    }

    public class NFE_FRETE_VOLUME
    {
        public string qVol { get; set; }
        public string esp { get; set; }
        public string nVol { get; set; }
        public string pesoL { get; set; }
        public string pesoB { get; set; }
    }
}
