namespace NWEB01.Domain.Specifications
{
    public class DoctorSpeParam : BaseSpeParam
    {
		private string? _search;
		public string? Search
		{
			get => _search;
			set => _search = value;
		}
		public string? Specialization { get; set; }
    }
}
