using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Script.Serialization;
using MongoDB.Driver;
using MongoDB.Bson;
using MvcApplication2.Models;
using MvcApplication2.Controllers;
using Mandrill;

namespace MvcApplication2.Controllers
{
    public class CustomSaveController : Controller
    {
        private ReportSupEntities1 db = new ReportSupEntities1();



        public ActionResult Index()
        {
            List<test> all = new List<test>();

            /*
            using (ReportSupEntities dc = new ReportSupEntities())
            {
                all = (from e in dc.sp_dateRange("2015 - 08 - 01", "2015 - 08 - 29", " 2") select new test { Nombre = e.Name, Horas = e.horaTrabajada, FechaEntrada = e.horaEntrada, FechaSalida = e.horasalida }).ToList();

            }

            WebGrid grid = new WebGrid(source: all, canPage: false, canSort: false);
            string gridHtml ="show the content in grid format using web grid and foreach ".ToString();

            string exportData = String.Format("<html><head>{0}</head><body><div><span>Reporte</span></div>{1}</body></html>", "<style>table{ border-spacing: 10px; border-collapse: separate; }</style>", gridHtml);
            var bytes = System.Text.Encoding.UTF8.GetBytes(exportData);
            using (var input = new MemoryStream(bytes))
            {
                var output = new MemoryStream();
                var document = new iTextSharp.text.Document(PageSize.A4, 150, 150, 50, 50);
                var writer = PdfWriter.GetInstance(document, output);
                writer.CloseStream = false;
                document.Open();

                var xmlWorker = iTextSharp.tool.xml.XMLWorkerHelper.GetInstance();
                xmlWorker.ParseXHtml(writer, document, input, System.Text.Encoding.UTF8);
                document.Close();
                output.Position = 0;
                string path = this.Server.MapPath(".") + "Libraries\\Documents\\doc.pdf";

                //          return new FileStreamResult(output, "C:\application.pdf");
                return new FileStreamResult(output, "aplication/pdf")
                {
                    FileDownloadName = "PDFPERFORMACE"
                };
            }
             */

            //   List<test> info = (from e in db.sp_dateRange("2015 - 08 - 01", "2015 - 08 - 07", " 2") select new test { Nombre = e.Name, FechaEntradaMonday = e.horaTrabajad, FechaEntrada = e.horaEntrada, FechaSalida = e.horasalida }).ToList();
            //all = (from e in db.sp_matrix_weekdays(1, "02-02-2015") select new test { Nombre = e.name, FechaEntradaMonday = e.Hora_de_LLegada_Lunes, FechaSalidaMonday = e.Hora_de_salida_Lunes, HorasMonday = e.Monday, FechaEntradaTuesday = e.Hora_de_LLegada_Martes, FechaSalidaTuesday = e.Hora_de_salida_Martes, HorasTuesday = e.Tuesday, FechaEntradaWendnsday = e.Hora_de_LLegada_Miercoles, FechaSalidaWendnsday = e.Hora_de_salida_Miercoles, HorasWendnsday = e.Wednsday, FechaEntradaThursday = e.Hora_de_LLegada_Jueves, FechaSalidaThursday = e.Hora_de_salida_Jueves, HorasThursday = e.Thursday, FechaEntradaFriday = e.Hora_de_LLegada_Viernes, FechaSalidaFriday = e.Hora_de_salida_Viernes, HorasFriday = e.Friday, FechaEntradaSaturday = e.Hora_de_LLegada_Sabado, FechaSalidaSaturday = e.Hora_de_salida_Sabado, HorasSaturday = e.Saturday, FechaEntradaSunday = e.Hora_de_LLegada_Domingo, FechaSalidaSunday = e.Hora_de_salida_Domingo, HorasSunday = e.Sunday }).ToList();
            core();
            return View(all);


        }

        public class test
        {
            public string Nombre { get; set; }
            public DateTime? FechaEntradaMonday { get; set; }
            public DateTime? FechaEntradaTuesday { get; set; }
            public DateTime? FechaEntradaWendnsday { get; set; }
            public DateTime? FechaEntradaThursday { get; set; }
            public DateTime? FechaEntradaFriday { get; set; }
            public DateTime? FechaEntradaSaturday { get; set; }
            public DateTime? FechaEntradaSunday { get; set; }
            public DateTime? FechaSalidaMonday { get; set; }
            public DateTime? FechaSalidaTuesday { get; set; }
            public DateTime? FechaSalidaWendnsday { get; set; }
            public DateTime? FechaSalidaThursday { get; set; }
            public DateTime? FechaSalidaFriday { get; set; }
            public DateTime? FechaSalidaSaturday { get; set; }
            public DateTime? FechaSalidaSunday { get; set; }
            public Decimal? HorasMonday { get; set; }
            public Decimal? HorasTuesday { get; set; }
            public Decimal? HorasWendnsday { get; set; }
            public Decimal? HorasThursday { get; set; }
            public Decimal? HorasFriday { get; set; }
            public Decimal? HorasSaturday { get; set; }
            public Decimal? HorasSunday { get; set; }
        }
        public FileStreamResult GETPdf()
        {


            List<test> all = new List<test>();
            //  item1 = Session["selecdate"].ToString();
            //  Console.Write(item1);
            using (ReportSupEntities1 dc = new ReportSupEntities1())
            {
                //   all = (from e in dc).ToList();
                all = (from e in dc.sp_matrix_weekdays(15, "08 - 17 - 2015") select new test { Nombre = e.name, FechaEntradaMonday = e.Hora_de_LLegada_Lunes, FechaSalidaMonday = e.Hora_de_salida_Lunes, HorasMonday = e.Monday, FechaEntradaTuesday = e.Hora_de_LLegada_Martes, FechaSalidaTuesday = e.Hora_de_salida_Martes, HorasTuesday = e.Tuesday, FechaEntradaWendnsday = e.Hora_de_LLegada_Miercoles, FechaSalidaWendnsday = e.Hora_de_salida_Miercoles, HorasWendnsday = e.Wednsday, FechaEntradaThursday = e.Hora_de_LLegada_Jueves, FechaSalidaThursday = e.Hora_de_salida_Jueves, HorasThursday = e.Thursday, FechaEntradaFriday = e.Hora_de_LLegada_Viernes, FechaSalidaFriday = e.Hora_de_salida_Viernes, HorasFriday = e.Friday, FechaEntradaSaturday = e.Hora_de_LLegada_Sabado, FechaSalidaSaturday = e.Hora_de_salida_Sabado, HorasSaturday = e.Saturday, FechaEntradaSunday = e.Hora_de_LLegada_Domingo, FechaSalidaSunday = e.Hora_de_salida_Domingo, HorasSunday = e.Sunday }).ToList();
            }

            WebGrid grid = new WebGrid(source: all, canPage: false, canSort: false);
            string gridHtml = grid.GetHtml(
        columns: grid.Columns(
        grid.Column("Nombre", "Nombre", canSort: true, style: "name"),
                         grid.Column("FechaEntradaMonday", "Fecha de Entrada LUNES"),
            grid.Column("FechaSalidaMonday", "Fecha de Salida"),
                            grid.Column("HorasMonday", "Horas Trabajadas Lunes"),
                         grid.Column("FechaEntradaTuesday", "Fecha de Entrada MARTES"),
            grid.Column("FechaSalidaTuesday", "Fecha de Salida"),
                          grid.Column("HorasTuesday", "Horas Trabajadas Martes"),
                         grid.Column("FechaEntradaWendnsday", "Fecha de Entrada MIERCOLES"),
            grid.Column("FechaSalidaWendnsday", "Fecha de Salida"),
                          grid.Column("HorasWendnsday", "Horas Trabajadas Miertcoles"),
                         grid.Column("FechaEntradaThursday", "Fecha de JUEVES"),
            grid.Column("FechaSalidaThursday", "Fecha de Salida"),
                        grid.Column("HorasThursday", "Horas Trabajadas Jueves"),
                        grid.Column("FechaEntradaFriday", "Fecha de Entrada VIERNES"),
            grid.Column("FechaSalidaFriday", "Fecha de Salida"),
                        grid.Column("HorasFriday", "Horas Trabajadas Viernes"),
                         grid.Column("FechaEntradaSaturday", "Fecha de Sabado"),
            grid.Column("FechaSalidaSaturday", "Fecha de Salida"),
                         grid.Column("HorasSaturday", "Horas Trabajadas Sabado"),
                         grid.Column("FechaEntradaSunday", "Fecha de DOMINGO"),
            grid.Column("FechaSalidaSunday", "Fecha de Salida")
              )
                ).ToHtmlString();

            string exportData = String.Format("<html><head>{0}</head><body><div><span>Reporte</span></div>{1}</body></html>", "<style>table{ border-spacing: 1000px; border-collapse: separate; .name {width: 550px;} }</style>", gridHtml);
            var bytes = System.Text.Encoding.UTF8.GetBytes(exportData);
            using (var input = new MemoryStream(bytes))
            {
                var output = new MemoryStream();
                var document = new iTextSharp.text.Document(PageSize.A0, 50, 50, 25, 50);
                var writer = PdfWriter.GetInstance(document, output);
                writer.CloseStream = false;
                document.Open();

                var xmlWorker = iTextSharp.tool.xml.XMLWorkerHelper.GetInstance();
                xmlWorker.ParseXHtml(writer, document, input, System.Text.Encoding.UTF8);
                document.Close();
                output.Position = 0;
                string path = this.Server.MapPath(".") + "Libraries\\Documents\\doc.pdf";

                //        return new FileStreamResult(output, "C:\application.pdf");
                return new FileStreamResult(output, "aplication/pdf")
                {
                    FileDownloadName = "PDFPERFORMACE" + ".pdf"
                };
            }


        }

        public FileStreamResult GETTABLE()
        {
            var output = new MemoryStream();
            List<test> all = new List<test>();
            //  item1 = Session["selecdate"].ToString();
            //  Console.Write(item1);
            using (ReportSupEntities1 dc = new ReportSupEntities1())
            {
                //   all = (from e in dc).ToList();

                Server.ScriptTimeout = 400;
                all = (from e in dc.sp_matrix_weekdays(22, "08 - 17 - 2015") select new test { Nombre = e.name, FechaEntradaMonday = e.Hora_de_LLegada_Lunes, FechaSalidaMonday = e.Hora_de_salida_Lunes, HorasMonday = e.Monday, FechaEntradaTuesday = e.Hora_de_LLegada_Martes, FechaSalidaTuesday = e.Hora_de_salida_Martes, HorasTuesday = e.Tuesday, FechaEntradaWendnsday = e.Hora_de_LLegada_Miercoles, FechaSalidaWendnsday = e.Hora_de_salida_Miercoles, HorasWendnsday = e.Wednsday, FechaEntradaThursday = e.Hora_de_LLegada_Jueves, FechaSalidaThursday = e.Hora_de_salida_Jueves, HorasThursday = e.Thursday, FechaEntradaFriday = e.Hora_de_LLegada_Viernes, FechaSalidaFriday = e.Hora_de_salida_Viernes, HorasFriday = e.Friday, FechaEntradaSaturday = e.Hora_de_LLegada_Sabado, FechaSalidaSaturday = e.Hora_de_salida_Sabado, HorasSaturday = e.Saturday, FechaEntradaSunday = e.Hora_de_LLegada_Domingo, FechaSalidaSunday = e.Hora_de_salida_Domingo, HorasSunday = e.Sunday }).ToList();
            }
            Document doc = new Document();
            PdfPTable table = new PdfPTable(4);
            table.TotalWidth = 440f;
            table.LockedWidth = true;
            float[] widths = new float[] { 30f, 160f, 120f, 70f };
            table.SetWidths(widths);
            Document document = new Document(PageSize.A4, 5, 5, 15, 15);
            //    PdfWriter.GetInstance(document, new FileStream(HttpContext.Server.MapPath("~/Files/doc.pdf"), FileMode.Create));
            var writer = PdfWriter.GetInstance(document, output);
            document.Open();
            PdfPCell cell = new PdfPCell();
            foreach (var item in all)
            {
                cell = new PdfPCell(new Phrase("  "));
                cell.Colspan = 4;
                cell.BackgroundColor = new BaseColor(220, 237, 191);
                cell.HorizontalAlignment = 0;
                cell.PaddingBottom = 5f;
                cell.PaddingLeft = 5f;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Name: " + item.Nombre));
                cell.Colspan = 2;
                cell.BackgroundColor = new BaseColor(135, 196, 28);
                cell.HorizontalAlignment = 0;
                cell.PaddingBottom = 5f;
                cell.PaddingLeft = 5f;
                table.AddCell(cell);

                //album info
                cell = new PdfPCell(new Phrase("Album: " + item.FechaEntradaMonday));
                cell.HorizontalAlignment = 2;
                cell.Colspan = 2;
                cell.BackgroundColor = new BaseColor(135, 196, 28);
                cell.PaddingBottom = 5f;
                cell.PaddingLeft = 5f;
                table.AddCell(cell);



            }
            document.Add(table);
            document.Close();
            return new FileStreamResult(output, "aplication/pdf")
            {
                FileDownloadName = "PDFPERFORMACE" + ".pdf"
            };
        }

        public class WorkingPerDay
        {
            public string Name { get; set; }
            public DateTime? HourInput { get; set; }
            public DateTime? HourOutput { get; set; }
            public Decimal? workingHours { get; set; }
        }

        public void PDF(string beginDate, string dept_ID, string dept_name, string monday)
        {

            List<test> all = new List<test>();
            List<WorkingPerDay> WorkingHoursPerDay = new List<WorkingPerDay>();
            Array recordweek = new Array[6];

            //  DateTime newdate = DateTime.Parse(monday);

            Document document = new Document(PageSize.A1, 5, 5, 15, 15);
            string filepath = @"C:\\Users\\rcalix\\Documents\\Report_" + dept_name + "_" + monday + ".pdf";
            if ((!System.IO.File.Exists(filepath)))
            {
                using (FileStream output = new FileStream((filepath), FileMode.Create))
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(document, output))
                    {


                        document.Open();
                        PdfPTable table = new PdfPTable(24);
                        table.TotalWidth = 5000f;
                        float[] widths = new float[] { 1300f, 1300, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f, 1300f };
                        table.SetWidths(widths);
                        PdfPCell cell = new PdfPCell();
                        PdfPCell cellName = new PdfPCell();
                        Array[] list = { };
                        iTextSharp.text.Font georgia = FontFactory.GetFont("georgia", 14f);
                        georgia.Color = iTextSharp.text.BaseColor.BLUE;
                        string begindate = "09-14-2015";
                        try
                        {
                            var init = Convert.ToInt32(dept_ID.ToString());
                            using (ReportSupEntities1 dc = new ReportSupEntities1())
                            {
                                //   all = (from e in dc).ToList();

                                all = (from e in dc.sp_matrix_weekdays(init, begindate) select new test { Nombre = e.name, FechaEntradaMonday = e.Hora_de_LLegada_Lunes, FechaSalidaMonday = e.Hora_de_salida_Lunes, HorasMonday = e.Monday, FechaEntradaTuesday = e.Hora_de_LLegada_Martes, FechaSalidaTuesday = e.Hora_de_salida_Martes, HorasTuesday = e.Tuesday, FechaEntradaWendnsday = e.Hora_de_LLegada_Miercoles, FechaSalidaWendnsday = e.Hora_de_salida_Miercoles, HorasWendnsday = e.Wednsday, FechaEntradaThursday = e.Hora_de_LLegada_Jueves, FechaSalidaThursday = e.Hora_de_salida_Jueves, HorasThursday = e.Thursday, FechaEntradaFriday = e.Hora_de_LLegada_Viernes, FechaSalidaFriday = e.Hora_de_salida_Viernes, HorasFriday = e.Friday, FechaEntradaSaturday = e.Hora_de_LLegada_Sabado, FechaSalidaSaturday = e.Hora_de_salida_Sabado, HorasSaturday = e.Saturday, FechaEntradaSunday = e.Hora_de_LLegada_Domingo, FechaSalidaSunday = e.Hora_de_salida_Domingo, HorasSunday = e.Sunday }).ToList();
                                //    WorkingHoursPerDay = (from i in dc.sp_GetWorkingHoursPerDay(1, Convert.ToDateTime("08-13-2015").AddDays(w)) select new WorkingPerDay { Name = i.Name, HourInput = i.horaEntrada, HourOutput = i.horasalida, workingHours = Convert.ToInt32(i.horaTrabajada) }).ToList();
                                //     list[w] = WorkingHoursPerDay.ToList().ToArray();
                            }
                            DateTime date = Convert.ToDateTime(begindate);

                            //PdfPCell june = new PdfPCell(new Phrase("Cell 2",georgia));





                            PdfPCell nombre = new PdfPCell(new Phrase("Name"));

                            nombre.Rowspan = 2;
                            nombre.Colspan = 2;
                            nombre.HorizontalAlignment = 1;
                            nombre.VerticalAlignment = 0;
                            table.AddCell(nombre);

                            PdfPCell june = new PdfPCell(new Phrase("Moday :" + Convert.ToDateTime(date).ToShortDateString().ToString(), georgia));
                            june.HorizontalAlignment = 1;
                            june.Colspan = 3;
                            table.AddCell(june);
                            june = new PdfPCell(new Phrase("Tuesday :" + Convert.ToDateTime(date).AddDays(1).ToShortDateString(), georgia));

                            june.HorizontalAlignment = 1;
                            june.Colspan = 3;
                            table.AddCell(june);
                            june = new PdfPCell(new Phrase("Wednsday :" + Convert.ToDateTime(date).AddDays(2).ToShortDateString(), georgia));

                            june.HorizontalAlignment = 1;
                            june.Colspan = 3;
                            table.AddCell(june);
                            june = new PdfPCell(new Phrase("Thursday :" + Convert.ToDateTime(date).AddDays(3).ToShortDateString(), georgia));

                            june.HorizontalAlignment = 1;
                            june.Colspan = 3;
                            table.AddCell(june);

                            june = new PdfPCell(new Phrase("Friday :" + Convert.ToDateTime(date).AddDays(4).ToShortDateString(), georgia));

                            june.HorizontalAlignment = 1;
                            june.Colspan = 3;
                            table.AddCell(june);


                            june = new PdfPCell(new Phrase("Saturday :" + Convert.ToDateTime(date).AddDays(5).ToShortDateString(), georgia));

                            june.HorizontalAlignment = 1;
                            june.Colspan = 3;
                            table.AddCell(june);
                            june = new PdfPCell(new Phrase("Sunday :" + Convert.ToDateTime(date).AddDays(6).ToShortDateString(), georgia));

                            june.HorizontalAlignment = 1;
                            june.Colspan = 3;
                            table.AddCell(june);

                            june = new PdfPCell(new Phrase("             "));

                            june.HorizontalAlignment = 1;
                            june.Colspan = 3;
                            table.AddCell(june);




                            PdfPCell second = new PdfPCell();
                            for (var i = 0; i <= 6; i++)
                            {
                                second = new PdfPCell(new Phrase("In"));
                                second.HorizontalAlignment = 1;
                                table.AddCell(second);

                                second = new PdfPCell(new Phrase("Out"));
                                second.HorizontalAlignment = 1;
                                table.AddCell(second);

                                second = new PdfPCell(new Phrase("Worked Hours"));
                                second.HorizontalAlignment = 1;
                                table.AddCell(second);


                            }
                            second = new PdfPCell(new Phrase("Weekly Hours Worked"));
                            second.HorizontalAlignment = 1;
                            table.AddCell(second);





                            foreach (var item in all)
                            {

                                cellName.Phrase = new Phrase(item.Nombre);
                                cellName.HorizontalAlignment = 1;
                                cellName.Colspan = 2;
                                table.AddCell(cellName);

                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaEntradaMonday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);


                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaSalidaMonday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase((item.HorasMonday).ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaEntradaTuesday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);


                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaSalidaTuesday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase((item.HorasTuesday).ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaEntradaWendnsday).ToShortTimeString().ToString());

                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);


                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaSalidaWendnsday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase((item.HorasWendnsday).ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);


                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaEntradaThursday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);


                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaSalidaThursday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase((item.HorasThursday).ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaEntradaFriday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);


                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaSalidaFriday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase((item.HorasFriday).ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaEntradaSaturday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);


                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaSalidaSaturday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase((item.HorasSaturday).ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaEntradaSunday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);


                                cell.Phrase = new Phrase(Convert.ToDateTime(item.FechaSalidaSunday).ToShortTimeString().ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                cell.Phrase = new Phrase((item.HorasSunday).ToString());
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);
                                // DateTime d1 = DateTime.Parse(Convert.ToDateTime(item.HorasMonday).ToString());
                                //DateTime d2 = DateTime.Parse(Convert.ToDateTime(item.HorasMonday).ToString());
                                //   double span = (d1 - d2).TotalHours;
                                cell.Phrase = new Phrase(Convert.ToString(Convert.ToDecimal(item.HorasMonday) + Convert.ToDecimal(item.HorasTuesday) + Convert.ToDecimal(item.HorasWendnsday) + Convert.ToDecimal(item.HorasThursday) + Convert.ToDecimal(item.HorasFriday) + Convert.ToDecimal(item.HorasSaturday) + Convert.ToDecimal(item.HorasSunday)));
                                cell.HorizontalAlignment = 1;
                                table.AddCell(cell);

                                //table.Rows.Add(cell);
                                //                 

                            }






                            //            document.Add(table);

                            document.Add(table);
                            document.Close();
                            document.Dispose();
                            writer.Close();
                            output.Close();

                        }

                        catch (Exception)
                        {

                        }
                        //  DateTime date =Convert.ToDateTime(Convert.ToDateTime("09-21-2015")).ToShortDateString();

                    }
                }
                //  var output = new MemoryStream();
            }
        }
        public void sendEmail(string monday, string name, string dept_name)
        {

            //   Thread.Sleep(120000);
            /*
                MailMessage message = new MailMessage(from, to);
               string mailbody = "Hello " + name +" this is your Report for today Pleease enjoy "+dept_name;
               message.Subject = "Sending " + name + " Email with Repor By Char ;) "+dept_name;
               message.Body = mailbody;
               message.BodyEncoding = Encoding.UTF8;
               message.IsBodyHtml = true; //~/Pdf/Report_Architecture1" + monday + ".pdf"
               message.Attachments.Add(new Attachment((@"C:\\Users\\rcalix\\Documents\\pdfReport_" + dept_name + "_" + monday + ".pdf"), "aplication/pdf"));

               //  message.Attachments.Add(new Attachment(Server.MapPath("~/Pdf/Report_"+dept_name+"_" + monday + ".pdf"), "aplication/pdf"));
               SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Gmail smtp    
               System.Net.NetworkCredential basicCredential1 = new
               System.Net.NetworkCredential("ramon.calix@laureate.net", "Laureate1234$");
               client.EnableSsl = true;
               client.UseDefaultCredentials = false;
               client.Credentials = basicCredential1;
               try
               {
                   client.Send(message);
               }

               catch (Exception ex)
               {
                   throw ex;
             * 
               }*/

            string to = "rayelmejor1@gmail.com"; //To address    
                                                 //     string from = "ramon.calix@laureate.net"; //From address    
            string subject = "Sending " + name + " Email with Repor By Char ;) " + dept_name;
            string mailbody = "Hello " + name + " this is your Report for today Pleease enjoy " + dept_name;

            Attachment att = new Attachment(@"C:\\Users\\rcalix\\Documents\\Report_" + dept_name + "_" + monday + ".pdf");
            MailMessage mail = new MailMessage("no-reply@laureate.net", to, subject, mailbody);
            mail.IsBodyHtml = true;
            mail.SubjectEncoding = Encoding.Default;
            mail.BodyEncoding = Encoding.UTF8;
            mail.Attachments.Add(att);

            SmtpClient client = new SmtpClient();

            //HOST AND PORT                
            client.Host = "smtp.mandrillapp.com";
            client.Port = int.Parse("587");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            //YOUR EMAIL CREDENTIALS FOR TESTING
            client.Credentials = new NetworkCredential("raul.rivera@laureate.net", "RZJh8n9hVJjboJlsDCJ9HQ");

            client.Send(mail);

        }
        public class boos
        {
            public string name { get; set; }
            public string correo { get; set; }
            public string departamento { get; set; }
            public string subdept { get; set; }
            public string deptID { get; set; }
        }
        public void core()
        {
            DateTime day = DateTime.Today;
            int offset = day.DayOfWeek - DayOfWeek.Monday;
            DateTime lastmonday = Convert.ToDateTime(day.AddDays(-offset - 7));
            string monday = lastmonday.ToString("dd-MM-yyyy");

            var client = new MongoClient();
            var db = client.GetDatabase("admin");
            var collection = db.GetCollection<infoDept>("managers");
            var document = db.GetCollection<Getreport>("managers");
            var leads = from l in document.AsQueryable<Getreport>()
                        select l.deptID;

            var test = from d in collection.AsQueryable<infoDept>()
                       select d.Id_Dept;
            foreach (var items in test)
            {
                var managers = collection
                      .Find(a => a.Id_Dept == items)
                      .ToListAsync()
                       .Result;
                foreach (var i in managers)
                {
                    string[] sub_managers = i.Name;
                    for (int y = 0; y < sub_managers.Length; y++)
                    {
                        string nombre = i.Name[y];
                        if (sub_managers.Length > 1)
                        {
                            List<Getreport> get = new List<Getreport>(i.GetReport);
                            foreach (var sub in get)
                            {
                                //    Thread.Sleep(120000);
                                PDF(monday, sub.deptID, sub.subdept, monday);
                                sendEmail(monday, sub.subName, sub.subdept);
                            }
                        }
                        else
                        {
                            //    Thread.Sleep(120000);
                            List<Getreport> get = new List<Getreport>(i.GetReport);
                            foreach (var sub in get)
                            {
                                PDF(monday, sub.deptID, sub.subdept, monday);
                                sendEmail(monday, nombre, sub.subdept);
                            }
                            /// sendEmail(monday, nombre, i.Nombre_Dept);
                        }
                        PDF(monday, i.Id_Dept, i.Nombre_Dept, monday);
                        sendEmail(monday, nombre, i.Nombre_Dept);
                    }

                }
            }

        }


        public class infoDept
        {
            public ObjectId Id { get; set; }
            public string Nombre_Dept { get; set; }
            public string[] Name { get; set; }
            public string[] correo { get; set; }
            public string Id_Dept { get; set; }
            public Getreport[] GetReport { get; set; }
        }

        public class Getreport
        {
            public ObjectId Id { get; set; }
            public string subdept { get; set; }
            public string deptID { get; set; }
            public string subEmail { get; set; }
            public string subName { get; set; }
        }
    }

}


