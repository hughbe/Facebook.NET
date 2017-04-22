using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Facebook
{
    public class PagedResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int StartItemIndex => (PageNumber - 1) * PageSize;
        public int EndItemIndex => PageNumber * PageSize;
    }

    public abstract class PagedResponse<T> : PagedResponse
    {
        public IEnumerable<T> Data { get; set; }

        public abstract PagedResponse<T> PreviousPage();
        public abstract PagedResponse<T> NextPage();

        public IEnumerable<T> AllData() => AllPages().Flatten();

        public IEnumerable<PagedResponse<T>> AllPages()
        {
            yield return this;
            foreach (PagedResponse<T> remainingPages in AllPagesAfterThis())
            {
                yield return remainingPages;
            }
        }

        public IEnumerable<PagedResponse<T>> AllPagesAfterThis()
        {
            PagedResponse<T> response = NextPage();
            while (response != null)
            {
                yield return response;
                response = response.NextPage();
            }
        }
    }

    public static class PagedResponseExtensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<PagedResponse<T>> responses)
        {
            return responses.SelectMany(response => response.Data);
        }
    }
}
