using System;
using System.Collections.Generic;
using System.Text;

namespace ClintManagement.BLL
{
    class ClientBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime addedDate { get; set; }
    }
}
