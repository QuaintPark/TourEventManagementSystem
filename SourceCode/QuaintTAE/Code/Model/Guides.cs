using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.Model
{
    public class Guides
    {
        public int GuideId { get; set; }
        public string GuideCode { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
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