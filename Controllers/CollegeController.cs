using Microsoft.AspNetCore.Mvc;
using CRUDAppADO.Models;
using CRUDAppADO.Repository;
using Microsoft.Data.SqlClient;

namespace CRUDAppADO.Controllers
{
    public class CollegeController : Controller
    {
        public IActionResult AllColleges()
        {
            CollegeRepo cr = new CollegeRepo();
            try
            {
                IEnumerable<College> listOfColleges = cr.GetAllCollegeRecords();
                return View(listOfColleges);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
        }
        public IActionResult CreateCollegeRecord()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCollegeRecord(College c)
        {
            CollegeRepo cr = new CollegeRepo();
            try
            {
                cr.AddRecord(c);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }

            return Content("A record has been inserted !");
        }
        public IActionResult CollegeDetail(int id)
        {
            CollegeRepo cr = new CollegeRepo();
            try
            {
                College c = cr.GetSingleCollegeRecord(id);
                return View(c);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
        }

        // edit
        public IActionResult EditCollegeRecord(int id)
        {
            CollegeRepo cr = new CollegeRepo();
            try
            {
                College c = cr.GetSingleCollegeRecord(id);
                return View(c);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
        }
        [HttpPost]
        public IActionResult EditCollegeRecord(College c)
        {
            CollegeRepo cr = new CollegeRepo();
            try
            {
                cr.EditRecord(c);
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
            return Content("A record has been updated !");
        }

        public IActionResult DeleteCollegeRecord(int id)
        {
            CollegeRepo cr = new CollegeRepo();
            try
            {
                College c = cr.GetSingleCollegeRecord(id);
                cr.DeleteRecord(c);
                return Content("A record has been deleted !");
            }
            catch (SqlException ex)
            {
                return Content("Error !!" + ex.Message);
            }
        }



    }
}
