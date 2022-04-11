/***********************************************************************
 * Module:  Patient.cs
 * Author:  Darko
 * Purpose: Definition of the Class Model.Patient
 ***********************************************************************/

using System;

namespace Model
{
   public class Patient : User
   {

        public Patient(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu,string mejl) :base(fn,ln,i,un,pas,pn,date,g,ad,gu,mejl)
        {
            
        }
   }
}