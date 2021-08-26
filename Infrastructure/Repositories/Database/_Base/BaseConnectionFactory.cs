using System;
using System.Linq;
using System.Threading.Tasks;
using CommonShared.Dependencies.EntityFrameworkCore;
using Constants.Settings;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories.Database._Base
{
    public class BaseConnectionFactory<TEntity> where TEntity : class
    {

        protected static object Locker
        {
            get
            {
                if (_locker == null)
                {
                    _locker = new object();
                }
                return _locker;
            }
        }
        private static object _locker;
        protected DbSet<TEntity> Table;
        private string _dbPath { get; set; }
        private static DatabaseContext _dataContext { get; set; }
        public DatabaseContext DataContext
        {
            get
            {
                if (_dataContext != null)
                {
                    return _dataContext;
                }
                _dataContext = new DatabaseContext(_dbPath);
                _dataContext.ChangeTracker.AutoDetectChangesEnabled = false;
                return _dataContext;
            }
        }



        public BaseConnectionFactory(IEntityFrameworkCoreDependency entityFrameworkCoreDependency)
        {
            _dbPath = entityFrameworkCoreDependency.GetDatabasePath();
            Table = DataContext.Set<TEntity>();
        }

        public virtual async Task CommitAsync()
        {
            await DataContext.SaveChangesAsync();
        }

        public virtual void Commit()
        {
            DataContext.SaveChanges();
        }

        #region Other
        /// <summary>
        /// Obtiene la clave primaria
        /// </summary>
        /// <returns>String con la clave primaria</returns>
        protected string GetPrimaryKeyName()
        {
            var keyNames = DataContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select(x => x.Name);
            string keyName = keyNames.FirstOrDefault();

            if (keyNames.Count() > 1)
            {
                throw new ApplicationException(DatabaseSettings.ERROR_BASE_MODEL_ONLY_ONE_KEY);
            }

            if (keyName == null)
            {
                throw new ApplicationException(DatabaseSettings.ERROR_BASE_MODEL_PRIMARY_KEY);
            }

            return keyName;
        }

        /// <summary>
        /// Obtiene la clave primeria
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        protected object CastPrimaryKey(object id)
        {
            string keyName = GetPrimaryKeyName();
            Type keyType = typeof(TEntity).GetProperty(keyName).PropertyType;
            return Convert.ChangeType(id, keyType);
        }

        /// <summary>
        /// Obtiene el valor de la clave primaria
        /// </summary>
        /// <param name="entity">Entidad</param>
        /// <returns>Valor de las claves primarias</returns>
        protected object GetValuePrimaryKey(TEntity entity)
        {
            string keyName = GetPrimaryKeyName();
            object value = typeof(TEntity).GetProperty(keyName).GetValue(entity);
            return value;
        }
        #endregion

    }
}
