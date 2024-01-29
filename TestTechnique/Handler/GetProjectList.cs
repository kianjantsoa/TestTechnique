using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTechnique.Models;
using TestTechnique.Models.DTO;

namespace TestTechnique.Handler
{
    public class GetProjectList
    {
        public record Request(): IRequest<List<ProjectDTO>>;

        public class Handler : IRequestHandler<Request, List<ProjectDTO>>
        {
            private readonly PostgresContext _context;
            private readonly IMapper _mapper;
            public Handler(PostgresContext context,IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<List<ProjectDTO>> Handle(Request request, CancellationToken cancellationToken)
            {
                ArgumentNullException.ThrowIfNull(request);
                ArgumentNullException.ThrowIfNull(_context);

                var projects =  await _context.Projets.ToListAsync(cancellationToken);
                return _mapper.Map<List<ProjectDTO>>(projects);
            }
        }
    }
}
