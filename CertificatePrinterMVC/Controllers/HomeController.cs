using CertificatePrinterMVC.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CertificatePrinterMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FillDocument(FormCollection form)
        {
            // Get form data
            string name = form["Name"];
            string email = form["Email"];

            // Path to the Word document template
            string templatePath = Server.MapPath("~/Content/FormTemplate.docx");

            // Path to save the filled document
            string outputPath = Server.MapPath("~/Content/FilledDocument.docx");

            // Fill the document
            using (WordprocessingDocument doc = WordprocessingDocument.Open(templatePath, true))
            {
                var mainPart = doc.MainDocumentPart;

                // Replace the content controls with form data
                foreach (var cc in mainPart.Document.Descendants<SdtElement>())
                {
                    var sdtAlias = cc.Descendants<SdtAlias>().FirstOrDefault();
                    if (sdtAlias != null)
                    {
                        string alias = sdtAlias.Val.Value;
                        switch (alias)
                        {
                            case "NameField":
                                cc.Descendants<Text>().First().Text = name;
                                break;
                            case "EmailField":
                                cc.Descendants<Text>().First().Text = email;
                                break;
                                // Add cases for other form fields if needed
                        }
                    }
                }

                // Save the filled document
                doc.Save();
            }

            // Return the filled document for download
            byte[] fileBytes = System.IO.File.ReadAllBytes(outputPath);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "FilledDocument.docx");
        }

    }
}