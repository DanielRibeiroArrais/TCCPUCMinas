using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.PUC.SCA.Model.SpecificEntities.Common
{
    public class Mensagem
    {
        public Guid MessageId { get; set; }
        public DateTime InclusionDate { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string SMS { get; set; }
        public string WhatsApp { get; set; }
        public string Msg { get; set; }
    }
}
