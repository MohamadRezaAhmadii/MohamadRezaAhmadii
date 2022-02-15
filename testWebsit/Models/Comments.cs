using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testWebsit.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Tittel { get; set; }
        public string Text{ get; set; }
        public int Rating { get; set; }
        public string ReplayText { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Read,
        NoRead
    }
}
