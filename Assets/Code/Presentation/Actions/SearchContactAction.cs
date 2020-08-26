namespace Code.Presentation.Actions
{
    public class SearchContactAction
    {
        public string Search { get; }

        public SearchContactAction(string search)
        {
            Search = search;
        }
    }
}