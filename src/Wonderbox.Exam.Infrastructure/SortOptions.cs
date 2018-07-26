namespace Wonderbox.Exam.Infrastructure
{
    public class SortOptions
    {
        public string SortField { get; }

        public string SortDirection { get; }

        public SortOptions(string sortField, string sortDirection)
        {
            SortField = sortField;
            SortDirection = sortDirection;
        }
    }
}
