using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE.Core.Domain
{
    public class Expertise
    {
        [DataType(DataType.Date,ErrorMessage ="message")]
        public DateTime DateExpertise { get; set; }
        [DataType(DataType.MultilineText)]
        //[Range(3,100)] range nesta3mlouha kif tkoun int
        [MaxLength(100)]
        [MinLength(3)]
        public string AvisTechnique { get; set; }
        public double MontantEstime { get; set; }
        public double Duree { get; set; }
        public virtual Sinistre MySinistre { get; set; }
        public virtual Expert MyExpert { get; set; }
        public int ExpertFK { get; set; }
        public int SinistreFK { get; set; }
        
    }
}
