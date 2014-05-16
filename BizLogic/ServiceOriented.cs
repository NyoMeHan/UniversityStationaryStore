using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;




namespace BizLogic
{
    public class ServiceOriented
    {
        Team4_ADEntities team = new Team4_ADEntities();
        
        public List<CollectionDataSource> getCollectionpoint()
        {

            List<CollectionDataSource> list = new List<CollectionDataSource>();
            var x = (from m in team.vw_collectionpoint
                    select m).ToList<vw_collectionpoint>();

            foreach (var m in x)
            {
                CollectionDataSource cdp = new CollectionDataSource();

                cdp.DepartmentName = m.Department_Name.TrimEnd();
                cdp.CollectionPlace = m.Place;
               
                list.Add(cdp);
                
            }

            return list;
        }


        //public List<RepresentativeInformationDataStore> getDepartmentReq(int emp)
        //{
        //    List<RepresentativeInformationDataStore> dep = new List<RepresentativeInformationDataStore>();
        //    var y = (from m in team.Employees
        //             where m.EmployeeID == emp
        //             select m).First<Employee>();

        //    var x = (from m in team.vw_deptformobile 
        //           where m.Department_Code  == y.DepartmentCode
        //           select m).ToList<vw_deptformobile>();

        //    foreach (var d in x)
        //    {
        //        RepresentativeInformationDataStore rid = new RepresentativeInformationDataStore();
        //        rid.ItemDescription = HttpUtility.HtmlDecode(d.Item);
        //        rid.Quantity = Convert.ToInt32(d.Requested_Quantity).ToString();
        //        rid.CollectionPoint = d.Place;

        //        dep.Add(rid);
                
        //    }

        //    return dep;
            
        //}
    }
}
