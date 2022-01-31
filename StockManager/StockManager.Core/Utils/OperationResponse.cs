using System;
using System.Collections.Generic;
using System.Text;

namespace StockManager.Core.Utils
{
    public class OperationResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }

        public static OperationResponse<T> CreateSuccesResponse(T result)
        {
            return new OperationResponse<T>
            {
                Success = true,
                Resource = result
            };
        }

        public static OperationResponse<T> CreateSuccesResponse(string message)
        {
            return new OperationResponse<T>
            {
                Success = true,
                Message = message,
                Resource = default(T)
            };
        }

        public static OperationResponse<T> CreateFailure(string message)
        {
            return new OperationResponse<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}
