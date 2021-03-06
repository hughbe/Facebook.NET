﻿using System;
using System.Text;

namespace Facebook.Requests
{
    public class PagedRequest : Request
    {
        private DateTime? _since;
        private DateTime? _until;

        /// <summary>
        /// Gets or sets the lower bound of the created_time of data to fetch.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="value"/> is greater than <see cref="DateTime.UtcNow"/>.
        /// -or-
        /// <paramref name="value"/> is greater than <see cref="Until"/>.
        /// </exception>
        public DateTime? Since
        {
            get => _since;
            set
            {
                if (value.HasValue)
                {
                    DateTime utcDate = value.Value.ToUniversalTime();
                    if (utcDate >= DateTime.UtcNow)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, "Since cannot be greater than or equal to now.");
                    }
                    if (Until != null && utcDate >= Until)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, "Since cannot be greater than or equal to until.");
                    }

                    _since = utcDate;
                }
                else
                {
                    _since = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the upper bound of the created_time of data to fetch.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="value"/> is greater than <see cref="DateTime.UtcNow"/>.
        /// -or-
        /// <paramref name="value"/> is greater than <see cref="Until"/>.
        /// </exception>
        public DateTime? Until
        {
            get => _until;
            set
            {
                if (value.HasValue)
                {
                    DateTime utcDate = value.Value.ToUniversalTime();
                    if (utcDate >= DateTime.UtcNow)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, "Until cannot be greater than or equal to now.");
                    }
                    if (Since != null && utcDate <= Since)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, "Until cannot be less than or equal to since.");
                    }

                    _until = utcDate;
                }
                else
                {
                    _until = value;
                }
            }
        }

        private int? _paginationLimit;

        /// <summary>
        /// Gets or sets the maximum number of results to return in each page.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than or equal to zero.</exception>
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
