using DFe.Utils;
using NFe.Classes;
using System.IO;

public static class ExtNfeProc
{
    public static nfeProc CarregarDeArquivoXml(string arquivoXml)
    {
        var s = FuncoesXml.ObterNodeDeArquivoXml(typeof(nfeProc).Name, arquivoXml);
        return FuncoesXml.XmlStringParaClasse<nfeProc>(s);
    }

    public static nfeProc CarregardeStream(this nfeProc nfeProc, StreamReader stream)
    {
        var s = FuncoesXml.ObterNodeDeStream(typeof(nfeProc).Name, stream);
        return FuncoesXml.XmlStringParaClasse<nfeProc>(s);
    }

    public static string ObterXmlString(this nfeProc nfeProc)
    {
        return FuncoesXml.ClasseParaXmlString(nfeProc);
    }

    public static nfeProc CarregarDeXmlString(this nfeProc nfeProc, string xmlString)
    {
        var s = FuncoesXml.ObterNodeDeStringXml(typeof(nfeProc).Name, xmlString);
        return FuncoesXml.XmlStringParaClasse<nfeProc>(s);
    }
    
    public static void SalvarArquivoXml(this nfeProc nfeProc, string arquivoXml)
    {
        FuncoesXml.ClasseParaArquivoXml(nfeProc, arquivoXml);
    }
}
