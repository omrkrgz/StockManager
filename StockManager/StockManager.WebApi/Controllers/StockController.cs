using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockManager.Business.Abstract;
using StockManager.Entities;

namespace StockManager.WebApi.Controllers
{
    public class StockController : ControllerBase
    {
        private IStockService _stockService;

        public StockController()
        {
            _stockService = new Business.Manager.StockManager();
        }
        public List<Stocks> GetAllStocks()
        {
            return _stockService.GetAllStocks();
        }
    }
}