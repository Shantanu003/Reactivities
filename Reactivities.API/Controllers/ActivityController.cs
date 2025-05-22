using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Reactivities.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : BaseController
    {
        private readonly AppDbContext _appDbContext;
        public ActivityController(AppDbContext context)
        {
            _appDbContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(int id)
        {
            return await _appDbContext.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(string id)
        {
            var activity = await _appDbContext.Activities.FindAsync(id);

            if (activity == null)
            {
                return NotFound();
            }
            return activity;
        }
    }
}
