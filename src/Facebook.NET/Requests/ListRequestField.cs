using System;
using System.Text;

namespace Facebook.Requests
{
    public class ListRequestField : RequestField
    {
        private const int MaxLimit = 100;

        /// <summary>
        /// Gets the maximum number of objects the request should return, or null if no limit is specified.
        /// </summary>
        public int? RequestLimit { get; }

        /// <summary>
        /// Gets whether the request should provide a summary of the data, or null if no summary is specified.
        /// </summary>
        public bool? ShowSummary { get; }

        /// <summary>
        /// Constructs a request for a list of objects without a limit or summary.
        /// </summary>
        /// <param name="fieldName">The name of the field that will be listed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is empty or whitespace.</exception>
        public ListRequestField(string fieldName) : this(fieldName, null, null) { }

        /// <summary>
        /// Constructs a request for a list of objects optionally with a limit or summary.
        /// </summary>
        /// <param name="fieldName">The name of the field that will be listed.</param>
        /// <param name="requestLimit">The maximum number of objects the request should return or null if no limit is specified.</param>
        /// <param name="showSummary">Whether the request should provide a summary of the data or null if no summary is specified.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is empty or whitespace.</exception>
        private ListRequestField(string fieldName, int? requestLimit, bool? showSummary) : base(fieldName)
        {
            RequestLimit = requestLimit;
            ShowSummary = showSummary;
        }

        /// <summary>
        /// Constructs a request for a list of objects with a limit. This request is a new unique object that inherits the old values of <see cref="FieldName"/> and <see cref="ShowSummary"/>.
        /// </summary>
        /// <param name="limit">The maximum number of fields the request should return.</param>
        /// <returns>A unique request that has a maximum number of fields that the request should return.</returns>
        /// <exception cref="InvalidOperationException">The request already has a limit specified.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="limit"/> is less than zero.
        /// -or-
        /// <paramref name="limit"/> is greater than the maximum limit of 100 set by Facebook.
        /// </exception>
        public ListRequestField Limit(int limit)
        {
            if (RequestLimit != null)
            {
                throw new InvalidOperationException("Request already has a limit.");
            }
            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Argument cannot be negative.");
            }
            if (limit > MaxLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), limit, $"Argument cannot be greater than {MaxLimit}");
            }

            return new ListRequestField(FieldName, limit, ShowSummary);
        }

        /// <summary>
        /// Constructs a request for a list of objects with a summary. This request is a new unique object that inherits the old values of <see cref="FieldName"/> and <see cref="RequestLimit"/>.
        /// </summary>
        /// <param name="summary">Whether the request should provide a summary of the data.</param>
        /// <returns>A unique request that has a specified summary.</returns>
        /// <exception cref="InvalidOperationException">The request already has a summary specified.</exception>
        public ListRequestField Summary(bool summary)
        {
            if (ShowSummary != null)
            {
                throw new InvalidOperationException("Request already has a summary.");
            }

            return new ListRequestField(FieldName, RequestLimit, summary);
        }

        internal override void Format(StringBuilder builder)
        {
            base.Format(builder);
            if (RequestLimit.HasValue)
            {
                builder.Append($".limit({RequestLimit})");
            }
            if (ShowSummary.HasValue)
            {
                builder.Append($".summary({ShowSummary})");
            }
        }
    }
}

