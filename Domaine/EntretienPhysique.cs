using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class EntretienPhysique
    {
        public int EntretienPhysiqueId { get; set; }
        /*[ForeignKey("Calendrier")]
        private int? CalendrierId { get; set; }*/
        [DataType(DataType.DateTime)]
        public DateTime DateEntretien { get; set; }
    }
}
