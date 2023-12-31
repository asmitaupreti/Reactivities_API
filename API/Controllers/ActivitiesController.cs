using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController: BaseApiController
    {
       
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());

        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
             return await Mediator.Send(new Details.Query{Id= id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody]Activity activity)
        {
             return Ok(await Mediator.Send(new Create.Command{Activity = activity}));
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> EditActivity(Guid id,[FromBody]Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}