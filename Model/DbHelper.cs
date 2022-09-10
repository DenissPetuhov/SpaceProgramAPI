using SpaceProgram.EFCore;

namespace SpaceProgram.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }
        public List<SpaceObjectModel> GetAllSpaceObjects()
        {
            List<SpaceObjectModel> spaceObjects = new List<SpaceObjectModel>();
            var dataList = _context.SpaceObjects.ToList();
            dataList.ForEach(row => spaceObjects.Add(new SpaceObjectModel()
            {
                spaceSystem_id = row.SpaceSystemid,
                age = row.age,
                diameter = row.diameter,
                mass = row.mass,
                name = row.name,
                type = row.type,
                id = row.id,

            }));
            return spaceObjects;
        }
        public SpaceObjectModel GetSpaceObjectById(int id)
        {

            var data = _context.SpaceObjects.Where(i => i.id.Equals(id)).FirstOrDefault();
            return new SpaceObjectModel()
            {
                spaceSystem_id = data.SpaceSystemid,
                age = data.age,
                diameter = data.diameter,
                mass = data.mass,
                name = data.name,
                type = data.type,
                id = data.id,

            };

        }
        public List<SpaceObjectModel> GetSpaceObjectsBySpaceSystemId(int id)
        {
            List<SpaceObjectModel> spaceObjects = new List<SpaceObjectModel>();
            var dataList = _context.SpaceObjects.Where(i => i.SpaceSystemid.Equals(id)).ToList();
            dataList.ForEach(row => spaceObjects.Add(new SpaceObjectModel()
            {
                spaceSystem_id = row.SpaceSystemid,
                age = row.age,
                diameter = row.diameter,
                mass = row.mass,
                name = row.name,
                type = row.type,
                id = row.id,

            }));
            return spaceObjects;
        }
        public List<SpaceSystemModel> GetAllSpaceSystems()
        {
            List<SpaceSystemModel> spaceSystems = new List<SpaceSystemModel>();
            var dataList = _context.SpaceSystems.ToList();
            dataList.ForEach(row => spaceSystems.Add(new SpaceSystemModel()
            {
                age = row.age,
                name = row.name,
                id = row.id,

            }));
            return spaceSystems;
        }
        public SpaceSystemModel GetSpaceSystemById(int id)
        {

            var data = _context.SpaceSystems.Where(d => d.id.Equals(id)).FirstOrDefault();
            return new SpaceSystemModel()
            {
                age = data.age,
                name = data.name,
                id = data.id,

            };

        }
        public void SaveSpaceObject(SpaceObjectModel objectModel)
        {
            SpaceObject spaceObject = new SpaceObject();
            if (objectModel.id > 0)// если ид больше нуля знаичит такая запись уже есть
            {
                spaceObject = _context.SpaceObjects.Where(r => r.id.Equals(objectModel.id)).FirstOrDefault();//ищем космический обект который хотим поменять исходя из айди который пришел
                if (spaceObject != null)
                {
                    spaceObject.name = objectModel.name;
                    spaceObject.type = objectModel.type;
                    spaceObject.age = objectModel.age;
                    spaceObject.diameter = objectModel.diameter;
                    spaceObject.mass = objectModel.mass;
                }
                else
                {   // если же обекта нету создаем новый обьект
                    spaceObject.name = objectModel.name;
                    spaceObject.type = objectModel.type;
                    spaceObject.age = objectModel.age;
                    spaceObject.diameter = objectModel.diameter;
                    spaceObject.mass = objectModel.mass;
                    spaceObject.SpaceSystemid = objectModel.spaceSystem_id;
                    _context.SpaceObjects.Add(spaceObject);
                }
            }
            _context.SaveChanges();
        }
        public void SaveSpaceSystem(SpaceSystemModel systemModel)
        {
            SpaceSystem spaceSystem = new SpaceSystem();
            if (systemModel.id > 0)// если ид больше нуля знаичит обновляем запись в бд
            {
                spaceSystem = _context.SpaceSystems.Where(r => r.id.Equals(systemModel.id)).FirstOrDefault();//ищем космический обект который хотим поменять исходя из айди который пришел
                if (spaceSystem != null)
                {
                    spaceSystem.name = systemModel.name;
                    spaceSystem.age = systemModel.age;

                }
            }
            else
            {
                spaceSystem.name = systemModel.name;
                spaceSystem.age = systemModel.age;
                _context.SpaceSystems.Add(spaceSystem);
            }
            _context.SaveChanges();
        }
        public void DeleteSpaceSystem(int id)
        {
            var spaceSystem = _context.SpaceSystems.Where(s => s.id.Equals(id)).FirstOrDefault();

            if (spaceSystem != null)
            {

                _context.SpaceSystems.Remove(spaceSystem);
                _context.SaveChanges();
            }
        }
        public void DeleteSpaceObject(int id)
        {
            var spaceObject = _context.SpaceObjects.Where(s => s.id.Equals(id)).FirstOrDefault();
            if (spaceObject != null)
            {
                _context.SpaceObjects.Remove(spaceObject);
                _context.SaveChanges();
            }
        }
    }
}
