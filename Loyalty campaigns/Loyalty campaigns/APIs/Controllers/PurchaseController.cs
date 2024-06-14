using Loyalty_campaigns.Business_Layer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty_campaigns.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        [HttpGet("export_csv")]
        public async Task<IActionResult> ExportProductsToCsv()
        {
            //DateTime endDateOfCampaign = new DateTime(2024, 7, 1);
            DateTime endDateOfCampaign = new DateTime(2024, 6, 13);//for test purpose
            DateTime currentDate = DateTime.UtcNow.Date;

            //if (currentDate >= endDateOfCampaign.AddMonths(1))
            if (currentDate >= endDateOfCampaign.AddDays(1)) //for test purpose
            {
                var csvFilePath = _purchaseService.GetSuccessfulPurchasesCSVAsync();

                var csvBytes = await System.IO.File.ReadAllBytesAsync(csvFilePath);
                var csvFileName = "successful_purchases.csv";

                return File(csvBytes, "text/csv", csvFileName);
            }
            else
            {
               
                return StatusCode(403, "Results not available yet.");
            }
            
        }
    }
}
