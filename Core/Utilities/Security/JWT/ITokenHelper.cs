using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Core.Entities.Concrete.User user, List<OperationClaim> operationClaims);
    }
}
