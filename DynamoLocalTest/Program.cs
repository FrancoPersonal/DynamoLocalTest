using Newtonsoft.Json;
using System;
using Tams.Core;

namespace DynamoLocalTest
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            AccountVerificationRecordRepository repository = new AccountVerificationRecordRepository();

            Tams.dto.AccountVerificationRecord record = new Tams.dto.AccountVerificationRecord()
            {
                AccountIdentifierType = Tams.Model.Enums.BankAccountIdentifierType.CLABE,
                AccountNumber = "245554545",
                LegacyContractId = "4568786",
                BusinessUnitParty = Tams.Model.Enums.BussinesPartyType.CASA_DE_BOLSA
            };

            await repository.SaveAsync(repository.AddUniqueId(record));


            var result = await repository.LoadAsync(repository.AddUniqueId(record));
            Console.WriteLine(JsonConvert.SerializeObject(result));


            //Helper help = new Helper();
            //await help.CreateExampleTableAsync("tams_accounts_verifications");





        }
    }
}
