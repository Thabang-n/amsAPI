using Domain.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DbTransactionManager
{

    
    public class TransactionService : ITransactionService
    {
        private readonly amsDbContext _context;
        private IDbContextTransaction _transaction;
        public TransactionService(amsDbContext context)
        {
          this._context = context; 
         
            
        }
        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = _context.Database.BeginTransaction();
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();

            if(_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if(_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                 _transaction = null;
            }
        }

    }
}
