namespace SpaceProgram.Model.Interfaces
{
    public interface ISpaceObjectRepository : IBaseRepository<SpaceObjectModel>
    {
        IEnumerable<SpaceObjectModel> GetBySpaceSystemId(int id);
    }
}
