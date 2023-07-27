using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
         public class Command:IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            public readonly ApplicationDbContext _db;
           

            public Handler(ApplicationDbContext db)
            {
               
                _db=db;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _db.Activities.FindAsync(request.Id);
                _db.Remove(activity);
                await _db.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}