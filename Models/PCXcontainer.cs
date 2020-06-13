using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using MerelliPCX;

namespace imgAPI.Models
{
    [Table("pcxcontainer", Schema = "pcxAPI")]
    public class PCXcontainer : container
    {
        public new PCXVersion version { get; set; }
    }
}
