using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Net;
using System.Data.Objects.SqlClient;
using System.Data.SqlClient;
using System.Web.Helpers;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class UserInfoController : Controller
    {
        private ReportSupEntities1 db = new ReportSupEntities1();
     

        //
        // GET: /UserInfo/
        public ActionResult Index(string data)
        {
            string dept = "";
            string range = "";
            string[] dialog = { "" };
            var inicio = "";
            var fin = "";
           // string fecha =  "2015-09-4";
         //   List<horas> result3 = (from u in db.Userinfoes  select new horas { }).ToList();
      
      //      List<horas> test = (from u in db.TB_Info() select new horas { Name = u.Name, UserID = u.Userid, Genero = u.Sex, Deptid = u.Deptid, cardnum = u.Cardnum }).ToList();
           var query = Request.QueryString[""];
                //  if (dialog[0]! = "")
                //{
                try
                {
                    dialog[0] = Request.Form["selectDate"].ToString();
                    dept = Request.Form["deptid"].ToString();
                    range = Request.Form["daterange"].ToString();
                     inicio = range.Substring(0, 10);
                    Console.WriteLine(inicio);
                      fin = range.Substring(13, 10);
                    if (dialog[0] != "")
                    {
                        Session["selecdate"] = dialog[0];
                        }

                    if (dept != "")
                    {

                        Session["selectDept"] = dept;

                    }
                    if (range != "")
                    {
                        Session["inicio"] = inicio;
                        Session["fin"] = fin;
             
                    }  
         
                }
               catch
                { 
          //          List<CharmanderLaMeraPija> result4 = (from e in db.EmployesUnleash((string)(Session["selecdate"]), (string)(Session["selectDept"])) select new CharmanderLaMeraPija { Nombre = e.Name, Horas = e.horaTrabajada, FechaEntrada = e.horaEntrada, FechaSalida = e.horasalida }).ToList();

                }
           
                //  List<CharmanderLaMeraPija> result4 = (from e in db.EmployesUnleash(dialog[0], dept) select new CharmanderLaMeraPija { Nombre = e.Name, Horas = e.horaTrabajada, Fecha = e.horaEntrada }).ToList();
                     
          //         List<CharmanderLaMeraPija> result4 = (from e in db.EmployesUnleash((string)(Session["selecdate"]), (string)(Session["selectDept"])) select new CharmanderLaMeraPija { Nombre = e.Name, Horas = e.horaTrabajada, FechaEntrada = e.horaEntrada, FechaSalida = e.horasalida }).ToList();
//           return View(result4);
                List<CharmanderLaMeraPija> result5 = (from e in db.sp_dateRange((string)(Session["inicio"]), (string)(Session["fin"]), (string)(Session["selectDept"])) select new CharmanderLaMeraPija { Nombre = e.Name, Horas = e.horaTrabajada, FechaEntrada = e.horaEntrada, FechaSalida = e.horasalida }).ToList();
           
            return View(result5);

               
       

                //}

      
            

        }

        //
        // GET: /UserInfo/Search/date
        public FileStreamResult Pdf()
        {
            List<CharmanderLaMeraPija> all = new List<CharmanderLaMeraPija>();
            using (ReportSupEntities1 dc = new ReportSupEntities1())
            {
                all = (from e in dc.sp_dateRange((string)(Session["inicio"]), (string)(Session["fin"]), (string)(Session["selectDept"])) select new CharmanderLaMeraPija { Nombre = e.Name, Horas = e.horaTrabajada, FechaEntrada = e.horaEntrada, FechaSalida = e.horasalida }).ToList();

            }

            WebGrid grid = new WebGrid(source: all, canPage: false, canSort: false);
            string gridHtml  = grid.GetHtml(
                    columns: grid.Columns(
                               grid.Column("Nombre", "Nombre"),
            grid.Column("FechaEntrada", "Fecha de Entrada       "),
            grid.Column("FechaSalida", "Fecha de Salida                        "),
            grid.Column("Horas","Horas Trabajadas")
                        )
                    ).ToString();

            string exportData = String.Format("<html><head>{0}</head><body><div><span>Reporte</span></div>{1}</body></html>", "<style>table{ border-spacing: 10px; border-collapse: separate; }</style>", gridHtml);
            var bytes = System.Text.Encoding.UTF8.GetBytes(exportData);
            using (var input = new MemoryStream(bytes))
            {
                var output = new MemoryStream();
                var document = new iTextSharp.text.Document(PageSize.LETTER, 150, 150, 50, 50);
                var writer = PdfWriter.GetInstance(document, output);
                writer.CloseStream = false;
                document.Open();

                var xmlWorker = iTextSharp.tool.xml.XMLWorkerHelper.GetInstance();
                xmlWorker.ParseXHtml(writer, document, input, System.Text.Encoding.UTF8);
                document.Close();
                output.Position = 0;
              //  string path = this.Server.MapPath(".") + "Libraries\\Documents\\doc.pdf";

                //          return new FileStreamResult(output, "C:\application.pdf");
                return new FileStreamResult(output, "aplication/pdf")
                {
                    FileDownloadName = "Reporte" + Session["selecdate"].ToString() + ".pdf"
                };

            }
        }
  
        //
        // GET: /UserInfo/Details/5

        public ActionResult Details(bool id = false)
        {
            Userinfo userinfo = db.Userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // GET: /UserInfo/Create

        public ActionResult Create()
        {
        
            return View();
        }

        //
        // POST: /UserInfo/Create

        [HttpPost]
        public ActionResult Create(Userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Userinfoes.Add(userinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userinfo);
        }

        //
        // GET: /UserInfo/Edit/5

        public ActionResult Edit(bool id = false)
        {
            Userinfo userinfo = db.Userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // POST: /UserInfo/Edit/5

        [HttpPost]
        public ActionResult Edit(Userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userinfo);
        }

        //
        // GET: /UserInfo/Delete/5

        public ActionResult Delete(bool id = false)
        {
            Userinfo userinfo = db.Userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // POST: /UserInfo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(bool id)
        {
            Userinfo userinfo = db.Userinfoes.Find(id);
            db.Userinfoes.Remove(userinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public class CharmanderLaMeraPija {
            public string Nombre { get; set; }
            public DateTime? FechaEntrada { get; set; }
            public DateTime? FechaSalida { get; set; }
            public Decimal? Horas { get; set; }
            

        }

        public class horas {
            public string UserID { get; set; }
            public string Name { get; set; }
            public string Genero { get; set; }
            public int? Deptid { get; set; }
            public string  cardnum { get; set; }
            


        }


    }
}