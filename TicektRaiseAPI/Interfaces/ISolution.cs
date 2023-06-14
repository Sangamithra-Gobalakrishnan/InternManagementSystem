namespace TicektRaiseAPI.Interfaces
{
    public interface ISolution<T,K>
    {
        public Task<T?> Provide(T item);
        
        //public Task<T?> Delete(K key);
        //public Task<T?> Get(K key);
        //public Task<T?> Update(T item);
    }
}
