using Eventmi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventmi.Core.Contracts
{
    public interface IEventService
    {
        Task AddAsync(EventModel model);

        Task DeleteAsync(int id);

        Task UpdateASync(EventModel model);

        Task<IEnumerable<EventModel>> GetAllAsync();

        Task<EventDetailsModel> GetEventAsync(int id);

    }
}
