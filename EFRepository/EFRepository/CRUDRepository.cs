﻿using EFRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace EFRepository
{
    public class CRUDRepository<TEntity, TypeId, BaseDbContext> : ICRUDRepository<TEntity, TypeId> where BaseDbContext : DbContext where TEntity : class
    {
        protected BaseDbContext db;
        protected DbSet<TEntity> dbSet;

        public CRUDRepository(BaseDbContext _db)
        {
            db = _db;
            dbSet = db.Set<TEntity>();
        }

        public async Task<int> CountAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().CountAsync(match);
        }

        public async Task<long> CountLongAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().LongCountAsync();
        }

        public async Task<long> CountLongAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().LongCountAsync(match);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task CreateRangeAsync(List<TEntity> entities)
        {
            await db.Set<TEntity>().AddRangeAsync(entities);
            await db.SaveChangesAsync();
        }

        public async Task<TEntity> FindAsTrackingAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().FirstOrDefaultAsync(match);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(match);
        }

        public async Task<List<TEntity>> FindListAsTrackingAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().Where(match).ToListAsync();
        }

        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().Where(match).ToListAsync();
        }

        public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> match, int count, int skip)
        {
            return await db.Set<TEntity>().AsNoTracking().Where(match).Skip(skip).Take(count).ToListAsync();
        }

        public async Task<TEntity> FirstAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsTrackingAsync(TypeId Id)
        {
            return await db.Set<TEntity>().FindAsync(Id);
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(match) != null ? true : false;
        }

        public async Task<TEntity> LastAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().LastOrDefaultAsync();
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task RemoveRangeAsync(List<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
            await db.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            db.Set<TEntity>().UpdateRange(entities);
            await db.SaveChangesAsync();
        }
    }
}