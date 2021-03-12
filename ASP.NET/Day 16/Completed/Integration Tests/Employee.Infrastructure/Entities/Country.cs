using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Employee.Infrastructure.Entities
{
    [Table(name:"Country", Schema ="sales")]
    public class Country 
    {
        


        public int Id { get; set; }

       
        public string Code { get; set; }
        public string Name { get; set; }

        public string IsoCode { get; set; }
    }
}
