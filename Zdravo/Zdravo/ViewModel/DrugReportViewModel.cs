using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Controller;
using System.Windows;
using System.Windows.Controls;
using Model;

namespace Zdravo.ViewModel
{
    internal class DrugReportViewModel
    {
        private int drugId;
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private string reason;
        public string Reason { get { return reason; } set { reason = value; } }
        private DrugController drugController;

        public DrugReportViewModel(int drugId)
        {
            this.drugId = drugId;
            var app = Application.Current as App;
            drugController = app.drugController;
            Drug d = drugController.GetById(drugId);
            name= d.Name;
        }

        internal void CreateDrugReport()
        {
            drugController.CreateDrugReport(drugId, reason);
            drugController.ChangeStatus(false, drugId);
        }
    }
}
