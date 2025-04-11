namespace EmpSysVer0.Models
{
    
        public class Response
        {
            public object Data { get; set; }
            public object Result { get; set; }
            public string Message { get; set; }
            public bool Success { get; set; }

            public Response(object result)
            {
                Result = result;
                Message = "成功";
                Success = true;
            }
            public Response()
            {
                Message = "失敗";
                Success = false;
            }


            public Response(Exception fatal)
            {
                Message = $"{fatal.Message}";
            }
        }
}
