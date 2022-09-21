using SpaceProgram.Model;

namespace SpaceProgram.Service.Intarface
{
    public interface ISpaceObjectService : ISpaceService<SpaceObjectModel>
    {
        IApiResponse<IEnumerable<SpaceObjectModel>> GetBySpaceSystemId(int id);
       
    }
}
