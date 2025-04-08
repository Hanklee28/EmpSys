using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using EmpSysVer0.Models;
using TrainEMPDB.Models;
using static EmpSysVer0.Models.Settings;
using EmpSysVer0.Services;

namespace EmpSysVer0.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ApiControllerBase
    {
        public LoginController(TrainEMPDBcontext dbcontext,/* ClaimAccessor claim, */IMemoryCache memoryCache) : base(dbcontext, memoryCache)
        {
            _dbcontext = dbcontext;
            //_claim = claim;
            _memoryCache = memoryCache;
        }
        [AllowAnonymous]
        [Route("logInBirth")]
        [HttpPost]
        public IActionResult LoginBirth([FromBody] Login loginBody)
        {
            try
            {
                var acct = loginBody.Account;
                var pwd = loginBody.Password;

                var emp = _dbcontext.Employees
                    .Where(x => x.EmpNo == acct)
                    .Select(x => new { x.EmpNo, x.Birth })
                    .FirstOrDefault();

                if (emp == null || !string.Equals(pwd, emp.Birth))
                {
                    return Ok(new Response { Message = "帳號或密碼錯誤" });
                }

                // 使用密碼當作唯一 key 來判斷是否登入
                if (_memoryCache.TryGetValue(emp.Birth, out _))
                {
                    throw new Exception("重複登入");
                }

                _memoryCache.Set(emp.Birth, DateTime.Now, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20),
                    Size = 1
                });

                return Ok(new Response(emp.Birth)); // token 就是 birth（依你原始邏輯）
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
            }
        }
        ////Token生日
        //[AllowAnonymous]
        //[Route("logInBirth")]
        //[HttpPost]
        //public IActionResult LoginBitrh([FromBody] Login loginBody)
        //{

        //    try
        //    {
        //        var acct = loginBody.Account; // 帳號==員編
        //        var pwd = loginBody.Password; // 密碼==生日

        //        var empNo = _dbcontext.Employees.Where(x => x.EmpNo == acct).Select(x => new { x.EmpNo }).FirstOrDefault().EmpNo;
        //        var birth = _dbcontext.Employees.Where(x => x.EmpNo == acct).Select(x => new { x.Birth }).FirstOrDefault().Birth;
        //        DateTime cacheEntry;
        //        //return Ok(empNo);
        //        //帳密是否正確回傳true/false
        //        var acctCheck = String.Equals(acct, empNo);
        //        var pwdCheck = String.Equals(pwd, birth);
        //        if (!acctCheck || !pwdCheck)
        //        {

        //            var fail = new Response();
        //            fail.Message = "帳號或密碼錯誤";
        //            return Ok(fail);
        //        }

        //        _memoryCache.Set("password", new Login()
        //        {
        //            Password = birth
        //        });
        //        var getCache = _memoryCache.Get<Login>("password");

        //        if (!_memoryCache.TryGetValue(getCache.Password, out cacheEntry))
        //        {
        //            cacheEntry = DateTime.Now;


        //            _memoryCache.Set(getCache.Password, cacheEntry, TimeSpan.FromSeconds(20));
        //            _memoryCache.Set("password", getCache.Password, TimeSpan.FromSeconds(20));

        //        }
        //        else
        //        {
        //            throw new Exception("重複登入");

        //        }
        //        var token = _memoryCache.Get("password");
        //        return Ok(new Response(token));


        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new Response(ex));
        //    }
        //}

        // 登入
        [AllowAnonymous]
        [Route("logIn")]
        [HttpPost]
        public IActionResult LoginToken([FromBody] Login loginBody)
        {

            try
            {
                var acct = loginBody.Account; // 帳號==員編
                var pwd = loginBody.Password; // 密碼==生日

                var empNo = _dbcontext.Employees.Where(x => x.EmpNo == acct).Select(x => new { x.EmpNo }).FirstOrDefault().EmpNo;
                var birth = _dbcontext.Employees.Where(x => x.EmpNo == acct).Select(x => new { x.Birth }).FirstOrDefault().Birth;
                DateTime cacheEntry;
                //return Ok(empNo);
                //帳密是否正確回傳true/false
                var acctCheck = String.Equals(acct, empNo);
                var pwdCheck = String.Equals(pwd, birth);
                if (!acctCheck || !pwdCheck)
                {

                    var fail = new Response();
                    fail.Message = "帳號或密碼錯誤";
                    return Ok(fail);
                }
                _memoryCache.Set("password", new Login()
                {
                    Password = birth
                });

                var getCache = _memoryCache.Get<Login>("password");

                if (!_memoryCache.TryGetValue(getCache.Password, out cacheEntry))
                {
                    cacheEntry = DateTime.Now;


                    _memoryCache.Set(getCache.Password, cacheEntry, TimeSpan.FromSeconds(20));


                }
                else
                {
                    throw new Exception("重複登入");

                }

                var token = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
                return Ok(new Response(token));


            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
            }




        }



    }
}
