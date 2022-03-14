using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.Model
{
    public class HotelReservations
    {
        public int HotelId { get; set; }
        public string HotelCode { get; set; }
        public string Slag { get; set; }
        public string HotelName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string RoomType { get; set; }
        public string BookedBy { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
        public int GuideId { get; set; }
    }
}