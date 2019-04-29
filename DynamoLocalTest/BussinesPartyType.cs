using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Tams.Model.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    [DataContract]
    public enum BussinesPartyType
    {
        [EnumMember]
        CASA_DE_BOLSA = 7757,
        [EnumMember]
        OPERADORA = 7759
    }
}
