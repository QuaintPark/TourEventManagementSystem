using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintTAE.Code.Model
{
    public class Registrations
    {
        public int RegistrationId { get; set; }
        public string RegistrationCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public int EventId { get; set; }

    }
}