namespace Nomis.Utils.Contracts.Properties
{
    /// <summary>
    /// Has property with name <see cref="Version"/>.
    /// </summary>
    public interface IHasVersion :
        IHasProperty
    {
        /// <summary>
        /// Version.
        /// </summary>
        int Version { get; }
    }
}
