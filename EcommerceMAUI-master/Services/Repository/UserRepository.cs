using EcommerceMAUI.Model;
//using GameplayKit;
using SQLite;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EcommerceMAUI.Services.Repository
{
    public class UserRepository : IUserRepository
    {
        private const string DbName = "MyDatabase.db5";
        private static string DbPath => Path.Combine(FileSystem.AppDataDirectory, DbName);

        private SQLiteAsyncConnection _connection;
        private SQLiteAsyncConnection Database =>
            _connection ??= new SQLiteAsyncConnection(DbPath,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);

        public async Task<bool> CreateTableIfNotExists<TTable>() where TTable : class, new()
        {
            await Database.CreateTableAsync<TTable>();
            return true;
        }

        public async Task<AsyncTableQuery<TTable>> GetTableAsync<TTable>() where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return Database.Table<TTable>();
        }

        public async Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.ToListAsync();
        }



        public async Task<IEnumerable<TTable>> GetFileteredAsync<TTable>(Expression<Func<TTable, bool>> predicate) where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.Where(predicate).ToListAsync();
        }

        private async Task<TResult> Execute<TTable, TResult>(Func<Task<TResult>> action) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await action();
        }

        public async Task<TTable> GetItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
        {
            //await CreateTableIfNotExists<TTable>();
            //return await Database.GetAsync<TTable>(primaryKey);
            return await Execute<TTable, TTable>(async () => await Database.GetAsync<TTable>(primaryKey));
        }

        public async Task<bool> AddItemAsync<TTable>(TTable item) where TTable : class, new()
        {
            //await CreateTableIfNotExists<TTable>();
            //return await Database.InsertAsync(item) > 0;
            return await Execute<TTable, bool>(async () => await Database.InsertAsync(item) > 0);
        }

        //public async Task<bool> UpdateItemAsync<TTable>(TTable item) where TTable : class, new()
        //{
        //    await CreateTableIfNotExists<TTable>();
        //    return await Database.UpdateAsync(item) > 0;
        //}



        public async Task<bool> DeleteItemByKeyAsync<TTable>(int Id) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await Database.DeleteAsync<TTable>(Id) > 0;
        }







        public async ValueTask DisposeAsync() => await _connection?.CloseAsync();




    }
}

