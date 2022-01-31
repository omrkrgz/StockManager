using StockManager.Core.Utils;
using StockManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.DataAccess.Abstract
{
    public interface IStockRepository
    {
       Task<List<Stocks>> GetAllStocks();

       Task<Stocks> GetStockByVariantCode(string VariantCode);

       Task<Stocks> GetStockByProductCode(string ProductCode);

        Task<OperationResponse<Stocks>> CreateStock(Stocks stock);

       Task<Stocks> UpdateStock (Stocks stock);

       void DeleteStock (string VariantCode);
    }
}
