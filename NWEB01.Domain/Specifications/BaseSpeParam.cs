using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Domain.Specifications
{
	public class BaseSpeParam
	{
		private const int MaxPageSize = 50;
		public int pageIndex { get; set; } = 1;
		private int _pageSize = 9;
		public int pageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
		}
		public bool IsDescending { get; set; } = false;
		
	}
}
