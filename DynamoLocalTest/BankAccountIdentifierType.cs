using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Tams.Model.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    [DataContract]
    public enum BankAccountIdentifierType
    {
        [EnumMember]
        CLABE = 9,
        [EnumMember]
        DEBIT_CARD = 11,
    }
}
