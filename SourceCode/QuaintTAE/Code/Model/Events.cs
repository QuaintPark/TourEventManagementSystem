using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.Model
{
    public class Events
    {
        public int EventId { get; set; }
        public string EventCode { get; set; }
        public string Slag { get; set; }
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
        public int LocationId { get; set; }
    }
}