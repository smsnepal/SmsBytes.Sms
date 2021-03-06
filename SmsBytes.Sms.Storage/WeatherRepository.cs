using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using SmsBytes.Sms.Common.Uuid;
using Microsoft.EntityFrameworkCore;

namespace SmsBytes.Sms.Storage
{
    public interface IWeatherRepository
    {
        Task<IEnumerable<Weather>> GetAll();
        Task<Weather> FindById(string id);
        Task<Weather> Create([NotNull] Weather weather);
        Task Delete(string id);
    }

    public class WeatherRepository : IWeatherRepository
    {
        private readonly ApplicationContext _db;
        private readonly IUuidService _uuid;

        public WeatherRepository(ApplicationContext db, IUuidService uuid)
        {
            _db = db;
            _uuid = uuid;
        }

        public async Task<IEnumerable<Weather>> GetAll()
        {
            return (await _db.Weathers.ToListAsync()).AsEnumerable();
        }

        public Task<Weather> FindById(string id)
        {
            return _db.Weathers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Weather> Create(Weather weather)
        {
            weather.Id = _uuid.GenerateUuId("weather");
            var result = await _db.Weathers.AddAsync(weather);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(string id)
        {
            var entities = _db.Weathers.Where(w => w.Id == id);
            _db.Weathers.RemoveRange(entities);
            await _db.SaveChangesAsync();
        }
    }
}
