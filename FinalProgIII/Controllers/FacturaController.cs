using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using FinalProgIII.Models;

namespace FinalProgIII.Controllers
{
    public class FacturaController : Controller
    {
        DataBase db = new DataBase();

        // GET: Factura
        public ActionResult Index()
        {
            return View();
        }

        // GET: Factura/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            return View();
        }

        //public ActionResult FacturaPdf()
        //{
        //    var Juegos = GetViewModel();

        //    return new ViewAsPdf("Factura", Juegos);
        //}


        public ActionResult EnviarC ()
        {
            MailMessage msg = new MailMessage();

            string From = "wilmervasquez219@gmail.com";

            foreach (var item in db.Factura)
            {
                var To = item.Clientes.Email;

                msg.To.Add(new MailAddress(To));
                msg.From = new MailAddress(From, "Sistema de ventas");
                msg.Subject = "Factura Comercial";
                msg.Body = "Aquí anexamos la factura correspondiente a su compra";

                var actionPdf = new ActionAsPdf("RetornaPdf")
                {
                    FileName = "factura.pdf",
                    PageSize = Rotativa.Options.Size.Letter
                };

                byte[] PdfData = actionPdf.BuildPdf(ControllerContext);

                MemoryStream stream = new MemoryStream(PdfData);
                Attachment pdf = new Attachment(stream, "factura.pdf", "application/pdf");
                msg.Attachments.Add(pdf);
                msg.IsBodyHtml = true;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.SubjectEncoding = System.Text.Encoding.Default;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential inicioSesion = new NetworkCredential(From, "wilmer041198");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = inicioSesion;
                smtp.Port = 587;
                smtp.Send(msg);
            }
            ViewBag.Mensaje = "Mensaje enviado";
            return View();
        }


        // POST: Factura/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Factura/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Factura/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Factura/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
