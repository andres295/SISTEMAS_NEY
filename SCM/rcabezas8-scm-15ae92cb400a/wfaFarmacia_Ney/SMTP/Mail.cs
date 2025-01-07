using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SCM.SMTP
{
    class Mail
    {
        public void SendEmail(string addres,string emailEmisor,string usuario,string pasword, string Subject,string boddy,string numfactura,string claveAcceso, string rutaXMLSave)
        {
            MailMessage mail = new MailMessage(emailEmisor, addres);

            mail.From = new MailAddress(emailEmisor);
            mail.Subject = Subject;
            string Body = boddy;
            mail.IsBodyHtml = true;
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(usuario, pasword);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //// agrega el adjunto factura
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\" + numfactura + ".pdf"))
            {
                mail.Attachments.Add(new Attachment(System.IO.Directory.GetCurrentDirectory() + "\\" + numfactura + ".pdf"));
            }
            //// agrega el adjunto xml
            if (File.Exists(rutaXMLSave + "\\" + claveAcceso + "-Firmate.xml"))
            {
                mail.Attachments.Add(new Attachment(rutaXMLSave + "\\" + claveAcceso + "-Firmate.xml"));
            }
            smtp.Send(mail);
            mail.Attachments.Dispose();
            mail.Dispose();
            mail = null;
            /**Se elimina el archivo de la factura*/
            //// agrega el adjunto factura
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\" + numfactura + ".pdf"))
            {
                File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\" + numfactura + ".pdf");
            }
        }
    }
}
