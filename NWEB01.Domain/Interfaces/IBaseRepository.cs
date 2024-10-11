using NWEB01.Domain.Entities;
using NWEB01.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Domain.Interfaces
{
	public interface IBaseRepository<T, P>
	{
		Task<PaginationList<T>> GetAll(ISpecifications<T> spec);
		Task<T?> GetById(P id, Expression<Func<T, object>> include);
		Task<T?> Add(T entity);
		Task<T?> Update(P id, T entity);
		Task<bool> Delete(P id);
	}
}
