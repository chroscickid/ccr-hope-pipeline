using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HopePipeline.Models
{
    public class Referral
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int pK { get; set; }
        //done
        public string fName { get; set; }
        //done
        public string lName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dOB { get; set; }
        //done
        public string guardianName { get; set; }
        //done
        public string guardianRelationship { get; set; }
        //done
        public string address { get; set; }
        //done

        public string guardianEmail { get; set; }
        //done

        public string guardianPhone { get; set; }

        public string meeting { get; set; }

        public int bakerxhistory { get; set; }


        public string youthInSchool { get; set; }
        public string issues { get; set; }
        //done
        public string currentSchool { get; set; }
        //done
        public string otherInfo { get; set; }

        public string communication { get; set; }

        public string zip { get; set; }

        //auto input
        public string status { get; set; }

        //done
        public Nullable<System.DateTime> dateInput { get; set; }
        [DataType(DataType.Date)]
        public DateTime? date { get; set; }

        public string email { get; set; }

        public string time { get; set; }

       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      
    }
}
    


