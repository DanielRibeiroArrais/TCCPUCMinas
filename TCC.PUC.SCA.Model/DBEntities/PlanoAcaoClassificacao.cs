using System;

namespace TCC.PUC.SCA.Model.DBEntities
{
    public class PlanoAcaoClassificacao
    {
        public int Id { get; set; }
        public int Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public PlanoAcaoClassificacao()
        {

        }
    }
}
