using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.PUC.SCA.Model.DBEntities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Display(Name = "Permissão")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int RoleId { get; set; }

        public string Role { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(80)]
        public string NomeCompleto { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(80)]
        public string Email { get; set; }

        [Display(Name = "Nome Usuário")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(30)]
        public string NomeUsuario { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(30)]
        public string Senha { get; set; }

        [Display(Name = "Ativo")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public bool Ativo { get; set; }

        [Display(Name = "Data Inclusão")]
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data Alteração")]
        public DateTime? DataAlteracao { get; set; }

        public Usuario()
        {

        }
    }
}
