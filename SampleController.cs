using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TestA.Models;

namespace TestA.Controllers
{
    public class SampleController : Controller
    {
        Patient db = new Patient();


        public IActionResult Index()
        {

            return View(Repository.AllPatient);
            
        }
        private IHostingEnvironment hostingEnv;
        public SampleController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }

        [HttpPost]
        public string Upload_File()
        {
            string result = string.Empty;

            try

            {
                long size = 0;

                var file = Request.Form.Files;

                var filename = ContentDispositionHeaderValue

                                .Parse(file[0].ContentDisposition)

                                .FileName

                                .Trim('"');

                string FilePath = hostingEnv.WebRootPath + $@"\{ filename}";

                size += file[0].Length;

                using (FileStream fs = System.IO.File.Create(FilePath))

                {

                    file[0].CopyTo(fs);

                    fs.Flush();

                }



                result = FilePath;

            }

            catch (Exception ex)

            {

                result = ex.Message;

            }



            return result;

        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                Repository.Create(patient);
                return View("Thanks", patient);
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult Update(Patient patient, string pname)
        {
            if (ModelState.IsValid)
            {
                Repository.AllPatient.Where(e => e.FullName == pname).FirstOrDefault().Photo = patient.Photo;
                Repository.AllPatient.Where(e => e.FullName == pname).FirstOrDefault().Gender = patient.Gender;
                Repository.AllPatient.Where(e => e.FullName == pname).FirstOrDefault().Age = patient.Age;
                Repository.AllPatient.Where(e => e.FullName == pname).FirstOrDefault().DOB = patient.DOB;
                Repository.AllPatient.Where(e => e.FullName == pname).FirstOrDefault().CaseType = patient.CaseType;
                Repository.AllPatient.Where(e => e.FullName == pname).FirstOrDefault().CaseType = patient.EnquiryRemark;
                Repository.AllPatient.Where(e => e.FullName == pname).FirstOrDefault().CaseType = patient.PresentAddresss;
                Repository.AllPatient.Where(e => e.FullName == pname).FirstOrDefault().CaseType = patient.PermanentAddresss;





                return RedirectToAction("Index");
            }
            else
                return View();
        }
        public IActionResult Delete(string pname)
        {
            Patient patient = Repository.AllPatient.Where(e => e.FullName == pname).FirstOrDefault();
            Repository.Delete(patient);
            return RedirectToAction("Index");
        }
    }
}