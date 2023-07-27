using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController: BaseApiController
    {
        private readonly ApplicationDbContext _db;
       
        public ActivitiesController(ApplicationDbContext db)
        {
            _db = db;
  
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _db.Activities.ToListAsync();
        }



        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _db.Activities.FindAsync(id);
        }
    }
}