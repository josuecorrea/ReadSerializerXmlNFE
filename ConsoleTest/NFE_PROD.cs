namespace ConsoleTest
{
    public class NFE_PROD
    {
        public string _chaveNfe { get; set; }
        public string _cProd { get; set; }
        public string _cEAN { get; set; }
        public string _xProd { get; set; }
        public string _NCM { get; set; }
        public string _CFOP { get; set; }
        public string _uCom { get; set; }
        public string _qCom { get; set; }
        public string _vUnCom { get; set; }
        public string _vProd { get; set; }
        public string _cEANTrib { get; set; }
        public string _uTrib { get; set; }
        public string _qTrib { get; set; }
        public string _vUnTrib { get; set; }
        public string _indTot { get; set; }
        public string _vTotTrib { get; set; }

        public NFE_PROD_COFINS COFINS { get; set; }
        public NFE_PROD_ICMS ICMS { get; set; }
        public NFE_PROD_IPI IPI { get; set; }
        public NFE_PROD_PIS PIS { get; set; }
    }
}
