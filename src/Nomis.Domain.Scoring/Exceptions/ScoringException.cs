using System.Net;

using Nomis.Domain.Exceptions;

namespace Nomis.Domain.Scoring.Exceptions
{
    /// <summary>
    /// Exception related to scoring.
    /// </summary>
    public class ScoringException :
        DomainException
    {
        /// <summary>
        /// Initialize <see cref="ScoringException"/>.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="errors">Error list.</param>
        /// <param name="statusCode">HTTP status code.</param>
        public ScoringException(string message, List<string>? errors = default, HttpStatusCode statusCode = default)
            : base(message, errors, statusCode)
        {
        }
    }
}