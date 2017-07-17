using motor.logic.common;
using motor.logic.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace motor.web
{
    /// <summary>
    /// Summary description for image
    /// </summary>
    public class image : IHttpHandler
    {
        UserService userSvc = new UserService();

        public void ProcessRequest(HttpContext context)
        {
            string docType = context.Request.QueryString["type"];
            string documentId = context.Request.QueryString["docId"];

            if (string.IsNullOrEmpty(docType) || string.IsNullOrEmpty(documentId))
                throw new ArgumentNullException();

            var type = (DocumentType)Enum.Parse(typeof(DocumentType), docType);

            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";
            var imageData = userSvc.GetDocumentImage(type, Convert.ToInt64(documentId));
            if (imageData != null)
                context.Response.BinaryWrite(imageData);

            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}