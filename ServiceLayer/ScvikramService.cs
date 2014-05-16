using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BizLogic;

namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "scvikramService" in both code and config file together.
    public class scvikramService : IscvikramService
    {
        ServiceOriented so = new ServiceOriented();
        CollectionDataSource cds = new CollectionDataSource();
        public List<CollectionDataSource> getCurrentPoint()
        {
            return so.getCollectionpoint();
        }


        public List<RepresentativeInformationDataStore> getData(int i)
        {
         // return so.getDepartmentReq(i);
            return null;
        }
    }
}
