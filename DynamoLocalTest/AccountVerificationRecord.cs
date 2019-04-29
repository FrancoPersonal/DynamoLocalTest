using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using System.Runtime.Serialization;
using Tams.Model.Enums;

namespace Tams.dto
{
    [DataContract]
    [DynamoDBTable(ResourcesDto.TamsAccountsVerifications)]
    public class AccountVerificationRecord 
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = ResourcesDto.BankAccountType)]
        [DynamoDBProperty(ResourcesDto.BankAccountType)]
        public BankAccountIdentifierType AccountIdentifierType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = ResourcesDto.LegacyContractId)]
        [DynamoDBProperty(ResourcesDto.LegacyContractId)]
        public string LegacyContractId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = ResourcesDto.IsAuthorizedByDesk)]
        [DynamoDBProperty(ResourcesDto.IsAuthorizedByDesk)]
        public bool IsAuthorizedByDesk { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = ResourcesDto.IsAuthorizedByTreasury)]
        [DynamoDBProperty(ResourcesDto.IsAuthorizedByTreasury)]
        public bool IsAuthorizedByTreasury { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = ResourcesDto.BusinessUnitParty)]
        [DynamoDBProperty(ResourcesDto.BusinessUnitParty)]
        public BussinesPartyType BusinessUnitParty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = ResourcesDto.AccountId)]
        [DynamoDBProperty(ResourcesDto.AccountId)]
        public long SsiId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = ResourcesDto.BankId)]
        [DynamoDBProperty(ResourcesDto.BankId)]
        public int BankId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = ResourcesDto.SubAccountId)]
        [DynamoDBProperty(ResourcesDto.SubAccountId)]
        public long SubAccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = ResourcesDto.LastStatusVerification)]
        [DynamoDBProperty(ResourcesDto.LastStatusVerification)]
        public string LastStatusVerification { get; set; }

        [DataMember(Name = ResourcesDto.ModifiedDate)]
        [DynamoDBProperty(ResourcesDto.ModifiedDate)]
        public string ModifiedDate { get; set; }


        [DynamoDBHashKey(ResourcesDto.Id)]
        [DataMember(Name = ResourcesDto.Id)]
        public string Id
        {
            get; set;
        }

        [DynamoDBRangeKey(ResourcesDto.AccountNumber)]
        [DataMember(Name = ResourcesDto.AccountNumber)]
        public string AccountNumber
        {
            get; set;
        }

        [DataMember(Name = ResourcesDto.FullName)]
        [DynamoDBProperty(ResourcesDto.FullName)]
        public string FullName { get; set; }

        [DataMember(Name = ResourcesDto.Header)]
        [DynamoDBProperty(ResourcesDto.Header)]
        public IDictionary<string, string> Headers { get; set; }

        [DataMember(Name = ResourcesDto.PartyId)]
        [DynamoDBProperty(ResourcesDto.PartyId)]
        public long PartyId { get; set; }
    }
}
