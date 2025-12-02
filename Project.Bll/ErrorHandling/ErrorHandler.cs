using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.ErrorHandling
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly ILogger<ErrorHandler> _logger;

        public ErrorHandler(ILogger<ErrorHandler> logger)
        {
            _logger = logger;
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> action)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Business layer error occurred.");
                throw new Exception("İş katmanında hata oluştu", ex);
            }
        }

        public async Task ExecuteAsync(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Business layer error occurred.");
                throw new Exception("İş katmanında hata oluştu", ex);
            }
        }

        public T Execute<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Business layer error occurred.");
                throw new Exception("İş katmanında hata oluştu", ex);
            }
        }

        public void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Business layer error occurred.");
                throw new Exception("İş katmanında hata oluştu", ex);
            }
        }
    }
}
