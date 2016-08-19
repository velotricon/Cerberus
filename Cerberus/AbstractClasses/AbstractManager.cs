using Cerberus.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cerberus.AbstractClasses
{
    public class AbstractManager
    {
        protected MainContext context;
        protected DbContextTransaction transaction;

        protected void BeginTransaction()
        {
            this.transaction = this.context.Database.BeginTransaction();
        }

        protected void CommitTransaction()
        {
            this.transaction.Commit();
        }

        protected void RollbackTransaction()
        {
            this.transaction.Rollback();
        }

        public AbstractManager(MainContext Context)
        {
            this.context = Context;
        }
    }
}