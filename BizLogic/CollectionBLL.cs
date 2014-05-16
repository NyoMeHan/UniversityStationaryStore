using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{
    public class CollectionBLL
    {
        Team4_ADEntities edm = new Team4_ADEntities();
        public List<CollectionPoint> GetAllCollectionPoint()
        {
            return this.edm.CollectionPoints.ToList();
        }

        public List<string> GetCollectionNames()
        {
            var names = (from r in edm.CollectionPoints select r.Place);
            return names.ToList<string>();
        }

        public string GetCollectionNameById(int id)
        {
            var query = (from r in edm.CollectionPoints where r.CollectionID == id select r);
            CollectionPoint cp = new CollectionPoint();
            cp = query.First<CollectionPoint>();
            string name = cp.Place;

            return name;
        }

        public int GetCollectionIdByName(string name)
        {
            var query = (from r in edm.CollectionPoints where r.Place.Equals(name) select r);
            CollectionPoint cp = new CollectionPoint();
            cp = query.First<CollectionPoint>();
            int id = cp.CollectionID;

            return id;
        }
    }
}
