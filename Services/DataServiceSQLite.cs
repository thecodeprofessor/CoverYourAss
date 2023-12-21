using SQLite;
using System.Collections.ObjectModel;
using System.Reflection;

namespace MediConnect.Services
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

        private static string DatabaseFile => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..\\..\\..\\..\\..\\Data.db3");
        //private static string DatabaseFile => Path.Combine(FileSystem.AppDataDirectory, "Data.db3");

        private DataServiceSQLite()
        {
        }

        private async Task Init()
        {
            if (_database == null)
            {
                //File.Delete(DatabaseFile); //This is a temporary line to delete the database every time. Remove this line to retain data.

                _database = new SQLiteAsyncConnection(DatabaseFile, Flags);

                //if (!File.Exists(DatabaseFile))
                //{
                //Create tables and add sample data if needed.
                //await _database.CreateTableAsync<Hospital>();
                //await SaveAsync<Hospital>(new Hospital { Image = "dotnet_bot.png", HospitalName = "AHospitalName",City = "ACity", Province = "AProvince", Country = "ACountry", HospitalDescription = "ADescription"});
                //await SaveAsync<Hospital>(new Hospital { Image = "loginimage.png", HospitalName = "BHospitalName", City = "BCity", Province = "BProvince", Country = "BCountry", HospitalDescription = "BDescription" });
                //await SaveAsync<Hospital>(new Hospital { Image = "welcomeimage.png", HospitalName = "CHospitalName", City = "CCity", Province = "CProvince", Country = "CCountry", HospitalDescription = "CDescription" });
                //await SaveAsync<Hospital>(new Hospital { Image = "welcomeimage.png", HospitalName = "DHospitalName", City = "DCity", Province = "DProvince", Country = "DCountry", HospitalDescription = "DDescription" });

                //var testing = await GetAsync<Hospital>();

                //await _database.CreateTableAsync<Doctor>();
                // await SaveAsync<Doctor>(new Doctor { Name = "AAAA", HospitalId = 1 });
                //await SaveAsync<Doctor>(new Doctor { Name = "BBBB", HospitalId = 2 });

                await _database.CreateTableAsync<Appointment>();
                await _database.CreateTableAsync<User>();
                //}


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
