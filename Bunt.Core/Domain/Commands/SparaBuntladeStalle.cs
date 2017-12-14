﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bunt.Core.Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

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
                    var lastIndex = await _db.BuntladeStallen.Select(b => b.Index).DefaultIfEmpty(0).MaxAsync(index => index);
                    buntladeStalle = new BuntladeStalle(command.Id, command.Adress, command.Typ, lastIndex + 1);
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