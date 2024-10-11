using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Domain.Specifications
{
	public class PaginationList<T>
	{
		public List<T> Items { get;}
        public int PageNumber { get;}
        public int TotalPage { get; }
        public int TotalRecord { get;}
        public bool IsHasNextPage => PageNumber < TotalPage;
		public bool IsHasPreviousPage => PageNumber > 1;

		public PaginationList(List<T> items, int pageNumber, int totalPage, int totalRecord)
		{
			Items = items;
			PageNumber = pageNumber;
			TotalPage = totalPage;
			TotalRecord = totalRecord;
		}
	}
}
