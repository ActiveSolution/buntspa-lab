using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bunt.Core.Infrastructure;
using Dapper;
using MediatR;

namespace Bunt.Core.Domain.Queries
{
    public class ListaBuntladeStallen : IRequest<ListaBuntladeStallenResponse>
    {
    }

    public class ListaBuntladeStallenHandler : IRequestHandler<ListaBuntladeStallen, ListaBuntladeStallenResponse>
    {
        private readonly IConnectionFactory _connectionFactory;

        public ListaBuntladeStallenHandler(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<ListaBuntladeStallenResponse> Handle(ListaBuntladeStallen query, CancellationToken cancellationToken)
        {
            using (var conn = _connectionFactory.Create())
            {
                var buntladeStallen = await conn.QueryAsync<ListaBuntladeStallenResponse.BuntladeStalle>("SELECT * FROM BuntladeStalle");

                var response = new ListaBuntladeStallenResponse
                {
                    BuntladeStallen = buntladeStallen
                };

                return response;
            }
        }
    }

    public class ListaBuntladeStallenResponse
    {
        public IEnumerable<BuntladeStalle> BuntladeStallen { get; set; }

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