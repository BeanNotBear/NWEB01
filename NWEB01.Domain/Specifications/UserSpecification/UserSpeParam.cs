using System.Text.RegularExpressions;


namespace NWEB01.Domain.Specifications
{
	public class UserSpeParam
	{
		private const int MaxPageSize = 50;
		public int pageIndex { get; set; } = 1;
		private int _pageSize = 9;
		public int pageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
		}
        public int? Role { get; set; }
        public bool IsAcending { get; set; } = true;
		public string? _search;
		public string? Search
		{
			get => _search;
			set => _search = value;
		}
	}
}
