using System;
using System.Text;

namespace Facebook.Requests
{
    public class PagedRequest : Request
    {
        private DateTime? _since;
        public DateTime? Since
        {
            get => _since;
            set
            {
                if (value >= DateTime.UtcNow)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Since cannot be greater than or equal to now.");
                }
                if (Until != null && value >= Until)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Since cannot be greater than or equal to until.");
                }

                _since = value;
            }
        }

        private DateTime? _until;
        public DateTime? Until
        {
            get => _until;
            set
            {
                if (value >= DateTime.UtcNow)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Until cannot be greater than or equal to now.");
                }
                if (Since != null && value <= Since)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Until cannot be less than or equal to since.");
                }

                _until = value;
            }
        }

        private int? _paginationLimit;
        public int? PaginationLimit
        {
            get => _paginationLimit;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Value cannot be zero or negative.");
                }

                _paginationLimit = value;
            }
        }

        internal override void Format(StringBuilder builder)
        {
            if (PaginationLimit.HasValue)
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
