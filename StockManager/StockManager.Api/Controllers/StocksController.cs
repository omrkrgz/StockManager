using Microsoft.AspNetCore.Mvc;
using StockManager.Business.Abstract;
using StockManager.Core.Utils;
using StockManager.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : Controller
    {
        private IStockService _stockService;
        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<List<Stocks>> GetAllStocks()
        {
            return await _stockService.GetAllStocks();
        }

        [HttpGet("GetStockByVariantCode/{VariantCode}")]
        public async Task<Stocks> GetStockByVariantCode(string VariantCode)
        {
            return await _stockService.GetStockByVariantCode(VariantCode);
        }

        [HttpGet("GetStockByProductCode/{ProductCode}")]
        public async Task<Stocks> GetStockByProductCode(string ProductCode)
        {
            return await _stockService.GetStockByProductCode(ProductCode);
        }

        [HttpPost]
        public async Task<OperationResponse<Stocks>> CreateStock([FromBody] Stocks stock )
        {
            return await _stockService.CreateStock(stock);
        }

        [HttpPut]
        public async Task<Stocks> UpdateStock([FromBody] Stocks stock)
        {
            return await _stockService.UpdateStock(stock);
        }

    }
}