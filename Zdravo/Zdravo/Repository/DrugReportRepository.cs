﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;
using Zdravo.Model;

namespace Zdravo.Repository
{
    public class DrugReportRepository 
    {
        private List<DrugReport> drugReports;
        private readonly DrugReportFileHandler fileHandler;

        public DrugReportRepository()
        {
            fileHandler = new DrugReportFileHandler();
            InitDrugReports();
        }

        private void InitDrugReports()
        {
            List<object> drugReportsList = fileHandler.Read();
            drugReports = new List<DrugReport>();
            foreach (object drugReportObj in drugReportsList)
            {
                DrugReport drugReport = (DrugReport) drugReportObj;
                drugReports.Add(drugReport);
            }
        }

        public List<DrugReport> GetAll()
        {
            return drugReports;
        }
        public DrugReport GetById(int id)
        {
            foreach (DrugReport drugReport in drugReports)
            {
                if (drugReport.Id == id) return drugReport;
            }
            return null;
        }

        public void AddNew(DrugReport drugReport)
        {
            drugReport.Id = drugReports.Last().Id + 1;
            int listCount = drugReports.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = drugReports[i].ToCSV();
            }
            newLines[listCount] = drugReport.ToCSV();
            fileHandler.Write(newLines);
            InitDrugReports();
        }

        public void Delete(int id)
        {
            DrugReport drugReportToDelte = GetById(id);
            drugReports.Remove(drugReportToDelte);
            int listCount = drugReports.Count;
            string[] newLines = new string[listCount];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = drugReports[i].ToCSV();
            }
            fileHandler.Write(newLines);
            InitDrugReports();
        }
    }
}
