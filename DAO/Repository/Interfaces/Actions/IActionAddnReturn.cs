namespace DAO.Repository.Interfaces.Actions
{
    public interface IActionAddnReturn<T>
    {
        public Task<T?> AddnReturn(T entity);

    }
}