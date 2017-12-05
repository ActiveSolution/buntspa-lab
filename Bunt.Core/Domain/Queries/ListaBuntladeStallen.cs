using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Bunt.Core.Domain.Queries
{
    public class ListaBuntladeStallen : IRequest<ListaBuntladeStallenResponse>
    {
    }

    public class ListaBuntladeStallenHandler : IRequestHandler<ListaBuntladeStallen, ListaBuntladeStallenResponse>
    {
        public Task<ListaBuntladeStallenResponse> Handle(ListaBuntladeStallen query,
            CancellationToken cancellationToken)
        {
            var response = new ListaBuntladeStallenResponse
            {
                BuntladeStallen = new List<ListaBuntladeStallenResponse.BuntladeStalle>
                {
                    new ListaBuntladeStallenResponse.BuntladeStalle
                    {
                        Index = 0,
                        Adress = "Testgatan 3",
                        Typ = "Lämna",
                        BuntladeNummer = 0
                    },
                    new ListaBuntladeStallenResponse.BuntladeStalle
                    {
                        Index = 1,
                        Adress = "Testgatan 4",
                        Typ = "Hämta",
                        BuntladeNummer = 1
                    }
                }
            };

            return Task.FromResult(response);
        }
    }

    public class ListaBuntladeStallenResponse
    {
        public IEnumerable<BuntladeStalle> BuntladeStallen { get; set; }

        public class BuntladeStalle
        {
            public int Index { get; set; }
            public string Adress { get; set; }
            public string Typ { get; set; }
            public int? BuntladeNummer { get; set; }
        }
    }
}