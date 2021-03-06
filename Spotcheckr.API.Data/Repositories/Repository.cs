﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Spotcheckr.API.Data.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly SpotcheckrCoreContext Context;

		public Repository(SpotcheckrCoreContext context)
		{
			Context = context;
		}

		public TEntity Get(int id) => Context.Set<TEntity>().Find(id) ?? throw new InvalidOperationException($"Record {id} not found.");

		public async Task<TEntity> GetAsync(int id) => await Context.Set<TEntity>().FindAsync(id) ?? throw new InvalidOperationException($"Record {id} not found.");

		public IEnumerable<TEntity> GetAll() => Context.Set<TEntity>().ToList();

		public async Task<IEnumerable<TEntity>> GetAllAsync() => await Context.Set<TEntity>().ToListAsync();

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().Where(predicate);

		public void Add(TEntity entity) => Context.Set<TEntity>().Add(entity);

		public void AddRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().AddRange(entities);

		public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

		public void RemoveRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().RemoveRange(entities);
	}
}
