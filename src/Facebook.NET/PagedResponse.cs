using System;
using System.Collections.Generic;
using System.Linq;

namespace Facebook
{
    public class PagedResponse
    {
        public PagedResponse() : this(0, 0) { }

        public PagedResponse(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        private int _pageNumber;
        public int PageNumber
        {
            get => _pageNumber;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Argument cannot be negative.");
                }

                _pageNumber = value;
            }
        }

        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Argument cannot be negative.");
                }

                _pageSize = value;
            }
        }

        public int StartItemIndex => PageNumber > 0 ? (PageNumber - 1) * PageSize : 0;
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
