﻿namespace UserManagementAPI.Interfaces
{
    public interface IIntern<T,K>
    {
        public Task<T?> Add(T item);
        public Task<T?> Delete(K key);
        public Task<T?> Get(K key);
        public Task<T?> Update(T item);
        public Task<ICollection<T>?> GetAll();
    }
}
