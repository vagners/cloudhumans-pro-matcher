using ProMatcher.Domain.ValueObjects;

namespace ProMatcher.Domain.Repositories
{
    public interface IReferralCodeRepository
    {
        Task<ReferralCode> GetReferralCode(string referralCode);
    }
}
