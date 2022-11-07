using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Nomis.Polygonscan.Interfaces.Models
{
    /// <summary>
    /// Polygonscan account ERC-1155 token transfer events.
    /// </summary>
    public class PolygonscanAccountERC1155TokenEvents :
        IPolygonscanTransferList<PolygonscanAccountERC1155TokenEvent>
    {
        /// <summary>
        /// Status.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// Account ERC-1155 token event list.
        /// </summary>
        [JsonPropertyName("result")]
        [DataMember(EmitDefaultValue = true)]
        public List<PolygonscanAccountERC1155TokenEvent> Data { get; set; } = new();
    }
}
