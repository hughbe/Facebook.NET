using System;
using System.Text;

namespace Facebook.Requests
{
    public class ListRequestField : RequestField
    {
        private const int MaxLimit = 100;

        public int? RequestLimit { get; }
        public bool? ShowSummary { get; }

        public ListRequestField(string fieldName) : this(fieldName, null, null) { }

        private ListRequestField(string fieldName, int? requestLimit, bool? showSummary) : base(fieldName)
        {
            RequestLimit = requestLimit;
            ShowSummary = showSummary;
        }

        public ListRequestField Limit(int limit)
        {
            if (RequestLimit != null)
            {
                throw new InvalidOperationException("Request already has a limit.");
            }
            if (limit <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Argument cannot be zero or negative.");
            }
            if (limit > MaxLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), limit, $"Argument cannot be greater than {MaxLimit}");
            }

            return new ListRequestField(FieldName, limit, ShowSummary);
        }

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

