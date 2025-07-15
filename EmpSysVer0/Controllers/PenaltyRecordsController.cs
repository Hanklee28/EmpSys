using Microsoft.AspNetCore.Mvc;


namespace EmpSysVer0.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PenaltyRecordsController : ControllerBase
    {

        //測試用假資料
        private static readonly List<PenaltyRecord> FakeData = new()
        {
            new PenaltyRecord { Id = 1, PenaltyDate = "2025-04-01", Company = "xx銀行", ViolationFact = "涉及洗錢防制法", ViolationLaw = "洗錢防制法第一條" },
            new PenaltyRecord { Id = 2, PenaltyDate = "2025-04-02", Company = "xx人壽", ViolationFact = "涉及洗錢防制法", ViolationLaw = "洗錢防制法第一條" },
            new PenaltyRecord { Id = 3, PenaltyDate = "2025-04-03", Company = "xx金控", ViolationFact = "涉及洗錢防制法", ViolationLaw = "洗錢防制法第三條" }
        };

        //裁罰紀錄查詢
        [HttpGet("GetPenaltyRecords")]
        public IActionResult Get([FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string? keyword = "")
        {
            try
            {
                var result = FakeData
                //此為初版,會再改為_dbContext
                .Where(r =>
                    DateTime.Parse(r.PenaltyDate) >= startDate &&
                    DateTime.Parse(r.PenaltyDate) <= endDate &&
                    (string.IsNullOrWhiteSpace(keyword) || r.ViolationFact.Contains(keyword)))
                .ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
                throw;
            }
            //後續會補上finally記log

        }
        //刪除單筆紀錄
        [HttpDelete("DeletePenaltyRecord/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var record = FakeData.FirstOrDefault(r => r.Id == id);
                if (record == null)
                    return NotFound();
                //此為初版,會再改為_dbContext
                FakeData.Remove(record);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Ok(ex);
                throw;
            }
            //後續會補上finally記log
        }
    }


    //假資料類別
    public class PenaltyRecord
    {
        public int Id { get; set; }
        public string PenaltyDate { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string ViolationFact { get; set; } = string.Empty;
        public string ViolationLaw { get; set; } = string.Empty;
    }


}

