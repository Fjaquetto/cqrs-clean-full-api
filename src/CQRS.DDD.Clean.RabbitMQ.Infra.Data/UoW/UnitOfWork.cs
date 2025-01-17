﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BancoMaster.Domain.Interfaces;
using Teste.BancoMaster.Infra.Data.Context;

namespace Teste.BancoMaster.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TesteContext _context;

        public UnitOfWork(TesteContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
