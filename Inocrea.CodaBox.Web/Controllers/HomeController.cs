﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

using ClosedXML.Excel;
using Inocrea.CodaBox.ApiModel;
using Inocrea.CodaBox.Web.Factory;
using Microsoft.AspNetCore.Mvc;
using Inocrea.CodaBox.Web.Models;
using Microsoft.Extensions.Options;
using Inocrea.CodaBox.Web.Helper;
using System.Text;
using Inocrea.CodaBox.Web.Background;

namespace Inocrea.CodaBox.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<SettingsModels> _appSettings;
        private static List<InvoiceModel> listInvoice = new List<InvoiceModel>();
        private static List<Transactions>   dataList = new List<Transactions>();
        private static string name = "";

        public HomeController(IOptions<SettingsModels> app)
        {
            _appSettings = app;
            AppSettings.ApiUrl = "Https://"+_appSettings.Value.WebApiBaseUrl;
        }
        public async Task<IActionResult> Index()
        {

            List<Transactions> data = await ApiClientFactory.Instance.GetInvoice();
            

            name = data.Select(n => n.Number).FirstOrDefault()?.ToString();
            ViewBag.transactions = dataList;
            ViewBag.statements = data;
            dataList = data;
            PeriodicBackgroundService.DataList = data;
            return View(dataList);
        }
        public FileResult ExportTransactions()
        {
            // query data from database  
            DataTable dt = ExportToExcel.ExportGenericTransactions<List<InvoiceModel>>(dataList);
            for (int i = 0; i < dt.Columns.Count; i++)
            {

                if ((dt.Columns[i].ColumnName.ToString().Contains("DATE") ||
                     (dt.Columns[i].ColumnName.ToString().Contains("Date"))))
                {
                    var name = dt.Columns[i].ColumnName;
                    if (!(dt.Columns[i].ColumnName.ToString().Contains("FORMAT")))
                    {
                        dt.Columns.Remove(dt.Columns[i].ColumnName.ToString());
                    }

                }


            }

            var fileName = name + ".xlsx"; //declaration.xlsx";


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    try
                    {
                          wb.SaveAs(stream);
                        var file = File(stream.ToArray(),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                        return file;
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
        }

        public FileResult Export()
        {
            DataTable dt = ExportToExcel.ExportGenericInvoiceModel<List<InvoiceModel>>(listInvoice);
            for (int i = 0; i < dt.Columns.Count; i++)
            {

                if ((dt.Columns[i].ColumnName.ToString().Contains("DATE") ||
                     (dt.Columns[i].ColumnName.ToString().Contains("Date"))))
                {
                    var name = dt.Columns[i].ColumnName;
                    if (!(dt.Columns[i].ColumnName.ToString().Contains("FORMAT")))
                    {
                        dt.Columns.Remove(dt.Columns[i].ColumnName.ToString());
                    }

                }


            }

            var fileName = name + ".xlsx"; //declaration.xlsx";


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    try
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
        }

        public FileResult ExportJson()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dataList);
            var fileName = "coda" + ".json"; //declaration.json";
            byte[] fileBytes = Encoding.UTF8.GetBytes(json);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
