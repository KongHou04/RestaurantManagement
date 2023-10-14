namespace DAO.Repository.Interfaces.Actions
{
    public interface IFK2EntityGetter <T, Y, X>
    {
        public Task<T?> GetEntityBy2FK(Y FKEntity1, X FKEntity2);

    }
}

