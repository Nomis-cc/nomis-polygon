using System.ComponentModel.DataAnnotations.Schema;

namespace Nomis.Utils.Contracts.Properties
{
    /// <inheritdoc cref="IHasDeletedOn{TPropertyType}"/>
    public interface IHasDeletedOn :
        IHasDeletedOn<DateTime?>
    {
    }

    /// <summary>
    /// Has property with name <see cref="DeletedOn"/>.
    /// </summary>
    /// <typeparam name="TPropertyType">The property type.</typeparam>
    public interface IHasDeletedOn<TPropertyType> :
        IHasProperty
    {
        /// <summary>
        /// Deletion date.
        /// </summary>
        public TPropertyType DeletedOn { get; set; }

        /// <summary>
        /// Is deleted.
        /// </summary>
        [NotMapped]
        public bool IsDeleted => DeletedOn != null;
    }
}