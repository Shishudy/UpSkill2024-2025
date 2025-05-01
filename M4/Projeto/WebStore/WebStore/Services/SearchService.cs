namespace WebStore.Services
{
	public class SearchService
	{
		private string _searchTerm = null!;

		public event Action<string>? SearchTriggered;

		public string SearchTerm
		{
			get => _searchTerm;
			set => _searchTerm = value;
		}

		public void TriggerSearch()
		{
			if (SearchTerm != null)
				SearchTriggered?.Invoke(_searchTerm);
		}
	}
}
