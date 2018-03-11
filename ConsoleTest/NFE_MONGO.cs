using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    public class NFE_MONGO
    {
        public NFE_MONGO() => NFE_PROD = new List<ConsoleTest.NFE_PROD>();

        [BsonId]
        public ObjectId _id { get; set; }
        public string _NumeroNF { get; set; }
        public string _cnpjDest { get; set; }
        public string _razaoDest { get; set; }
        public string _ieDest { get; set; }
        public string _cnpjEmit { get; set; }
        public string _razaoEmit { get; set; }
        public string _ieEmit { get; set; }
        public string _imEmit { get; set; }
        public string _chave  { get; set; }
        public string _serie { get; set; }
        public string _modelo { get; set; }
        public string _tpNf { get; set; }
        public string _cUF { get; set; }
        public string _natOpe { get; set; }
        public DateTime _emissao { get; set; }
        public string _infCpl { get; set; }

        public List<NFE_PROD> NFE_PROD { get; set; }

    }
}
