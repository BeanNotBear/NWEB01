namespace NWEB01.API.ApiResponse
{
	public class ErrorResponse
	{
		public Guid Id { get; } = Guid.NewGuid();
		public string Error { get; private set; } = string.Empty;
		public List<string> Details { get; } = new List<string>();
		public DateTime Timestamp { get; set; } = DateTime.Now;

		public void AddError(string error)
		{
			this.Error = error;
		}

		public void AddDetailsError(string detail)
		{
			this.Details.Add(detail);
		}
	}
}
