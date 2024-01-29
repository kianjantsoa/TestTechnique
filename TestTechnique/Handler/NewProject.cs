using AutoMapper;
using MediatR;
using TestTechnique.Models;
using TestTechnique.Models.DTO;

namespace TestTechnique.Handler;

public class NewProject
{
    public class Request : ProjectDTO , IRequest<bool>{}
    public class Handler : IRequestHandler<Request, bool>
    {
        private readonly PostgresContext _context;
        private readonly IMapper _mapper;
        public Handler(PostgresContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> Handle(Request request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(_context);
            _context.Projets.Add(_mapper.Map<Project>(request));
            _context.SaveChanges();
            return true;
        }
    }
}
