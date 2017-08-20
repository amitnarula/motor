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
            string action = context.Request.QueryString["action"];
            string docType = context.Request.QueryString["type"];
            string documentId = context.Request.QueryString["docId"];
            string userId = context.Request.QueryString["userId"];

            if (string.IsNullOrEmpty(action))
                throw new ArgumentException("action");

            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";
            byte[] imageData = null;
            if (action == "doc")
            {
                if (string.IsNullOrEmpty(docType) || string.IsNullOrEmpty(documentId))
                {
                    throw new ArgumentNullException("docType || docId");
                }
                var type = (DocumentType)Enum.Parse(typeof(DocumentType), docType);
                imageData = userSvc.GetDocumentImage(type, Convert.ToInt64(documentId));
            }
            else if (action == "pp")
            {
                if (string.IsNullOrEmpty(userId))
                {
                    throw new ArgumentNullException("userId");
                }
                imageData = userSvc.GetProfileImage(Convert.ToInt64(userId));
            }
            
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