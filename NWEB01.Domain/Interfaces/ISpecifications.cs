using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Domain.Interfaces
{
	public interface ISpecifications<T>
	{
		// Filter
		Expression<Func<T, bool>> Criterias { get; }

		// Include
		List<Expression<Func<T, object>>> Includes { get; }

		// Order By
		Expression<Func<T, object>> OrderBy { get; }

		// Order By Ascending
		Expression<Func<T, object>> Ascending { get; }

		// Take
		int Take { get; }

		// Skip
		int Skip { get; }

		// Is Paging
		bool IsPagingEnable { get; }
	}
}
