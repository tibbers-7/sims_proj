using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window, INotifyPropertyChanged
    {
        private EquipmentController _eqController;


        #region NotifyProperties
        private int _amount;
        private int _roomId;
        private string _name;
        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value != _amount)
                {
                    _amount = value;
                    OnPropertyChanged("Amount");
                }
            }
        }
        public int RoomId
        {
            get
            {
                return _roomId;
            }
            set
            {
                if (value != _roomId)
                {
                    _roomId = value;
                    OnPropertyChanged("RoomId");
                }
            }
        }

        public string Nam
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Nam");
                }
            }
        }
        #endregion



        public AddEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
            _eqController = new EquipmentController();

        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _eqController.Create(_name, _amount, _roomId);
            this.Close();
        }
    }
}
