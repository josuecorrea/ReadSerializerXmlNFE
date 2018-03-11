using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ConsoleTest
{
    public class NFE_MONGO
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string _cnpjDest { get; set; }
        public string _razaoDest { get; set; }
        public string _ieDest { get; set; }
        public string _cnpjEmit { get; set; }
        public string _razaoEmit { get; set; }
        public string _ieEmit { get; set; }
        public string _imEmit { get; set; }
        public string _chave  { get; set; }
        public DateTime _emissao { get; set; }

    }
}
