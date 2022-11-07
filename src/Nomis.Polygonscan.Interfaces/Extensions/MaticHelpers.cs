using System.Numerics;

using Nomis.Polygonscan.Interfaces.Models;

namespace Nomis.Polygonscan.Interfaces.Extensions
{
    /// <summary>
    /// Extension methods for polygon.
    /// </summary>
    public static class MaticHelpers
    {
        /// <summary>
        /// Convert Wei value to Matic.
        /// </summary>
        /// <param name="valueInWei">Wei.</param>
        /// <returns>Returns total Matic.</returns>
        public static decimal ToMatic(this string valueInWei)
        {
            if (!ulong.TryParse(valueInWei, out ulong wei))
            {
                return 0;
            }

            return new BigInteger(wei).ToMatic();
        }

        /// <summary>
        /// Convert Wei value to Matic.
        /// </summary>
        /// <param name="valueInWei">Wei.</param>
        /// <returns>Returns total Matic.</returns>
        public static decimal ToMatic(this ulong valueInWei)
        {
            return new BigInteger(valueInWei).ToMatic();
        }

        /// <summary>
        /// Convert Wei value to Matic.
        /// </summary>
        /// <param name="valueInWei">Wei.</param>
        /// <returns>Returns total Matic.</returns>
        public static decimal ToMatic(this BigInteger valueInWei)
        {
            return (decimal)valueInWei * (decimal)0.000_000_000_000_000_001;
        }

        /// <summary>
        /// Convert Wei value to Matic.
        /// </summary>
        /// <param name="valueInWei">Wei.</param>
        /// <returns>Returns total Matic.</returns>
        public static decimal ToMatic(this decimal valueInWei)
        {
            return new BigInteger(valueInWei).ToMatic();
        }

        /// <summary>
        /// Get token UID based on it ContractAddress and Id.
        /// </summary>
        /// <param name="token">Token info.</param>
        /// <returns>Returns token UID.</returns>
        public static string GetTokenUid(this IPolygonscanAccountNftTokenEvent token)
        {
            return token.ContractAddress + "_" + token.TokenId;
        }
    }
}