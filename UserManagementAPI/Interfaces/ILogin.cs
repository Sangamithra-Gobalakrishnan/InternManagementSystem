namespace UserManagementAPI.Interfaces
{
    public interface ILogin<T>
    {
        public Task<T?> AddIn(T item);
        public Task<T?> AddOut(T item);
    }
}
