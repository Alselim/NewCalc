using DataBase.Models;
using DataBase.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.NHibernate.Repositories
{
    public class NHBaseRepository
    {
        public void Add(HistoryItem item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(item);
                transaction.Commit();
            }
        }
        public IEnumerable<HistoryItem> GetAll(string condition = "")
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<HistoryItem>().List<HistoryItem>();
        }
    }
}
