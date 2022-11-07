namespace Nomis.Domain
{
    /// <summary>
    /// Database seeder.
    /// </summary>
    public interface IDatabaseSeeder
    {
        /// <summary>
        /// Initialize filling the database with data.
        /// </summary>
        void Initialize();
    }
}