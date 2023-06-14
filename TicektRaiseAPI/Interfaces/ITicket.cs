namespace TicektRaiseAPI.Interfaces
{
    public interface ITicket<T,K>
    {
        public Task<T?> Raise(T item);
        public Task<T?> Cancel(K key);
        public Task<T?> Get(K key);
        
        //public Task<T?> Update(T item);
        public Task<ICollection<T>?> GetAll();
    }
}
