namespace DAO.Repository.Interfaces.Actions
{
    public interface IFKEntityGetter <T, Y>
    {
        public Task<List<T>> GetEntitysByFK(Y FKentity);
    }
}