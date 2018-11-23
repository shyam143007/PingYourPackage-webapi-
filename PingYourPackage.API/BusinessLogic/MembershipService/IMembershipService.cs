namespace PingYourPackage.API.BusinessLogic.MembershipService
{
    public interface IMembershipService
    {
        OperationResult<UserWithRoles> CreateUser(string username, string password, string email);
    }
}
