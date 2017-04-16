using System;
using System.Text;

namespace Facebook.Requests
{
    public class PagedRequest : Request
    {
        public DateTime? Since { get; set; }
        public DateTime? Until { get; set; }
        public int? PaginationLimit { get; set; }

        internal override void Format(StringBuilder builder)
        {
            if (PaginationLimit.HasValue && PaginationLimit != -1)
            {
                builder.AppendFormat("limit={0}&", PaginationLimit);
            }

            if (Since.HasValue)
            {
                builder.AppendFormat("since={0}&", UnixTimestamp(Since.Value));
            }

            if (Until.HasValue)
            {
                builder.AppendFormat("until={0}&", UnixTimestamp(Until.Value));
            }
        }

        private static long UnixTimestamp(DateTime dateTime)
        {
            TimeSpan timeSince1970 = (dateTime - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSince1970.TotalSeconds;
        }
    }
}
