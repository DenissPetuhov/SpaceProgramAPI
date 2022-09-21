using AutoMapper;
using SpaceProgram.EFCore;
using SpaceProgram.Model.Interfaces;

namespace SpaceProgram.Model.Repositories
{
    public class SpaceSystemRepository : IBaseRepository<SpaceSystemModel>
    {
        private EF_DataContext _context;
        private readonly IMapper _mapper;
        public SpaceSystemRepository(EF_DataContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }
        public void Delete(int id)
        {
            var spaceSystem = _context.SpaceSystems.Where(s => s.id.Equals(id)).FirstOrDefault();

            if (spaceSystem != null)
            {

                _context.SpaceSystems.Remove(spaceSystem);
                _context.SaveChanges();
            }
        }

        public List<SpaceSystemModel> GetAll()
        {
            List<SpaceSystemModel> spaceSystems = new List<SpaceSystemModel>();
            var dataList = _context.SpaceSystems.ToList();
            dataList.ForEach(row => spaceSystems.Add(_mapper.Map<SpaceSystemModel>(row)));
            //    new SpaceSystemModel() упрощенно мапингом
            //{
            //    age = row.age,
            //    name = row.name,
            //    id = row.id,

            //})

            return spaceSystems;
        }

        public SpaceSystemModel GetById(int id)
        {
            var data = _context.SpaceSystems.Where(d => d.id.Equals(id)).FirstOrDefault();
            var system = _mapper.Map<SpaceSystemModel>(data);
            return system;
          
        }

        public void Save(SpaceSystemModel entity)
        {

            if (entity.id > 0)
            {
                var data = _context.SpaceSystems.Where(r => r.id.Equals(entity.id)).FirstOrDefault();
                if (data != null)
                {
                    //  data = _mapper.Map<SpaceSystem>(entity);
                    data.name = entity.name;
                    data.age = entity.age;
                    _context.SpaceSystems.Update(data);
                }

            }
            else
            {
                var spaceSystem = _mapper.Map<SpaceSystem>(entity);


                _context.SpaceSystems.Add(spaceSystem);
            }
            _context.SaveChanges();
        }
    }
}
