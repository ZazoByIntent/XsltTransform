using System;
using System.IO;

namespace XslTransform
{
    class Program
    {
        static string xsltDatoteka = "Transform.xslt";
        static string xmlDatoteka = "Data.xml";
        static string outputPath = "index.html";
        
        
        static void Main(string[] args)
        {
            Transform xmlTransform = new Transform();
            File.WriteAllText(outputPath, xmlTransform.VrniHtmlDokument(xmlDatoteka, xsltDatoteka));   
        }
    }
}
 