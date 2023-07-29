namespace Eventmi.Core.Services
{

    using Eventmi.Core.Contracts;
    using Eventmi.Core.Models;
    using Eventmi.Infrastructure.Data.Common;
    using Eventmi.Infrastructure.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class EventService : IEventService
    {
        private readonly IRepository repo;
        public EventService(IRepository _repo)
        {
            repo = _repo;
        }
        public async Task AddAsync(EventModel model)
        {
            Event entity = new Event()
            {
                Id = model.Id,
                Name = model.Name,
                Start = model.Start,
                End = model.End,
                Place = model.Place
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await repo.DeleteAsync<Event>(id);
            repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Event>()
                .Select(e => new EventModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    End = e.End,
                    Place = e.Place
                })
                .OrderBy(e => e.Start)
                .ToListAsync();
        }

        public async Task<EventModel> GetEventAsync(int id)
        {
            Event entity = await repo.GetByIdAsync<Event>(id);

            if (entity == null)
            {
                throw new ArgumentException("The Id does not exist", nameof(id));
            }

            return new EventModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Start = entity.Start,
                End = entity.End,
                Place = entity.Place
            };
        }

        public async Task UpdateASync(EventModel model)
        {
            var entity = await repo.GetByIdAsync<Event>(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("The Id does not exist", nameof(model.Id));
            }

            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Start = model.Start;
            entity.End = model.End;
            entity.Place = model.Place;

            await repo.SaveChangesAsync();
                    
        }
    }
}
