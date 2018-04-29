using MongoDB.Driver;
using NFe.Classes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();

            ConcurrentBag<nfeProc> _objects = new ConcurrentBag<nfeProc>();
            Console.WriteLine("Read started!");

            stopWatch.Start();

            var files = ReadDirectory();

            for (int i = 0; i < files.Count; i++)
            {
                FileInfo info = new FileInfo(files[i]);
                if (info.Length > 0)
                {
                    var resultado = ExtNfeProc.CarregarDeArquivoXml(files[i]);
                    _objects.Add(resultado);

                    Console.WriteLine(i);
                }
            }

            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            ProcessaArquivos(_objects);

            Console.ReadKey();
        }

        private static List<string> ReadDirectory()
        {
            string[] fileEntries = Directory.GetFiles("C:\\50XML");
            return fileEntries.ToList();
        }

        private static async Task ProcessaArquivos(ConcurrentBag<nfeProc> documentos)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var listaDeDocumentos = new ConcurrentBag<NFE_MONGO>();

            Parallel.ForEach(documentos, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 }, file =>
            {
                var novoDocumento = new NFE_MONGO
                {
                    _chave = file.protNFe.infProt.chNFe,
                    _cnpjDest = file.NFe.infNFe.dest.CNPJ,
                    _cnpjEmit = file.NFe.infNFe.emit.CNPJ,
                    _emissao = file.NFe.infNFe.ide.dEmi,
                    _ieDest = file.NFe.infNFe.dest.IE,
                    _ieEmit = file.NFe.infNFe.emit.IE,
                    _imEmit = file.NFe.infNFe.emit.IM,
                    _razaoDest = file.NFe.infNFe.dest.xNome,
                    _razaoEmit = file.NFe.infNFe.emit.xNome,
                    _NumeroNF = file.NFe.infNFe.ide.nNF.ToString()
                };

                listaDeDocumentos.Add(novoDocumento);
            });

            await InseriDocumentoNoMongo(listaDeDocumentos);

            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Parallel Foreach(Convertendo Doc) " + elapsedTime);
            Console.WriteLine("Terminou");
        }

        private static async Task InseriDocumentoNoMongo(NFE_MONGO documento)
        {
            string connectionString = "mongodb://localhost:27017";
            var url = MongoUrl.Create(connectionString);

            MongoClient client = new MongoClient(new MongoClientSettings
            {
                MaxConnectionPoolSize = 6000,
                WaitQueueSize = 6000,
                Server = url.Server
            });

            IMongoDatabase db = client.GetDatabase("fiscal");

            var _NFE_ITENS_MONGO = db.GetCollection<NFE_MONGO>("NFE_ITENS_MONGO");

            await _NFE_ITENS_MONGO.InsertOneAsync(documento);

            Console.WriteLine("Arquivo inserido: " + documento._chave);
        }

        private static async Task InseriDocumentoNoMongo(ConcurrentBag<NFE_MONGO> documentos)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string connectionString = "mongodb://localhost:27017";
            var url = MongoUrl.Create(connectionString);
            MongoClient client = new MongoClient(new MongoClientSettings
            {
                MaxConnectionPoolSize = 200,
                WaitQueueSize = 200,
                Server = url.Server
            });

            IMongoDatabase db = client.GetDatabase("fiscal");

            var _NFE_ITENS_MONGO = db.GetCollection<NFE_MONGO>("NFE_MONGO");

            await _NFE_ITENS_MONGO.InsertManyAsync(documentos);

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine($"Inseriu { documentos.Count } mil: " + elapsedTime);
            Console.WriteLine("Terminou");
        }
    }
}
