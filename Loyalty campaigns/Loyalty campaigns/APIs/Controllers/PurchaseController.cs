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
            var csvFilePath =  _purchaseService.GetSuccessfulPurchasesCSVAsync();

            var csvBytes = await System.IO.File.ReadAllBytesAsync(csvFilePath);
            var csvFileName = "successful_purchases.csv";

            return File(csvBytes, "text/csv", csvFileName);
        }
    }
}
