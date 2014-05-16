using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogicLayer
{
    public class userbll
    {

        Stationery_ADEntities entity ;
        public userbll()
        {
            entity = new Stationery_ADEntities();
        }
    
        public IQueryable viewaccount(int customerID) 
        {

           
            var vaccount = (from r in hotel.RoomReservations where r.CustomerID == customerID && r.Remarks=="Booked" select r);
            return vaccount;
        }
        public int getcustomerid ()
        {

            
            var qurey = (from cusid in hotel.Customers select cusid.CustomerID).Max();
            return qurey;
            
            
        }
        public int cancelbooking(int reservationid)
        {
          
            RoomReservation res = hotel.RoomReservations.FirstOrDefault(m => m.ReservationID == reservationid);
            res.Remarks = "Cancelled";
            return hotel.SaveChanges();
            
        }
        /* Validation Method */

        public bool validateUser(int customerId, string pwd)
        {
            Customer cust = hotel.Customers.FirstOrDefault(x => x.CustomerID == customerId);
            if (cust != null)
            {
                if (cust.Password.Trim().Equals(pwd.Trim()))
                {
                    return true;
                }
            }
            return false;
        }
        public bool validatestaff(string StaffID, string Password)
        {
            Staff stf = hotel.Staffs.FirstOrDefault(y => y.StaffID == StaffID);
            if (stf != null)
                if (stf.Password.Trim().Equals(Password.Trim()))
                {
                    return true;
                }

            return false;

        }
    }

}
