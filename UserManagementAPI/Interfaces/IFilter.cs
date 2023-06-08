namespace UserManagementAPI.Interfaces
{
    public interface IFilter<T>
    {
        public Task<ICollection<T>?> GetAllUsers();
    }
}
