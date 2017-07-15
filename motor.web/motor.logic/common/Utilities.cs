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
    public enum UserType
    {
        SuperAdmin=0,
        Supervisor = 1,
        Rider =2,
        Driver=3
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

        private static void SendEmail(string to, string body, string subject)
        {
            using (MailMessage mm = new MailMessage("SENDER@GMAIL.COM", to))
            {
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("SENDER@GMAIL.COM", "SENDERPASSWORD");
                //smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }

        public static void SendActivationEmail(string firstname, string lastname,string email,string activationUrl)
        {
            string subject = "Account activation";
            string body = "Hello " + firstname + ","+lastname;
            body += "<br /><br />Please click the following link to activate your account";
            body += "<br /><a href = '" + activationUrl + "'>Click here to activate your account.</a>";
            body += "<br /><br />Thanks";

            SendEmail(email, body, subject);
            
            
        }
    }
}
