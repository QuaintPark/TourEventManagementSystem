using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.Model
{
    public class Locations
    {
        public int LocationId { get; set; }
        public string LocationCode { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
    }
}