using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalWebsiteMVC.Models
{
    public class MultipleTableData
    {
        public IEnumerable<Experiencecls> experienceee { get; set; }

        public IEnumerable<Educationcls> educationss { get; set; }

        public IEnumerable<Resumecls> resumeees { get; set; }

        public IEnumerable<Userregcls> userdetailss { get; set; }

        public int record_id { get; set; }
    }
}