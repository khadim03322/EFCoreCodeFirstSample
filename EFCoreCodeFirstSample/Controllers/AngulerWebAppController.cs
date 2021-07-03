using EFCoreCodeFirstSample.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Controllers
{
    [Authorize]
    [Route("api/AngulerWebApp")]
    [ApiController]
    public class AngulerWebAppController : ControllerBase
    {


        private readonly EmployeeContext _employeeContext;
        public AngulerWebAppController(EmployeeContext context)
        {
        
            _employeeContext = context;
        }



        [HttpGet("AllEmployeeDetails")]
        public IActionResult GetEmaployee()
        {
            // int skipValue = (page - 1) * size;

            try
            {

                IEnumerable<TblEmployeeMaster> tblEmployeeMasters = _employeeContext
                .TblEmployeeMasters.
                Include(e => e.CityMaster)
               .Include(e => e.CountryMaster)
                 .Include(e => e.StateMaster)

                .ToList();


            return Ok(tblEmployeeMasters);


            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet("GetEmployeeDetailsById/{employeeId}")]
        public IActionResult GetEmaployeeById(int employeeId)
        {
            // int skipValue = (page - 1) * size;

            try
            {
                TblEmployeeMaster  tblEmployeeMaster = _employeeContext.TblEmployeeMasters
                 .Include(e => e.CityMaster)
               .Include(e => e.CountryMaster)
                 .Include(e => e.StateMaster)
                 .FirstOrDefault(e => e.EmpId == employeeId);



            return Ok(tblEmployeeMaster);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("InsertEmployeeDetails")]
        public IActionResult PostEmaployee([FromBody] TblEmployeeMaster tblEmployeeMaster)
        {
            if (tblEmployeeMaster == null)
            {
                return BadRequest("tblEmployeeMaster is null.");
            }

            try
            {
                _employeeContext.TblEmployeeMasters.Add(tblEmployeeMaster);
            _employeeContext.SaveChanges();

            return Ok(tblEmployeeMaster);
            }
            catch (Exception)
            {
                throw;
            }


        }


        [HttpPut("UpdateEmployeeDetails")]
        public IActionResult Put(TblEmployeeMaster tblEmployeeMaster)
        {
            if (tblEmployeeMaster == null)
            {
                return BadRequest("tblEmployeeMaster is null.");
            }

            TblEmployeeMaster tblEmployeeMasterToUpdate = _employeeContext.TblEmployeeMasters.FirstOrDefault(e => e.EmpId == tblEmployeeMaster.EmpId); 

            if (tblEmployeeMasterToUpdate == null)
            {
                return NotFound("The tblEmployeeMasterToUpdate record couldn't be found.");
            }

            //_dataRepository.Update(postToUpdate, post);
            try
            {
                tblEmployeeMasterToUpdate.FirstName = tblEmployeeMaster.FirstName;
            tblEmployeeMasterToUpdate.LastName = tblEmployeeMaster.LastName;
            tblEmployeeMasterToUpdate.Address = tblEmployeeMaster.Address;
            tblEmployeeMasterToUpdate.EmailId = tblEmployeeMaster.EmailId;
            tblEmployeeMasterToUpdate.DateofBirth = (DateTime)(tblEmployeeMaster.DateofBirth !=null ? tblEmployeeMaster.DateofBirth : (DateTime?)null);
            tblEmployeeMasterToUpdate.Gender = tblEmployeeMaster.Gender;
            tblEmployeeMasterToUpdate.CountryId = tblEmployeeMaster.CountryId;
            tblEmployeeMasterToUpdate.StateId = tblEmployeeMaster.StateId;
            tblEmployeeMasterToUpdate.Cityid = tblEmployeeMaster.Cityid;
            tblEmployeeMasterToUpdate.Pincode = tblEmployeeMaster.Pincode;


            _employeeContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(tblEmployeeMasterToUpdate);
        }



        [HttpDelete("DeleteEmployeeDetails")]
        public IActionResult Delete(long id)
        {
            TblEmployeeMaster tblEmployeeMasterToDelete = _employeeContext.TblEmployeeMasters.FirstOrDefault(e => e.EmpId == id);

            if (tblEmployeeMasterToDelete == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }


            _employeeContext.TblEmployeeMasters.Remove(tblEmployeeMasterToDelete);
            _employeeContext.SaveChanges();

            return Ok(tblEmployeeMasterToDelete);
        }


        [HttpGet("Country")]
        public IActionResult GetCountry()
        {
            // int skipValue = (page - 1) * size;

            try
            {

                IEnumerable<CountryMaster> countryMasters = _employeeContext
                .CountryMasters
                  .ToList();

                return Ok(countryMasters);


            }
            catch (Exception)
            {
                throw;
            }
        }



        [Route("Country/{CountryId}/State")]
        [HttpGet]
        public List<StateMaster> StateData(int CountryId)
        {
            try
            {
                return _employeeContext.StateMasters.Where(s => s.CountryId == CountryId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [Route("State/{StateId}/City")]
        [HttpGet]
        public List<CityMaster> CityData(int StateId)
        {
            try
            {
                return _employeeContext.CityMasters.Where(s => s.StateId == StateId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost]
        [Route("DeleteRecord")]
        public IActionResult DeleteRecord(List<TblEmployeeMaster> tblEmployeeMasters)
        {
            string result = "";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
                result = DeleteData(tblEmployeeMasters);
           
            return Ok(tblEmployeeMasters);
        }


        private string DeleteData(List<TblEmployeeMaster> tblEmployeeMasters)
        {
            string str = "";
            try
            {
                foreach (var item in tblEmployeeMasters)
                {
                    TblEmployeeMaster objEmp = new TblEmployeeMaster();
                    objEmp.EmpId = item.EmpId;
                    objEmp.FirstName = item.FirstName;
                    objEmp.LastName = item.LastName;
                    objEmp.Address = item.Address;
                    objEmp.EmailId = item.EmailId;
                    objEmp.DateofBirth = (DateTime)(item.DateofBirth!=null ? item.DateofBirth : (DateTime?)null);
                    objEmp.Gender = item.Gender;
                    objEmp.CountryId = item.CountryId;
                    objEmp.StateId = item.StateId;
                    objEmp.Cityid = item.Cityid;
                    objEmp.Pincode = item.Pincode;
                    var entry = _employeeContext.Entry(objEmp);
                    if (entry.State == EntityState.Detached)
                        _employeeContext.TblEmployeeMasters.Attach(objEmp);
                    _employeeContext.TblEmployeeMasters.Remove(objEmp);
                }

                int i = _employeeContext.SaveChanges();

                if (i > 0)
                {
                    str = "Records has been deleted";
                }
                else
                {
                    str = "Records deletion has been faild";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }






    }
}
