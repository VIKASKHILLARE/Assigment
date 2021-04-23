using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestA.Models
{
    public static  class Repository
    {
        private static List<Patient> allPatient = new List<Patient>();
        public static IEnumerable<Patient> AllPatient
        {
            get { return allPatient; }
        }
        public static void Create(Patient patient)
        {
            allPatient.Add(patient);
        }
        public static void Delete(Patient patient)
        {
            allPatient.Remove(patient);
        }
    }
}
