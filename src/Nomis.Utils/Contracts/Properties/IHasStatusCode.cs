namespace Nomis.Utils.Contracts.Properties
{
    /// <inheritdoc cref="IHasStatusCode{TPropertyType}"/>
    public interface IHasStatusCode :
        IHasStatusCode<int>
    {
    }

    /// <summary>
    /// Has property with name <see cref="StatusCode"/>.
    /// </summary>
    /// <typeparam name="TPropertyType">Property type.</typeparam>
    public interface IHasStatusCode<TPropertyType> :
        IHasProperty
    {
        /// <summary>
        /// HTTP status code.
        /// </summary>
        TPropertyType StatusCode { get; set; }
    }
}