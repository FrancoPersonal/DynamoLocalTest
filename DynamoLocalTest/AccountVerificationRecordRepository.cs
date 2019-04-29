namespace Tams.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Amazon.Lambda.DynamoDBEvents;
    using Tams.core;
    using Tams.dto;
    using Tams.Model.Enums;
    //using Tams.Model.Enums;
    using static Amazon.Lambda.DynamoDBEvents.DynamoDBEvent;

    public class AccountVerificationRecordRepository : DynamoRepository, IAccountVerificationRecordRepository
    {
        public async Task SaveAsync(AccountVerificationRecord request)
        {
            await this.context.SaveAsync(request).ConfigureAwait(false);
         //   await _amazonDynamoDb.PutItemAsync(request);
        }


        public async Task<AccountVerificationRecord> LoadAsync(AccountVerificationRecord request)
        {
            return await this.context.LoadAsync<AccountVerificationRecord>(GetUniqueId(request));
        }

        public  async Task DeleteAsync(AccountVerificationRecord request)
        {
            await this.context.DeleteAsync<AccountVerificationRecord>(GetUniqueId(request));
        }

        public async Task DeleteTableAsync(string tableName)
        {           
            await this.client.DeleteTableAsync(tableName);
        }



        public object HashKey(AccountVerificationRecord request)
        {
            return $@"{request.LegacyContractId}|{request.BusinessUnitParty}";
        }

        public AccountVerificationRecord GetUniqueId(string legacyContractId, BussinesPartyType bussinesPartyType, string accountNumber)
        {
            return new AccountVerificationRecord()
            {
                Id = $@"{legacyContractId}|{bussinesPartyType}",
                AccountNumber = accountNumber
            };
        }

        public AccountVerificationRecord AddUniqueId(AccountVerificationRecord request)
        {
            var newAccount = request;
            var id= GetUniqueId(request.LegacyContractId, request.BusinessUnitParty, request.AccountNumber);
            newAccount.Id = id.Id;
            newAccount.AccountNumber = id.AccountNumber;
            return newAccount;
        }


        public AccountVerificationRecord GetUniqueId(AccountVerificationRecord request)
        {
            return GetUniqueId(request.LegacyContractId, request.BusinessUnitParty, request.AccountNumber);
        }


        //public  AccountVerificationRecord ToReactiveForQuery( DynamodbStreamRecord record)
        //{
        //    return new AccountVerificationRecord
        //    {
        //        Id = GetStrValue(record, ResourcesDto.Id),
        //        AccountNumber = GetStrValue(record, ResourcesDto.AccountNumber)
        //    };
        //}


        //public async Task<AccountVerificationRecord> LoadRegisteredAsync(DynamoDBEvent dynamoEvent)
        //{
        //    foreach (DynamoDBEvent.DynamodbStreamRecord record in dynamoEvent.Records)
        //    {
        //        Dictionary<string, string> headers = new Dictionary<string, string>();
        //        var recordDynamo = await this.context.LoadAsync(ToReactiveForQuery(record)).ConfigureAwait(false);
        //        if (recordDynamo.LastStatusVerification == StatusVerification.REGISTERED.ToString() && (record.EventName.Equals("INSERT") || record.EventName.Equals("MODIFY")))
        //        {
        //            return recordDynamo;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //    return null;
        //}
    }
}
