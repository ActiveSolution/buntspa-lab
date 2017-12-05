using System;
using System.Threading;
using System.Threading.Tasks;
using Bunt.Core.Infrastructure;
using Dapper;
using MediatR;

namespace Bunt.Core.Domain.Commands
{
    public class TaBortBuntladeStalle
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IConnectionFactory _connectionFactory;

            public Handler(IConnectionFactory connectionFactory)
            {
                _connectionFactory = connectionFactory;
            }

            public async Task Handle(Command command, CancellationToken cancellationToken)
            {
                using (var conn = _connectionFactory.Create())
                {
                    await conn.ExecuteAsync("DELETE BuntladeStalle WHERE Id = @Id", command);
                }
            }
        }
    }
}