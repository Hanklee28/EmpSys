using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using TrainEMPDB.Models;
using EmpSysVer0.Models;
using EmpSysVer0.Services;

namespace EmpSysVer0.Controllers
{


    namespace empSys.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class EmployeeController : ApiControllerBase
        {

            public EmployeeController(TrainEMPDBcontext dbcontext,/* ClaimAccessor claim, */IMemoryCache memoryCache) : base(dbcontext, memoryCache)
            {
                _dbcontext = dbcontext;
            }

            //測試
            [Route("db")]
            [HttpGet]
            public IActionResult Data([FromHeader] string header)
            {
                var No = header;
                try
                {
                    var webemp = _dbcontext.Employees.Where(x => x.DeptNo == $"{No}").Select(x => new { x.EmpName });
                    return Ok(webemp);
                }
                catch (Exception ex)
                {
                    return Ok(new Response(ex));
                }
            }
            ////[ServiceFilter(typeof(AuthorizationFilter))]
            ////列出所有員工
            //[Route("allEmp")]
            //[HttpGet]
            //public IActionResult AllEmp()
            //{

            //    var bonusYear = _claim._config.Year;
            //    try
            //    {

            //        var listEmp = _dbcontext.Employee.Select(x => new { x.EmpNo, x.EmpName, x.Sex, x.DeptNo, x.Salary, x.Birth }).ToList();

            //        // 建立存放有加薪後薪水的 List 
            //        List<AddClass> data = new List<AddClass>();

            //        // 從 listEmp中撈取資料
            //        foreach (var e in listEmp)
            //        {
            //            //以 AddClass 類別 format
            //            AddClass cal = new AddClass();
            //            cal.empNo = e.EmpNo;
            //            cal.empName = e.EmpName;
            //            cal.sex = e.Sex;
            //            cal.deptNo = e.DeptNo;
            //            cal.salary = e.Salary;
            //            cal.year = bonusYear;
            //            cal.bonusSalary = SalaryHelper.AddSalary(_claim._config.Year, e.Sex, e.DeptNo, e.Salary);
            //            cal.birth = e.Birth;
            //            data.Add(cal);
            //        }

            //        return Ok(data);


            //    }
            //    catch (Exception ex)
            //    {
            //        return Ok(new Response(ex));
            //    }
            //}






            //新增員工
            [Route("addEmp")]
            [HttpPost]
            public IActionResult Add([FromBody] Employee empBody)
            {
                try
                {
                    _dbcontext.Employees.Add(empBody);
                    _dbcontext.SaveChanges();
                    var newEmo = _dbcontext.Employees.Select(x => new { x.EmpNo, x.EmpName, x.Sex, x.DeptNo, x.Salary, x.Birth });


                    
   
                    return Ok(newEmo);
                }
                catch (Exception ex)
                {
                    return Ok(new Response(ex));
                }
            }


            //// 刪除員工
            [Route("deleEmp")]
            [HttpPost]
            public IActionResult Dele([FromBody] Employee empBody)
            {
                try
                {


                    _dbcontext.Employees.Remove(empBody);
                    _dbcontext.SaveChanges();
                    var newEmo = _dbcontext.Employees.Select(x => new { x.EmpNo, x.EmpName, x.Sex, x.DeptNo, x.Salary, x.Birth });


                    return Ok(newEmo);
                }
                catch (Exception ex)
                {
                    return Ok(new Response(ex));
                }
            }


            // 修改員工
            [Route("updEmp")]
            [HttpPost]
            public IActionResult Upd([FromBody] Employee empBody)
            {
                try
                {


                    _dbcontext.Employees.Update(empBody);
                    _dbcontext.SaveChanges();
                    var newEmo = _dbcontext.Employees.Select(x => new { x.EmpNo, x.EmpName, x.Sex, x.DeptNo, x.Salary, x.Birth });

                    return Ok(newEmo);
                }
                catch (Exception ex)
                {
                    return Ok(new Response(ex));
                }
            }


            // 試算薪水

            //[Route("calSalary")]
            //[HttpPost]
            //public IActionResult CalSalary([FromBody] CalSalary calSalary)
            //{

            //    try
            //    {

            //        //試算後的薪水
            //        var test = SalaryHelper.AddSalary(calSalary.Year, calSalary.Sex, calSalary.DeptNo, calSalary.Salary);

            //        return Ok(test);
            //    }
            //    catch (Exception ex)
            //    {
            //        return Ok(new Response(ex));
            //    }
            //}

    


        }
    }

}
