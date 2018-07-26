namespace Wonderbox.Exam.ViewModels
{
    public class SearchFilterVM
    {
        public string SearchText { get; set; }

        public string SortField { get; set; }

        public string SortDirection { get; set; }

        public int Page { get; set; } = 1;
    }
}
