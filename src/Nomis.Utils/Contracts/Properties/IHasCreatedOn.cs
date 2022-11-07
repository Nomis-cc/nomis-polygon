namespace Nomis.Utils.Contracts.Properties
{
    /// <inheritdoc cref="IHasCreatedOn{TPropertyType}"/>
    public interface IHasCreatedOn :
        IHasCreatedOn<DateTime>
    {
    }

    /// <summary>
    /// Has property with name <see cref="CreatedOn"/>.
    /// </summary>
    /// <typeparam name="TPropertyType">The property type.</typeparam>
    public interface IHasCreatedOn<TPropertyType> :
        IHasProperty
    {
        /// <summary>
        /// Creation date.
        /// </summary>
        TPropertyType CreatedOn { get; set; }
    }
}