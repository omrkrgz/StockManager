
using StockManager.Core.Utils;
using StockManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Business.Abstract
{
    public interface IStockService
    {
        Task<List<Stocks>> GetAllStocks();

        Task<Stocks> GetStockByVariantCode(string VariantCode);

        Task<Stocks> GetStockByProductCode(string ProductCode);

        Task<OperationResponse<Stocks>> CreateStock(Stocks stock);

        Task<Stocks> UpdateStock(Stocks stock);

        void DeleteStock(string VariantCode);
    }
}
