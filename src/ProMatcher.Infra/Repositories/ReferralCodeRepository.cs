using ProMatcher.Domain.Repositories;
using ProMatcher.Domain.ValueObjects;

namespace ProMatcher.Infra.Repositories
{
    public class ReferralCodeRepository : IReferralCodeRepository
    {
        private ReferralCode[] _repositoryOfReferralCodes => new ReferralCode[]
        {
            new ReferralCode("token1234", valid: true)
        };

        public async Task<ReferralCode> GetReferralCode(string value)
        {
            var referralCode = _repositoryOfReferralCodes.FirstOrDefault (x => x.Value == value);
            if (referralCode == null)
                return new ReferralCode(value, false);

            return referralCode;
        }
    }
}