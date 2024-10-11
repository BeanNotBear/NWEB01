using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB01.Domain.Specifications.DoctorSpecification
{
	public class DoctorSpeParam
	{
		private const int MaxPageSize = 50;
		public int pageIndex { get; set; } = 1;
		private int _pageSize = 9;
		public int pageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
		}
		public string? Specialization { get; set; }
		public bool IsDescending { get; set; } = false;
		public string? _search;
		public string? Search
		{
			get => _search;
			set => _search = value;
		}
	}
}
