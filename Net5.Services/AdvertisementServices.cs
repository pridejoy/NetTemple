using Net5.IServices;
using Net5.Model.Models;
using Net5.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Net5.Repository.Sugar;
using SqlSugar;

namespace Net5.Services
{
    public class AdvertisementServices : BaseServices<Advertisement>, IAdvertisementServices
    {
        private DbContext context;
        private SqlSugarClient db;
        private SimpleClient<Advertisement> entityDB;

        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }
        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }
        public AdvertisementServices()
        {
            DbContext.Init(BaseDBConfig.ConnectionString);
            context = DbContext.GetDbContext();
            db = context.Db;
            entityDB = context.GetEntityDB<Advertisement>(db);
        }

        public int Sum(int i, int j)
        {
            return i+j;
        }

        int IAdvertisementServices.Add(Advertisement model)
        {
            var ccc = db.Queryable<Advertisement>().ToJson();
            return  db.Insertable(model).ExecuteReturnIdentity();
        }

        bool IAdvertisementServices.Delete(Advertisement model)
        {
            return true;
            //throw new NotImplementedException();
        }

        List<Advertisement> IAdvertisementServices.Query(Expression<Func<Advertisement, bool>> whereExpression)
        {
            return null;
        }

        bool IAdvertisementServices.Update(Advertisement model)
        {
            return true;
        }
    }
}
