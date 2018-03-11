using System.Collections.Generic;

namespace ConsoleTest
{
    public class NFE_COBRANCA
    {

        public NFE_COBRANCA()
        {
            NFE_COBRANCA_DUPLICATA = new List<ConsoleTest.NFE_COBRANCA_DUPLICATA>();
        }
        public List<NFE_COBRANCA_DUPLICATA> NFE_COBRANCA_DUPLICATA { get; set; }
    }

    public class NFE_COBRANCA_DUPLICATA
    {
        public int _nDup { get; set; }
        public int _dVenc { get; set; }
        public int _vDup { get; set; }
    }
}
