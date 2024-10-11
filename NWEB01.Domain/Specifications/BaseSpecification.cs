using NWEB01.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Domain.Specifications
{
	public class BaseSpecification<T> : ISpecifications<T>
	{
		public BaseSpecification()
		{
		}

		public BaseSpecification(Expression<Func<T, bool>> criterias)
		{
			Criterias = criterias;
		}

		public Expression<Func<T, bool>> Criterias { get; private set; }

		public List<Expression<Func<T, object>>> Includes { get; private set; } = new List<Expression<Func<T, object>>> { };

		public Expression<Func<T, object>> OrderBy { get; private set; }

		public Expression<Func<T, object>> Ascending { get; private set; }

		public int Take { get; private set; }

		public int Skip { get; private set; }

		public bool IsPagingEnable { get; private set; }

		public void AddInclude(Expression<Func<T, object>> includeExpression)
		{
			Includes.Add(includeExpression);
		}

		public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
		{
			OrderBy = orderByExpression;
		}

		public void AddAscending(Expression<Func<T, Object>> ascendingExpression)
		{
			Ascending = ascendingExpression;
		}

		public void ApplyPaging(int take, int skip)
		{
			Take = take;
			Skip = skip;
		}
	}
}
