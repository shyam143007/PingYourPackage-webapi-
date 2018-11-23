namespace PingYourPackage.API.BusinessLogic.MembershipService
{
    public class OperationResult
    {
        public bool IsSuccess { get; private set; }

        public OperationResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }

    public class OperationResult<TEntity> : OperationResult
    {
        public OperationResult(bool isSuccess) : base(isSuccess)
        {
        }

        public TEntity Entity { get; set; }
    }

    public class UserWithRoles
    {

    }
}
