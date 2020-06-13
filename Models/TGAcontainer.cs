using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Paloma;

namespace imgAPI.Models
{
    [Table("tgacontainer", Schema = "tgaAPI")]
    public class TGAcontainer : container
    {
        public new TGAFormat version { get; set; }
    }
}
