using NReco.PdfGenerator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace CVGenerator.Utilities
{
    public class PdfGenerator
    {
        private string _exportPath;
        //private HtmlToPdfConverter _converter = null;
        private static PdfGenerator _instance = null;

        public PdfGenerator()
        {
            _exportPath = ConfigurationManager.AppSettings["CVPath"];
         //   _converter = new HtmlToPdfConverter();
        }

        public static PdfGenerator GetInstance()
        {
            if (_instance == null)
                _instance = new PdfGenerator();
            return _instance;
        }

        public void ConvertToPDF(string url, string output)
        {
            var _converter = new HtmlToPdfConverter();
            var fileName = "D:/" + _exportPath + "/" + output;
            //File.WriteAllText(fileName, "asdfsdf");

            _converter.GeneratePdfFromFile(url, null, fileName);
        }
    }
}