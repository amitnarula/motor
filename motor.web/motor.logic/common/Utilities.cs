using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace motor.logic.common
{
    public enum EmailTemplate
    {
        UserActivation,
        DocumentsReceived,
        DocumentsUploadedByDriver,
        DocumentsVerified,
        DocumentsRejected,
        ScheduleAnInterview
    }
    public enum EmailTemplateParams
    {
        ActivationUrl,
        InterviewDate
    }

    public enum UserType
    {
        SuperAdmin = 0,
        Supervisor = 1,
        Rider = 2,
        Driver = 3
    }

    public enum DocumentType
    {
        VehicleImage1,
        VehicleImage2,
        LicenseImage
    }

    public enum DocumentStatus
    {
        Pending,
        Verified,
        InterviewScheduled,
        Rejected
    }

    public class CommonUtils
    {
        public static string EncryptParameter(string stringValue)
        {
            byte[] stringByteArray = System.Text.Encoding.UTF8.GetBytes(stringValue);
            return Convert.ToBase64String(stringByteArray);
        }

        public static string DecryptParameter(string encryptedValue)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(encryptedValue);
            return System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private static void SetEmailSubjectAndBody(EmailTemplate template, string firstName, string lastName, out string subject, out string emailBody)
        {
            subject = "A general subject";
            emailBody = "Hello " + firstName + "," + firstName + "<br/><br/>";
            switch (template)
            {
                case EmailTemplate.UserActivation:
                    subject = "Account activation";
                    emailBody += "Please click the following link to activate your account";
                    emailBody += "<br /><a href = '#" + EmailTemplateParams.ActivationUrl.ToString() + "#'>Click here to activate your account.</a>";
                    emailBody += "<br /><br />Thanks";
                    break;
                case EmailTemplate.DocumentsReceived:
                    subject = "Documents received";
                    emailBody += "Thanks for your interest. We have received your documents and we will contact you shortly for further process.";
                    break;
                case EmailTemplate.DocumentsVerified:
                    subject = "Document verification successful and completed";
                    emailBody += "Congratulations, your document verification has been completed. We will keep you posted.";
                    break;
                case EmailTemplate.DocumentsRejected:
                    subject = "Document verification failed and rejected";
                    emailBody += "Unfortunately your document verification has been failed and rejected by the administrator.";
                    break;
                case EmailTemplate.ScheduleAnInterview:
                    subject = "Interview scheduled";
                    emailBody += "Your interview has been scheduled at #" + EmailTemplateParams.InterviewDate.ToString() + "#.";
                    break;
                case EmailTemplate.DocumentsUploadedByDriver:
                    subject = "Documents uploaded by driver";
                    emailBody = "Hello Administrator, a driver has uploaded his information on the portal.";
                    emailBody += "<br/><br/>Driver info name:" + firstName + "," + firstName;
                    break;
                default:
                    break;
            }
            emailBody += "<br/><br/>Thanks<br/>Administrator";

        }

        private static void SendEmail(string to, string body, string subject)
        {
            using (MailMessage mm = new MailMessage("admin@GMAIL.COM", to))
            {
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("admin@GMAIL.COM", "adminpassword");
                //smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                Object state = mm;
               smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
                try
                {
                    smtp.Send(mm);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        
        public static void SendEmail(EmailTemplate template, string to, string firstName, string lastName, Dictionary<string, string> parameters = null)
        {
            string subject = string.Empty;
            string emailBody = string.Empty;

            SetEmailSubjectAndBody(template, firstName, lastName, out subject, out emailBody);

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    emailBody = emailBody.Replace("#" + item.Key + "#", item.Value);
                }
            }

            SendEmail(to, emailBody, subject);

            if (template == EmailTemplate.DocumentsReceived)
            {
                SetEmailSubjectAndBody(EmailTemplate.DocumentsUploadedByDriver, firstName, lastName, out subject, out emailBody);
                SendEmail("admin@gmail.com", emailBody, subject);
            }
        }
        static void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MailMessage mail = e.UserState as MailMessage;

        }

    }

}

