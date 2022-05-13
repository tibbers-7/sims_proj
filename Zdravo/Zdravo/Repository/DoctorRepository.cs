// File:    DoctorRepository.cs
// Author:  Anja
// Created: Monday, March 28, 2022 3:57:38 PM
// Purpose: Definition of Class DoctorRepository

using FileHandler;
using Model;
using System;
using System.Collections.ObjectModel;
using FileHandler;
namespace Repository
{
   public class DoctorRepository
   {
      private ObservableCollection<Doctor> doctors;

    public DoctorRepository()
        {
            DoctorFileHandler fileHandler = new DoctorFileHandler();
            this.doctors = fileHandler.Load();
        }
       
      public Doctor getById(int id)
        {
            
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