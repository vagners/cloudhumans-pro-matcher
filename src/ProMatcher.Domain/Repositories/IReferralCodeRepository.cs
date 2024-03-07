using ProMatcher.Domain.ValueObejcts;

namespace ProMatcher.Domain.Repositories
{
    public interface IReferralCodeRepository
    {
        Task<ReferralCode> GetReferralCode(string referralCode);
    }
}
