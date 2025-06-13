using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DbTransactionManager
{
    public interface ITransactionService
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();

    }
}
