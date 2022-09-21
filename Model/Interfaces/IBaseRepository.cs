namespace SpaceProgram.Model.Interfaces
{
    public interface IBaseRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void Save(T entity);
        void Delete(int id);
    }
}
