namespace EmpSysVer0.Models
{
    public class Settings
    {
        public class Login  //登入類別
        {
            public string Account { get; set; }
            public string Password { get; set; }
        }
        public class User
        {
            public string UserId { get; set; }
        }

    }
}
