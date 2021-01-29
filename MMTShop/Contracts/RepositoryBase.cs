using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Contracts
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public void ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (RepositoryContext.Database.CanConnect())
            {
                var command = RepositoryContext.Database.
            }
        }
    }
}
