using AutoMapper;
using SpaceProgram.EFCore;
using SpaceProgram.Model.Interfaces;

namespace SpaceProgram.Model.Repositories
{
    public class SpaceObjectRepository : ISpaceObjectRepository
    {
        private EF_DataContext _context;
        private readonly IMapper _mapper;
        public SpaceObjectRepository(EF_DataContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }
        public void Delete(int id)
        {
            var spaceObject = _context.SpaceObjects.Where(s => s.id.Equals(id)).FirstOrDefault();
            if (spaceObject != null)
            {
                _context.SpaceObjects.Remove(spaceObject);
                _context.SaveChanges();
            }
        }

        public IEnumerable<SpaceObjectModel> GetAll()
        {
            List<SpaceObjectModel> spaceObjects = new List<SpaceObjectModel>();
            var dataList = _context.SpaceObjects.ToList();
            dataList.ForEach(row => spaceObjects.Add(_mapper.Map<SpaceObjectModel>(row)));
            //   new SpaceObjectModel()
            //{
            //    spaceSystem_id = row.SpaceSystemid, упрощенно мапингом
            //    age = row.age,
            //    diameter = row.diameter,
            //    mass = row.mass,
            //    name = row.name,
            //    type = row.type,
            //    id = row.id,

            //}));
            return spaceObjects;
        }

        public SpaceObjectModel GetById(int id)
        {
            var data = _context.SpaceObjects.Where(i => i.id.Equals(id)).FirstOrDefault();
            var spaceObject = _mapper.Map<SpaceObjectModel>(data);
            return spaceObject;
            // new SpaceObjectModel() упрощенно мапингом
            //{
            //    spaceSystem_id = data.SpaceSystemid,
            //    age = data.age,
            //    diameter = data.diameter,
            //    mass = data.mass,
            //    name = data.name,
            //    type = data.type,
            //    id = data.id,

            //};
        }

        public IEnumerable<SpaceObjectModel> GetBySpaceSystemId(int id)
        {
            List<SpaceObjectModel> spaceObjects = new List<SpaceObjectModel>();
            var dataList = _context.SpaceObjects.Where(i => i.SpaceSystemid.Equals(id)).ToList();
            dataList.ForEach(row => spaceObjects.Add(_mapper.Map<SpaceObjectModel>(row)));


            //    new SpaceObjectModel() упрощенно мапингом
            //{
            //    spaceSystem_id = row.SpaceSystemid,
            //    age = row.age,
            //    diameter = row.diameter,
            //    mass = row.mass,
            //    name = row.name,
            //    type = row.type,
            //    id = row.id,

            //}));
            return spaceObjects;
        }

        public void Save(SpaceObjectModel entity)
        {
            SpaceObject spaceObject = new SpaceObject();
            if (entity.id > 0)// если ид больше нуля знаичит такая запись уже есть
            {
                spaceObject = _context.SpaceObjects.Where(r => r.id.Equals(entity.id)).FirstOrDefault();
                if (spaceObject != null)
                {
                    _mapper.Map<SpaceObjectModel>(spaceObject);
                    //spaceObject.name = objectModel.name;
                    //spaceObject.type = objectModel.type;
                    //spaceObject.age = objectModel.age;
                    //spaceObject.diameter = objectModel.diameter;
                    //spaceObject.mass = objectModel.mass;
                }
                else
                {
                    _mapper.Map<SpaceObjectModel>(spaceObject);
                    //spaceObject.name = objectModel.name;
                    //spaceObject.type = objectModel.type;
                    //spaceObject.age = objectModel.age;
                    //spaceObject.diameter = objectModel.diameter;
                    //spaceObject.mass = objectModel.mass;
                    //spaceObject.SpaceSystemid = objectModel.spaceSystem_id;

                    _context.SpaceObjects.Add(spaceObject);
                }
            }
            _context.SaveChanges();
        }
    }
}
