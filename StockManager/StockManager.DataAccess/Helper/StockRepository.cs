using Microsoft.EntityFrameworkCore;
using StockManager.Core.Utils;
using StockManager.DataAccess.Abstract;
using StockManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.DataAccess.Helper
{
    public class StockRepository : IStockRepository
    {

        public async Task <List<Stocks>> GetAllStocks()
        {
            using (var stockDbContext = new  StockDbContext())
            {
                return await stockDbContext.Stocks.ToListAsync();
            }
        }

        public async Task<Stocks> GetStockByVariantCode(string VariantCode)
        {
            using (var stockDbContext = new StockDbContext())
            {
                return await stockDbContext.Stocks.FirstOrDefaultAsync(x=>x.VariantCode==VariantCode);
            }
        }

        public async Task<Stocks> GetStockByProductCode(string ProductCode)
        {
            using (var stockDbContext = new StockDbContext())
            {
                return await stockDbContext.Stocks.FirstOrDefaultAsync(x => x.ProductCode == ProductCode);
            }
        }

        public async Task<OperationResponse<Stocks>> CreateStock(Stocks stock)
        {
            using (var stockDbContext = new StockDbContext())
            {
                stockDbContext.Add(stock);
                stockDbContext.SaveChanges();
                return OperationResponse<Stocks>.CreateSuccesResponse(stock);
            }
        }

        public async Task<Stocks> UpdateStock(Stocks stock)
        {
            using (var stockDbContext = new StockDbContext())
            {
                stockDbContext.Stocks.Update(stock);
                stockDbContext.SaveChanges();
                return stock;
            }
        }

        public void DeleteStock(string VariantCode)
        {
            throw new NotImplementedException();
        }
    }
}
