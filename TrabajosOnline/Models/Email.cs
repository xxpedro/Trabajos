using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajosOnline.Models
{
    public class Email
    {
        public String Envia { get; set; }
        public String Recibe { get; set; }
        public String Asunto { get; set; }
        public String mensaje { get; set; }
        public HttpPostedFileBase Curriculum { get; set; }
    }
}