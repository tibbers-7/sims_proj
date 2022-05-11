using Service;
using System;

namespace Controller
{
    public class VacationController
    {
        private VacationService service;

        public VacationController(VacationService service)
        {
            this.service = service;
        }

        internal int ScheduleVacation(int doctorId,string startDate, string endDate, string reason)
        {
            DateOnly _startDate = AppointmentController.ParseDate(startDate);
            DateOnly _endDate = AppointmentController.ParseDate(endDate);
            return service.ScheduleVacation(doctorId,_startDate, _endDate, reason);
        }
    }
}
