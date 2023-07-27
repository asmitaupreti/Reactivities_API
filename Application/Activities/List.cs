
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query:IRequest<List<Activity>>{}

        public class Handler:IRequestHandler<Query,List<Activity>>
        {
           
            public readonly ApplicationDbContext _db;
           

            public Handler(ApplicationDbContext db, ILogger<List> logger)
            {
                
                _db=db;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _db.Activities.ToListAsync();
            }
        }
    }
}