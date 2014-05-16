using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Entity;
using System.Diagnostics;

namespace BizLogic
{
    public class SupplierBLL
    {
        Team4_ADEntities edm = new Team4_ADEntities();

        public List<Supplier> GetAllSupplier()
        {
            return this.edm.Suppliers.ToList();
        }

        public List<string> GetSupplierNames()
        {
            var query = (from r in edm.Suppliers select r.Supplier_Name);
            return query.ToList<string>();
        }


        public Supplier GetSupplierByCode(string scode)
        {
            Supplier s = edm.Suppliers.First<Supplier>(x => x.Supplier_Code == scode);
            return s;
        }

        public Supplier GetSupplierByName(string name)
        {
            Supplier s = edm.Suppliers.First<Supplier>(x => x.Supplier_Name == name);
            return s;
        }

        public string UpdateSupplierInfo(Supplier updateSupInfo)
        {
            Supplier updateInfo = edm.Suppliers.FirstOrDefault(c => c.Supplier_Code == updateSupInfo.Supplier_Code);
            if (updateInfo != null)
            {
                updateInfo.Supplier_Code = updateSupInfo.Supplier_Code;
                updateInfo.Supplier_Name = updateSupInfo.Supplier_Name;
                updateInfo.Phone = updateSupInfo.Phone;
                updateInfo.Fax = updateSupInfo.Fax;
                updateInfo.Contact_Name = updateSupInfo.Contact_Name;
                updateInfo.Address = updateSupInfo.Address;

            }
            this.edm.SaveChanges();
            string s = "Update is successful";
            return s;
        }

        public string DeleteSupplier(string scode)
        {
            var sup = edm.Suppliers.First<Supplier>(m => m.Supplier_Code == scode);
            edm.DeleteObject(sup);
            edm.SaveChanges();
            string msg = "1 row is deleted";
            return msg;
        }

        public string Createsupplier(string gstregno, string suppliercode, string suppliername, string contactname, string phone, string fax, string Address, string email)
        {
            Supplier createsupp = new Supplier();
            createsupp.GST_RegNo = gstregno;
            createsupp.Supplier_Code = suppliercode;
            createsupp.Supplier_Name = suppliername;
            createsupp.Contact_Name = contactname;
            createsupp.Phone = phone;
            createsupp.Fax = fax;
            createsupp.Address = Address;
            createsupp.Email = email;
            edm.Suppliers.AddObject(createsupp);
            edm.SaveChanges();

            return "Insert successfully";

        }

        public string Updatesupplier(string supp_code, string supp_name, string contact_name, string ph, string fax, string address, string gst_no, string email)
        {

            Supplier supper_info = edm.Suppliers.FirstOrDefault(m => m.Supplier_Code == supp_code);
            if (supper_info != null)
            {

                //supper_info.Supplier_Code = supp_code;
                supper_info.Supplier_Name = supp_name;
                supper_info.Contact_Name = contact_name;
                supper_info.Phone = ph;
                supper_info.Fax = fax;
                supper_info.Address = address;
                supper_info.GST_RegNo = gst_no;
                supper_info.Email = email;
            }

            this.edm.SaveChanges();
            // string code = supper_info.Supplier_Code;
            string s = "Update Successful";
            return s;
        }

    }
}
