using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDetails.Models
{
    public class TblContactDetailsTO
    {
        public Int32 IdContactDetails { get;  set; }
        public String FirstName { get;  set; }
        public String LastName { get;  set; }
        public String PhoneNo { get;  set; }
        public String Email { get;  set; }
        public Int32 IsActive { get;  set; }
        public Int32 CreatedBy { get;  set; }
        public String CreatedByName { get;  set; }
        public DateTime CreatedOn { get;  set; }
        public Int32 UpdatedBy { get;  set; }
        public DateTime UpdatedOn { get;  set; }
        public String UpdatedByName { get;  set; }

    }
}
