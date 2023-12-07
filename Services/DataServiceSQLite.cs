using CoverYourAss.Models;
using SQLite;
using System.Collections.ObjectModel;

namespace CoverYourAss.Services
{
    public class DataServiceSQLite
    {
        private static DataServiceSQLite _instance;
        public static DataServiceSQLite Instance => _instance ??= new DataServiceSQLite();

        private SQLiteAsyncConnection _database;

        private const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        private static string DatabaseFile => Path.Combine(FileSystem.AppDataDirectory, "Data.db3");

        private DataServiceSQLite()
        {
        }

        private async Task Init()
        {
            if (_database == null)
            {
                File.Delete(DatabaseFile); //This is a temporary line to delete the database every time. Remove this line to retain data.

                _database = new SQLiteAsyncConnection(DatabaseFile, Flags);

                if (!File.Exists(DatabaseFile))
                {
                    //Create tables and add sample data if needed.
                    await _database.CreateTableAsync<Activity>();
                    await SaveAsync(new Activity { Name = "Activity 1", Description = "Description for Activity 1" });
                    await SaveAsync(new Activity { Name = "Activity 2", Description = "Description for Activity 2" });
                    await SaveAsync(new Activity { Name = "Activity 3", Description = "Description for Activity 3" });
                    await SaveAsync(new Activity { Name = "Activity 4", Description = "Description for Activity 4" });
                    await SaveAsync(new Activity { Name = "Activity 5", Description = "Description for Activity 5" });
                }


            }
        }

        public async Task<ObservableCollection<T>> GetAsync<T>() where T : new()
        {
            await Init();
            var result = await _database.Table<T>().ToListAsync();
            return new ObservableCollection<T>(result);
        }

        public async Task<T> GetAsync<T>(int id) where T : IEntity, new()
        {
            await Init();
            return await _database.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveAsync<T>(T item) where T : IEntity, new()
        {
            await Init();
            if (item.Id != 0)
            {
                return await _database.UpdateAsync(item);
            }
            else
            {
                return await _database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteAsync<T>(T item) where T : new()
        {
            await Init();
            return await _database.DeleteAsync(item);
        }
    }
}
