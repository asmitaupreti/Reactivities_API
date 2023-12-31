using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command:IRequest
        {
            public Activity Activity { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
              
            }
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
                await _db.Activities.AddAsync(request.Activity);
                await _db.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}