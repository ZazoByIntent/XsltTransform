using System;
using System.IO;
using System.Collections.Generic;

namespace XslTransform
{
    class Program
    {
        static string xsltDatoteka = "Transform2.xslt";
        static string xmlDatoteka = "Data.xml";
        static string outputPath = "test.html";
               
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            #region TestClass
            List<TestClass> seznam = new List<TestClass>();
            for(int i = 0; i < 10; i++)
            {
                seznam.Add(new TestClass(i.ToString(),(i+1).ToString()));
            }
            #endregion
            File.WriteAllText(outputPath, new Transform().VrniDokument(seznam, xsltDatoteka));
            DateTime end = DateTime.Now;
            Console.WriteLine("The application finished at {0:HH:mm:ss.fff}\n", DateTime.Now);
            TimeSpan elapsed = end - start;
            Console.WriteLine("The application finished in {0}", elapsed);
        }
    }
}
 