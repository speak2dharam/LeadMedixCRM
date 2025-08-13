namespace LeadMedixCRM.Interfaces
{
    public interface ICurrentUserService
    {
        int GetUserId();
        string GetUserRole();
    }
}
