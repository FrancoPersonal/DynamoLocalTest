using System.Threading.Tasks;
using Tams.dto;
using Tams.Model.Enums;

namespace Tams.Core
{
    public interface IAccountVerificationRecordRepository
    {
        AccountVerificationRecord GetUniqueId(AccountVerificationRecord request);
        AccountVerificationRecord GetUniqueId(string legacyContractId, BussinesPartyType bussinesPartyType, string accountNumber);
        object HashKey(AccountVerificationRecord request);
        Task<AccountVerificationRecord> LoadAsync(AccountVerificationRecord request);
        Task SaveAsync(AccountVerificationRecord request);
    }
}