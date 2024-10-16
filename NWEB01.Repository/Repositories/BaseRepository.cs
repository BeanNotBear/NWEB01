﻿using Microsoft.EntityFrameworkCore;
using NWEB01.Domain.Interfaces;
using NWEB01.Domain.Specifications;
using NWEB01.Repository.Data;
using System.Linq.Expressions;

namespace NWEB01.Repository.Repositories
{
	public class BaseRepository<T, P> : IBaseRepository<T, P> where T : class
	{
		private readonly AppDbContext dbContext;

		public BaseRepository(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<T?> Add(T entity)
		{
			await dbContext.Set<T>().AddAsync(entity);
			await dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> Delete(P id)
		{
			var entity = await dbContext.Set<T>().FindAsync(id);
			if (entity != null)
			{
				dbContext.Set<T>().Remove(entity);
				await dbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<PaginationList<T>> GetAll(ISpecifications<T> spec)
		{
			var entities = dbContext.Set<T>().AsQueryable();

			// Filter
			if (spec.Criterias != null)
			{
				entities = entities.Where(spec.Criterias);
			}

			// Sort by
			if (spec.OrderBy != null)
			{
				entities = entities.OrderBy(spec.OrderBy);
			}

			// Sort Descending
			if (spec.Descending != null)
			{
				entities = entities.OrderByDescending(spec.Descending);
			}

			var totalRecords = await entities.CountAsync();
			var totalPages = (int)Math.Ceiling((double)totalRecords / spec.Take);

			// Paging
			if (spec.IsPagingEnable)
			{
				entities = entities.Skip(spec.Skip).Take(spec.Take);
			}

			var items = await entities.ToListAsync();

			var pageNumber = spec.Skip / spec.Take + 1;

			var result = new PaginationList<T>(items, pageNumber, totalPages, totalRecords);
			return result;
		}

		public async Task<T?> GetById(P id, ISpecifications<T> spec)
		{
			var entities = dbContext.Set<T>().AsQueryable();
			if (spec.Includes != null && spec.Includes.Count > 0)
			{
				foreach (var item in spec.Includes)
				{
					entities = entities.Include(item);
				}
			}
			var entity = await entities.FirstOrDefaultAsync(x => EF.Property<P>(x, "Id").Equals(id));
			return entity;
		}

		public async Task<T?> Update(P id, T entity)
		{
			var existingEntity = await dbContext.Set<T>().FindAsync(id);
			if (existingEntity != null)
			{
				dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
				await dbContext.SaveChangesAsync();
			}
			return existingEntity;
		}
	}
}
