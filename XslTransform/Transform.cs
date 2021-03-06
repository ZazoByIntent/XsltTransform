using System;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace XslTransform
{
    public class Transform
    {
        // public static string ImenikXslt = HttpContext.Current.Request.PhysicalApplicationPath + "Reports\\";
        // string path = SessionHandler.ImenikXslt + KonstanteWEB.DOC_INSTALACIJE_NAROCILA_DOGODKI;
        
        
        public string VrniDokument<T>(List<T> aEntitetaCollection, string aXsltDatoteka)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (XmlWriter stringWriter = XmlWriter.Create(stringBuilder))
                new XmlSerializer(typeof(List<T>)).Serialize(stringWriter, aEntitetaCollection);
            return new Transform().VrniHtmlDokument(XDocument.Parse(stringBuilder.ToString()), aXsltDatoteka);
        }

        private string VrniHtmlDokument(XDocument aDocument, string aXsltDatoteka)
        {
            XslCompiledTransform xct = new XslCompiledTransform();
            StringBuilder stringBuilder = new StringBuilder();
            using (XmlWriter stringWriter = XmlWriter.Create(stringBuilder))
            {
                xct.Load(aXsltDatoteka, new XsltSettings(false, true), new XmlUrlResolver());
                xct.Transform(aDocument.CreateReader(ReaderOptions.None), stringWriter);
            }
            return stringBuilder.ToString();
        }
        

        /*
        public string VrniDokument<T>(List<T> aEntitetaCollection, string aXsltDatoteka)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<T>));
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            ser.Serialize(writer, aEntitetaCollection);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());

            return new Transform().VrniHtmlDokument(doc, aXsltDatoteka);         
        }


        private string VrniHtmlDokument(object aData, string aXsltDatoteka)
        {

            XmlSerializer ser = new XmlSerializer(aData.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            ser.Serialize(writer, aData);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());


            XsltSettings xslt_set = new XsltSettings();
            xslt_set.EnableScript = true;

            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load(aXsltDatoteka, xslt_set, new XmlUrlResolver());


            StringBuilder sb2 = new StringBuilder();
            StringWriter sw = new StringWriter(sb2);
            XmlTextWriter tw = new XmlTextWriter(sw);

            xct.Transform(doc, tw);
            string Vsebina = sb2.ToString();
            return Vsebina;
        }
        */
        


        /*
        public string VrniHtmlDokument(string aXmlDatoteka, string aXsltDatoteka)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(aXmlDatoteka);

            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load(aXsltDatoteka, new XsltSettings(false, true), new XmlUrlResolver());

            StringWriter sw = new StringWriter();
            xct.Transform(xmlDoc, new XmlTextWriter(sw));

            return sw.GetStringBuilder().ToString();
        }
        */

        /*
        public static List<string> XmlFileToString(List<string> aEntitetaCollection)
        {
            List<string> XmlData = new List<string>();
            foreach(string file in aEntitetaCollection)
            {
                XmlData.Add(XmlToString(file));
            }
            return XmlData;
        }

        public static string XmlToString(string aFilePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(aFilePath);
            using (StringWriter sw = new StringWriter())
            using (XmlWriter tw = XmlWriter.Create(sw))
            {
                doc.WriteTo(tw);
                tw.Flush();
                Console.WriteLine(sw.GetStringBuilder().ToString());
                return sw.GetStringBuilder().ToString();
            }
        }


        public static string VrniDokument(List<string> aEntitetaCollection, string aXsltDatoteka)
        {
            List<string> stringCollection = XmlFileToString(aEntitetaCollection);
            XmlSerializer ser = new XmlSerializer(typeof(List<string>));
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            ser.Serialize(writer, stringCollection);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());
            return VrniHtmlDokument(doc, aXsltDatoteka);
        }


        private static string VrniHtmlDokument(object aData, string aXsltDatoteka)
        {
            XmlSerializer ser = new XmlSerializer(aData.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            ser.Serialize(writer, aData);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());

            XsltSettings xslt_set = new XsltSettings();
            xslt_set.EnableScript = true;

            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load(aXsltDatoteka, xslt_set, new XmlUrlResolver());


            StringBuilder sb2 = new StringBuilder();
            StringWriter sw = new StringWriter(sb2);
            XmlTextWriter tw = new XmlTextWriter(sw);
            
            xct.Transform(doc, tw);
            string Vsebina = sb2.ToString();
            return Vsebina;
        }
        */
    }
}
