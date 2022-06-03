﻿using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zdravo.Controller;

namespace Zdravo.managerView
{
    public partial class AddDrug : Window, INotifyPropertyChanged
    {
        private DrugController drugController;
        #region NotifyProperties
        private int id;
        private string drugName;
        private string type;
        private string description;
        private ObservableCollection<string> drugNames;
        private ObservableCollection<string> allIngridients;
        private List<string> selectedIngredients;

        public ObservableCollection<string> DrugNames { get; set; }

        public ObservableCollection<string> AllIngridients { get; set; }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string DrugName
        {

            get
            {
                return drugName;
            }
            set
            {
                if (value != drugName)
                {
                    drugName = value;
                    OnPropertyChanged("DrugName");
                }
            }
        }


        public string Type
        {

            get
            {
                return type;
            }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public string Description
        {

            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        #endregion
        
        public AddDrug()
        {
            InitializeComponent();
            var app = Application.Current as App;
            drugController = app.drugController;
            comboStatus.ItemsSource = Enum.GetValues(typeof(Status));
            this.drugNames = new ObservableCollection<string>(drugController.GetAllDrugNames());
            comboDrugNames.ItemsSource = this.drugNames;
            this.DataContext = this;
            this.selectedIngredients = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Status status = (Status)comboStatus.SelectedItem;
            var selectedIngredients = ingridientsListView.SelectedItems;
            foreach(string ingrid in selectedIngredients)
            {
                string ingredient = (string)ingrid;
                this.selectedIngredients.Add(ingredient);
            }
            string alternativeDrugName = comboDrugNames.SelectedItem.ToString();
            Drug alternativeDrug = drugController.GetByName(alternativeDrugName);
            drugController.AddNew(this.id, this.drugName, status, this.type, this.description, this.selectedIngredients, alternativeDrug.Id);
            this.Close();
        }
    }
}
