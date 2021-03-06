﻿using CVGenerator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CVGenerator.Controllers.API
{
    public class UploadController : BaseApiController
    {
        [HttpPost]
        public HttpResponseMessage CvPhoto([FromBody]UploadViewModel model)
        {
            String uploadFolder = ConfigurationManager.AppSettings["PhotoUploadPath"];
            String path = HttpContext.Current.Server.MapPath("~/" + uploadFolder); //Path

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            string imageName = Guid.NewGuid() + ".jpg";

            string imgPath = Path.Combine(path, imageName);
            var stringContent = model.Content
                .Replace("data:image/jpeg;base64,", "")
                .Replace("data:image/png;base64,", "");
            byte[] imageBytes = Convert.FromBase64String(stringContent);

            File.WriteAllBytes(imgPath, imageBytes);

            var dataReturn = new
            {
                Photo = string.Format("/{0}/{1}", uploadFolder, imageName),
            };
            return Request.CreateResponse(HttpStatusCode.OK, dataReturn);
        }
    }
}
