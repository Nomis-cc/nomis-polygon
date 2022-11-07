using System.ComponentModel.DataAnnotations.Schema;

namespace Nomis.Utils.Contracts.Properties
{
    /// <inheritdoc cref="IHasLastModifiedOn{TPropertyType}"/>
    public interface IHasLastModifiedOn :
        IHasLastModifiedOn<DateTime?>
    {
    }

    /// <summary>
    /// Has property with name <see cref="LastModifiedOn"/>.
    /// </summary>
    /// <typeparam name="TPropertyType">The property type.</typeparam>
    public interface IHasLastModifiedOn<TPropertyType> :
        IHasProperty
    {
        /// <summary>
        /// Last modified date.
        /// </summary>
        TPropertyType LastModifiedOn { get; set; }

        /// <summary>
        /// Is modified.
        /// </summary>
        [NotMapped]
        public bool IsModified => LastModifiedOn != null;
    }
}