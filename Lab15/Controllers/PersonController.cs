﻿using Lab15.Models;
using Microsoft.Reporting.WebForms;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lab15.Controllers
{
    public class PersonController : Controller
    {
        #region
        //ATRIBUTO CONTEXTO
        private SchoolEntities _contexto;

        //PROPIEDAD CONTEXTO
        public SchoolEntities Contexto
        {
            set { _contexto = value; }
            get
            {
                if (_contexto == null)
                    _contexto = new SchoolEntities();
                return _contexto;
            }
        }
        #endregion

        // GET: Person
        public ActionResult Index()
        {
            return View(Contexto.Person.ToList());
        }

        public ActionResult Reporte()
        {
            List<Person> listado = new List<Person>();
            listado = Contexto.Person.ToList();

            var rptviewer = new ReportViewer();
            rptviewer.ProcessingMode = ProcessingMode.Local;
            rptviewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Report.rdlc";

            ReportDataSource rptdatasource = new ReportDataSource("dsPersona", listado);
            rptviewer.LocalReport.DataSources.Add(rptdatasource);
            rptviewer.SizeToReportContent = true;

            ViewBag.ReportViewer = rptviewer;
            return View();
        }

        [HttpPost]
        public ActionResult Reporte(string FirstName)
        {
            List<Person> listado = new List<Person>();
            listado = (from p in Contexto.Person
                       where p.FirstName.Contains(FirstName)
                       select p).ToList();

            var rptviewer = new ReportViewer();
            rptviewer.ProcessingMode = ProcessingMode.Local;
            rptviewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) +
                @"Report.rdlc";
            ReportDataSource rptdatasurce = new ReportDataSource("dsPersona", listado);
            rptviewer.LocalReport.DataSources.Add(rptdatasurce);
            rptviewer.SizeToReportContent = true;

            ViewBag.ReportViewer = rptviewer;
            return View();
        }
    }
}