using System;
using System.Collections.Generic;
using System.Text;

namespace ClintManagement.BLL
{
    class ShowEmailSmsBLL
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
    }
}
