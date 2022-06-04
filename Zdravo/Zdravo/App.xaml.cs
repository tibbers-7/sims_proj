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
using Zdravo.Controller;
using Zdravo.Repository;
using Zdravo.Service;


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
        public VacationController vacationController;
        public DrugController drugController;
        public IngredientController ingredientController;
        public App()
        {
            
            var allergenRepository = new AllergenRepository();
            var basicRenovationRepository=new BasicRenovationRepository();
            var doctorRepository = new DoctorRepository();
            var drugRepository=new DrugRepository();
            var reportRepository = new ReportRepository();
            var equipmentRepository = new EquipmentRepository();
            var patientRepository=new PatientRepository();
            var prescriptionRepository = new PrescriptionRepository();
            var relocationRepository = new RelocationRepository();
            var appointmentRepository = new AppointmentRepository(doctorRepository,patientRepository);
            var vacationRepository = new VacationRepository(doctorRepository);
            var drugReportRepository = new DrugReportRepository();
            var ingredientRepository = new IngredientRepository();



            var drugService = new DrugService(drugRepository,drugReportRepository);
            var appointmentService = new AppointmentService(appointmentRepository,drugRepository,prescriptionRepository,reportRepository,patientRepository);
            var vacationService = new VacationService(vacationRepository,doctorRepository);
            var allergenService = new AllergenService();
            var basicRenovationService = new BasicRenovationService();
            var equipmentService = new EquipmentService();
            var patientService=new PatientService();
            var roomService = new RoomService();
            var timeService = new TimeService();
            var ingredientService = new IngredientService(ingredientRepository);

            drugController = new DrugController(drugService);
            patientController = new PatientController();
            appointmentController = new AppointmentController(appointmentService,patientController,doctorRepository,drugController);
            allergenController = new AllergenController();
            basicRenovationController = new BasicRenovationController();
            equipmentController = new EquipmentController();
            roomController = new RoomController();
            vacationController = new VacationController(vacationService);
            ingredientController = new IngredientController(ingredientService);
            
        }
    }
}
