using SpaceProgram.Model;

namespace SpaceProgram.Service.Intarface
{
    public interface ISpaceService<T>
    {
        IApiResponse<IEnumerable<T>> GetAll();
        IApiResponse<T> GetById(int id);
        IApiResponse<T> PostSave(T obj);
        IApiResponse<T> PutUpdate(T obj);
        IApiResponse<T> Delete(int id);
    }
}
