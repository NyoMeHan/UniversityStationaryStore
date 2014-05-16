using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{
    public class DepartmentRepBLL
    {
        Team4_ADEntities edm = new Team4_ADEntities();
        public List<DepartmentRep> GetAllReps()
        {
            return this.edm.DepartmentReps.ToList();
        }

        public DepartmentRep GetRepsByDeptCode(string code)
        {
            var q = (from r in edm.DepartmentReps where r.Department_Code.Equals(code) select r);
            DepartmentRep rep = new DepartmentRep();
            rep = q.First<DepartmentRep>();
            return rep;
        }

        public DepartmentRep GetRepByRepId(int id)
        {
            var q = (from r in edm.DepartmentReps where r.RepID == id select r);
            DepartmentRep rep = new DepartmentRep();
            rep = q.First<DepartmentRep>();
            return rep;

        }

        public void AddDeptRep(int id, string code)
        {
            DepartmentRep rep = new DepartmentRep();

            rep.EmployeeID = id;
            rep.Department_Code = code;
            edm.DepartmentReps.AddObject(rep);
            this.edm.SaveChanges();

        }

        public void UpdateDeptRep(int id, string code)
        {
            DepartmentRep rep = GetRepsByDeptCode(code);

            rep.EmployeeID = id;
            this.edm.SaveChanges();
        }
    }
}
