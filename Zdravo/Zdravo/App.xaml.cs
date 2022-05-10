using Controller;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Zdravo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public AppointmentController appointmentController;
        public AllergenController allergenController;
        public BasicRenovationController basicRenovationController;
        public EquipmentController equipmentController;
        public PatientController patientController;
        public RoomController roomController;
        public App()
        {
            var appointmentRepository = new AppointmentRepository();
            var allergenRepository = new AllergenRepository();
            var basicRenovationRepository=new BasicRenovationRepository();
            var doctorRepository = new DoctorRepository();
            var drugRepository=new DrugRepository();
            var equipmentRepository = new EquipmentRepository();
            var patientRepository=new PatientRepository();
            var prescriptionRepository = new PrescriptionRepository();
            var relocationRepository = new RelocationRepository();




            var appointmentService = new AppointmentService();
            var vacationService = new VacationService();
            var allergenService = new AllergenService();
            var basicRenovationService = new BasicRenovationService();
            var equipmentService = new EquipmentService();
            var patientService=new PatientService();
            var roomService = new RoomService();
            var timeService = new TimeService();


            appointmentController = new AppointmentController(appointmentService);
            allergenController = new AllergenController();
            basicRenovationController = new BasicRenovationController();
            equipmentController = new EquipmentController();
            patientController = new PatientController();
            roomController = new RoomController();

            
        }
    }
}
