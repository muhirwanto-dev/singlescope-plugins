﻿using Microsoft.EntityFrameworkCore;

namespace SingleScope.Repository
{
    public abstract class RepositoryBase<TContext>
        where TContext : DbContext
    {
        protected readonly TContext _context;

        protected RepositoryBase(TContext context)
        {
            _context = context;
        }
    }
}
