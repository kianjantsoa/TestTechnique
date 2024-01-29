using AutoMapper;
using MediatR;
using TestTechnique.Models;
using TestTechnique.Models.DTO;

namespace TestTechnique.Handler;

public class NewProject
{
    public class Request : ProjectDTO , IRequest<string>{}
    public class Handler : IRequestHandler<Request, string>
    {
        private readonly PostgresContext _context;
        private readonly IMapper _mapper;
        public Handler(PostgresContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<string> Handle(Request request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(_context);
            try
            {
                var newItem = _mapper.Map<Project>(request);
                _context.Projets.Add(newItem);
                _context.SaveChanges();
                return request.Uuid;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
