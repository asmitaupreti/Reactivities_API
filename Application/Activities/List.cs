
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
            public readonly ILogger<List> _logger ;

            public Handler(ApplicationDbContext db, ILogger<List> logger)
            {
                _logger= logger;
                _db=db;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000,cancellationToken);
                        _logger.LogInformation($"Task {i} has completed");
                    }
                }
                catch (System.Exception)
                {
                    _logger.LogInformation($"Task was cancelled");
                    
                }

                return await _db.Activities.ToListAsync();
            }
        }
    }
}