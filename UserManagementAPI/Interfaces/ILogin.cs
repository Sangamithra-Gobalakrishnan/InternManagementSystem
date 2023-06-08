namespace UserManagementAPI.Interfaces
{
    public interface ILogin<T,I,K>
    {
        public Task<T?> AddIn(T item);
        public Task<T?> AddOut(T item);
        public Task<K?> Update(I key1,K key2);
        
    }
}
