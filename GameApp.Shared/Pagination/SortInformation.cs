using System.ComponentModel;

namespace GameApp.Shared.Pagination
{
    public class SortInformation
    {
        public string PropertyName { get; set; }

        public ListSortDirection SortDirection { get; set; }
    }
}