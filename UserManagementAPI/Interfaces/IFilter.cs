namespace UserManagementAPI.Interfaces
{
    public interface IFilter<T,K>
    {
        public Task<ICollection<T>?> GetAllUsers();

        public Task<ICollection<K>?> GetAllLog();
    }
}
