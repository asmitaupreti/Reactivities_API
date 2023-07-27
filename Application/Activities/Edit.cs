using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using FluentValidation;

namespace Application.Activities
{
    public class Edit
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
            private readonly IMapper _mapper;

            public Handler(ApplicationDbContext db,IMapper mapper)
            {
                _mapper = mapper;
                _db=db;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _db.Activities.FindAsync(request.Activity.Id);
                // activity.Title = request.Activity.Title ?? activity.Title;
               _mapper.Map(request.Activity,activity); // we are mapping command bhitra ko activity to activity
                await _db.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}