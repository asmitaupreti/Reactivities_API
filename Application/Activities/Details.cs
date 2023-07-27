using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query:IRequest<Activity>
        {
            public Guid Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, Activity>
        {
            public readonly ApplicationDbContext _db;

            public Handler(ApplicationDbContext db)
            {
                _db=db;
            }
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _db.Activities.FindAsync(request.Id);
            }
        }
    }
}