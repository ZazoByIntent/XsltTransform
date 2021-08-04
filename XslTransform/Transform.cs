using System;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XslTransform
{
    public class Transform
    {        
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

        #region GenericTransform

        public string VrniDokument<T>(List<T> aEntitetaCollection, string aXsltDatoteka)
        {
            StringWriter stringWriter = new StringWriter();
            new XmlSerializer(typeof(List<T>)).Serialize(stringWriter, aEntitetaCollection);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(stringWriter.GetStringBuilder().ToString());
            return new Transform().VrniHtmlDokument(xmlDocument, aXsltDatoteka);
        }

        private string VrniHtmlDokument(XmlDocument xmlDocument, string aXsltDatoteka)
        {
            using (var stringWriter = new StringWriter())
            {
                XslCompiledTransform xct = new XslCompiledTransform();
                xct.Load(aXsltDatoteka, new XsltSettings(false, true), new XmlUrlResolver());
                xct.Transform(xmlDocument, new XmlTextWriter(stringWriter));
                return stringWriter.GetStringBuilder().ToString();
            }
        }

        #endregion


        // public static string ImenikXslt = HttpContext.Current.Request.PhysicalApplicationPath + "Reports\\";
        // string path = SessionHandler.ImenikXslt + KonstanteWEB.DOC_INSTALACIJE_NAROCILA_DOGODKI;

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
