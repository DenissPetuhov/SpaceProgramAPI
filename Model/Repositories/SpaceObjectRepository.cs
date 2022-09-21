using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpaceProgram.EFCore;
using SpaceProgram.Model.Interfaces;

namespace SpaceProgram.Model.Repositories
{
    public class SpaceObjectRepository : ISpaceObjetcRepository
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
            var spaceObject  = _context.SpaceObjects.Where(s => s.id.Equals(id)).FirstOrDefault();
            if (spaceObject != null)
            {
                _context.SpaceObjects.Remove(spaceObject);
                _context.SaveChanges();
            }
           
        }

        public  List<SpaceObjectModel> GetAll()
        {
            List<SpaceObjectModel> spaceObjects = new List<SpaceObjectModel>();
            var dataList =  _context.SpaceObjects.ToList();
            dataList.ForEach(row => spaceObjects.Add(_mapper.Map<SpaceObjectModel>(row)));
            //   new SpaceObjectModel()
            //{
            //    spaceSystem_id = row.spaceSystem_id, упрощенно мапингом
            //    age = row.age,
            //    diameter = row.diameter,
            //    mass = row.mass,
            //    name = row.name,
            //    type = row.type,
            //    id = row.id,

            //}));
            return spaceObjects;
        }

        public  SpaceObjectModel GetById(int id)
        {
            var data =   _context.SpaceObjects.Where(i => i.id.Equals(id)).FirstOrDefault();
            var spaceObject =  _mapper.Map<SpaceObjectModel>(data);
            return spaceObject;
         
        }

        public List<SpaceObjectModel> GetBySpaceSystemId(int id)
        {
            List<SpaceObjectModel> spaceObjects = new List<SpaceObjectModel>();
            var dataList = _context.SpaceObjects.Where(i => i.spaceSystem_id.Equals(id)).ToList();
            dataList.ForEach(row => spaceObjects.Add(_mapper.Map<SpaceObjectModel>(row)));


            //    new SpaceObjectModel() упрощенно мапингом
            //{
            //    spaceSystem_id = row.spaceSystem_id,
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
            
            if (entity.id > 0)// если ид больше нуля знаичит такая запись уже есть
            {
                var data = _context.SpaceObjects.Where(r => r.id.Equals(entity.id)).FirstOrDefault();
                if (data != null)
                {
                    //  data = _mapper.Map<SpaceObject>(entity);
                    data.name = entity.name;
                    data.type = entity.type;
                    data.age = entity.age;
                    data.diameter = entity.diameter;
                    data.mass = entity.mass;
                    _context.SpaceObjects.Update(data);
                }

            }
            else
            {
                var spaceObject = _mapper.Map<SpaceObject>(entity);
             

                _context.SpaceObjects.Add(spaceObject);
            }
            _context.SaveChanges();
        }
    }
}
