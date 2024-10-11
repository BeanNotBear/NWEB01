using Microsoft.EntityFrameworkCore;
using NWEB01.Domain.Entities;
using NWEB01.Domain.Interfaces;
using NWEB01.Domain.Specifications;
using NWEB01.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Repository.Repositories
{
	public class UserRepository : IUserRepository
	{

		private readonly AppDbContext dbContext;

		public UserRepository(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<User?> Add(User entity)
		{
			await dbContext.Users.AddAsync(entity);
			await dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<int> CountItems()
		{
			int totalItems = await dbContext.Users.CountAsync();
			return totalItems;
		}

		public Task<bool> Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<PaginationList<User>> GetAll(ISpecifications<User> spec)
		{
			var query = dbContext.Users.AsQueryable();

			if (spec.Criterias != null)
			{
				query = query.Where(spec.Criterias);
			}

			if (spec.Includes != null)
			{
				foreach (var item in spec.Includes)
				{
					query = query.Include(item);
				}
			}

			if (spec.OrderBy != null)
			{
				query = query.OrderByDescending(spec.OrderBy);
			}

			if (spec.Descending != null)
			{
				query = query.OrderBy(spec.Descending);
			}

			var totalRecords = await query.CountAsync();

			if (spec.IsPagingEnable)
			{
				query = query.Skip(spec.Skip).Take(spec.Take);
			}
			
			var totalPage = (int)Math.Ceiling((double)totalRecords / spec.Take);
			int pageIndex = spec.Skip / spec.Take + 1;

			var items = await query.ToListAsync();

			var result = new PaginationList<User>(items, pageIndex, totalPage, totalRecords);

			return result;
		}

		public Task<User?> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<User?> Update(Guid id, User entity)
		{
			throw new NotImplementedException();
		}
	}
}
