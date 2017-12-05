using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bunt.Core.Infrastructure;
using Dapper;
using MediatR;

namespace Bunt.Core.Domain.Queries
{
    public class ListaBuntladeStallen
    {
        public class Query : IRequest<IEnumerable<BuntladeStalle>>
        {
        }

        public class Handler : IRequestHandler<Query, IEnumerable<BuntladeStalle>>
        {
            private readonly IConnectionFactory _connectionFactory;

            public Handler(IConnectionFactory connectionFactory)
            {
                _connectionFactory = connectionFactory;
            }

            public async Task<IEnumerable<BuntladeStalle>> Handle(Query query, CancellationToken cancellationToken)
            {
                using (var conn = _connectionFactory.Create())
                {
                    return await conn.QueryAsync<BuntladeStalle>("SELECT * FROM BuntladeStalle");
                }
            }
        }

        public class BuntladeStalle
        {
            public Guid Id { get; set; }
            public int Index { get; set; }
            public string Adress { get; set; }
            public string Typ { get; set; }
            public int? BuntladeNummer { get; set; }
        }
    }
}