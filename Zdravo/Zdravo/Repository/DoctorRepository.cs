// File:    DoctorRepository.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:57:38 PM
// Purpose: Definition of Class DoctorRepository

using Model;
using System;
using System.Collections.ObjectModel;
using Zdravo.FileHandler;
namespace Repository
{
   public class DoctorRepository
   {
      private ObservableCollection<Doctor> doctors;
       
      public Doctor getById(int id)
        {
            DoctorFileHandler fileHandler = new DoctorFileHandler();
            this.doctors = fileHandler.Load();
            foreach(Doctor doctor in doctors)
            {
                if(doctor.Id == id)return doctor;
            }
            return null;
        }
        public ObservableCollection<Doctor> getAll()
        {
            DoctorFileHandler fileHandler = new DoctorFileHandler();
            this.doctors = fileHandler.Load();
            return this.doctors;
        }

   }
}