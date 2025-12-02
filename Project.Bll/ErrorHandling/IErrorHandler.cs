using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.ErrorHandling
{
    public interface IErrorHandler
    {
        Task<T> ExecuteAsync<T>(Func<Task<T>> action);
        Task ExecuteAsync(Func<Task> action);
        T Execute<T>(Func<T> action);
        void Execute(Action action);
    }
}
