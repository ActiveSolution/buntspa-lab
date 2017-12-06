using System;
using System.Threading;
using System.Threading.Tasks;
using Bunt.Core.Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bunt.Core.Domain.Commands
{
    public class SparaBuntladeStalle
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Adress { get; set; }
            public int Typ { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly BuntDbContext _db;

            public Handler(BuntDbContext db)
            {
                _db = db;
            }

            public async Task Handle(Command command, CancellationToken cancellationToken)
            {
                var buntladeStalle = await _db.BuntladeStallen.SingleOrDefaultAsync(b => b.Id == command.Id, cancellationToken);

                if (buntladeStalle == null)
                {
                    buntladeStalle = new BuntladeStalle(command.Id, command.Adress, command.Typ);
                    _db.Add(buntladeStalle);
                }
                else
                {
                    buntladeStalle.Redigera(command.Adress, command.Typ);
                }

                await _db.SaveChangesAsync(cancellationToken);
            }        
        }
    }
}