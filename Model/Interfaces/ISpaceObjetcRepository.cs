namespace SpaceProgram.Model.Interfaces
{
    public interface ISpaceObjetcRepository : IBaseRepository<SpaceObjectModel>
    {
        List<SpaceObjectModel> GetBySpaceSystemId(int id);
    }
}
