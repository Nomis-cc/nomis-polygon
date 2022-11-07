using Nomis.Polygonscan.Interfaces.Models;

namespace Nomis.Polygonscan.Interfaces
{
    /// <summary>
    /// Polygonscan client.
    /// </summary>
    public interface IPolygonscanClient
    {
        /// <summary>
        /// Get the account balance in Wei.
        /// </summary>
        /// <param name="address">Account address.</param>
        /// <returns>Returns <see cref="PolygonscanAccount"/>.</returns>
        Task<PolygonscanAccount> GetBalanceAsync(string address);

        /// <summary>
        /// Get list of specific transactions/transfers of the given account.
        /// </summary>
        /// <typeparam name="TResult">The type of returned response.</typeparam>
        /// <typeparam name="TResultItem">The type of returned response data items.</typeparam>
        /// <param name="address">Account address.</param>
        /// <returns>Returns list of specific transactions/transfers of the given account.</returns>
        Task<IEnumerable<TResultItem>> GetTransactionsAsync<TResult, TResultItem>(string address)
            where TResult : IPolygonscanTransferList<TResultItem>
            where TResultItem : IPolygonscanTransfer;
    }
}