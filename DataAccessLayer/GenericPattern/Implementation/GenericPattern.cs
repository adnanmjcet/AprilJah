using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.GenericPattern.Implementation
{
    public class GenericPattern<T> : IGenericPattern<T> where T : class
    {
        private readonly JamiatDb db;
        internal IDbSet<T> DbSet;
        public GenericPattern()
        {
            db = new JamiatDb();
            this.DbSet = this.db.Set<T>();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = db.Set<T>().Where(predicate);
            return query;
        }

        public void Delete(int id)
        {
            var ID = db.Set<T>().Find(id);
            db.Set<T>().Remove(ID);
            db.SaveChanges();
        }
        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }
        public T Insert(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
            return entity;
        }

        public IQueryable<T> GetWithInclude(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params string[] include)
        {
            IQueryable<T> query = this.DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }
        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        public List<T> GetMultipleTablesDataById(string SQLQuery)
        {
            var strApplicant = db.Database.SqlQuery<T>(SQLQuery).ToList<T>();
            return strApplicant;
        }
    }
}
