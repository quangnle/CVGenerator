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
        private string _downloadUrl;
        private string _exportPath;
        private HtmlToPdfConverter _converter = null;
        private static PdfGenerator _instance = null;

        public PdfGenerator()
        {
            _exportPath = ConfigurationManager.AppSettings["CVPath"];
            _downloadUrl = ConfigurationManager.AppSettings["CVUrl"];
            _converter = new HtmlToPdfConverter();
        }

        public static PdfGenerator GetInstance()
        {
            if (_instance == null)
                _instance = new PdfGenerator();
            return _instance;
        }

        public string ConvertToPDF(string url, string output)
        {
            var fileName = _exportPath + "/" + output;
            _converter.GeneratePdfFromFile(url, null, output);

            return _downloadUrl + "/" + output;
        }
    }
}