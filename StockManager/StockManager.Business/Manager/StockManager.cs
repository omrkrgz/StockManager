using StockManager.Business.Abstract;
using StockManager.Business.Settings;
using StockManager.Core.Utils;
using StockManager.DataAccess.Abstract;
using StockManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Business.Manager
{
    public class StockManager : IStockService
    {
        private IStockRepository _stockRepository;

        public StockManager(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;

        }
        public async Task<OperationResponse<Stocks>> CreateStock(Stocks stock)
        {
            object existStockVaryantCode = null;
            try
            {
                var varyantCode = Helper.FormatConverter(stock.VariantCode.ToUpper());
                existStockVaryantCode = await _stockRepository.GetStockByVariantCode(varyantCode);
                if (existStockVaryantCode != null)
                {
                    return OperationResponse<Stocks>.CreateSuccesResponse("Varyant Code Daha Önce Kullanılmış");
                }
                var newStock = new Stocks
                {

                    ProductCode = Helper.FormatConverter(stock.ProductCode.ToUpper()),
                    CreatedDate = DateTime.Now,
                    Quantity = stock.Quantity,
                    VariantCode = varyantCode
                };
                return await _stockRepository.CreateStock(newStock);
            }          
            catch(Exception ex)
            {
                return OperationResponse<Stocks>.CreateFailure(ex.Message);
            }
        }

        public async Task<List<Stocks>> GetAllStocks()
        {
            try
            {
                return await _stockRepository.GetAllStocks();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Stocks> GetStockByVariantCode(string VariantCode)
        {
            try
            {
                if (VariantCode == null)
                {
                    throw new Exception();
                }
                return await _stockRepository.GetStockByVariantCode(VariantCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Stocks> GetStockByProductCode(string ProductCode)
        {
            try
            {
                if (ProductCode == null)
                {
                    throw new Exception();
                }
                return await _stockRepository.GetStockByProductCode(ProductCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Stocks> UpdateStock(Stocks stock)
        {
            try
            {
                var varyantCode = Helper.FormatConverter(stock.VariantCode.ToUpper());
                var existStockVaryantCode = await _stockRepository.GetStockByVariantCode(varyantCode);
                if (existStockVaryantCode != null)
                {
                    throw new Exception();
                }

                var updateStock = await _stockRepository.GetStockByVariantCode(stock.VariantCode);
                if (updateStock != null)
                {
                    updateStock.ProductCode = stock.ProductCode;
                    updateStock.VariantCode = varyantCode;
                    updateStock.Quantity = stock.Quantity;
                    updateStock.UpdateTime = DateTime.Now;
                }
                return await _stockRepository.UpdateStock(updateStock);
            }
            catch (Exception)
            {
                throw new ArgumentNullException("Varyant Code Daha Önce Kullanılmış");
            }
        }

        public void DeleteStock(string VariantCode)
        {
            throw new NotImplementedException();
        }
    }
}
