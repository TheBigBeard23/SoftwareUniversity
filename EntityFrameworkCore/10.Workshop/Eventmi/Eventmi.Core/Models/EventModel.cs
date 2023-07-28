using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Eventmi.Core.Models
{
    public class EventModel : EventDetailsModel
    {
        public int Id { get; set; }
    }
}
