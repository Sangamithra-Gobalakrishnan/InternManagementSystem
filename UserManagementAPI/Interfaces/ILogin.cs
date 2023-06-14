namespace UserManagementAPI.Interfaces
{
    public interface ILogin<T,I>
    {
        public Task<T?> AddInTime(T item);
        public Task<T?> AddOutTime(T item);
        public Task<T?> UpdateStatus(I key);
        
    }
}
