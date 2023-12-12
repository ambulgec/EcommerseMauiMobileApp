using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EcommerceMAUI.Services.Repository
{


    public interface IUserRepository : IAsyncDisposable
    {

        Task<bool> CreateTableIfNotExists<TTable>() where TTable : class, new();
        Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new();
        Task<IEnumerable<TTable>> GetFileteredAsync<TTable>(Expression<Func<TTable, bool>> predicate) where TTable : class, new();
        Task<TTable> GetItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new();

        Task<bool> AddItemAsync<TTable>(TTable item) where TTable : class, new();
        Task<bool> DeleteItemByKeyAsync<TTable>(int Id) where TTable : class, new();

    }
}
