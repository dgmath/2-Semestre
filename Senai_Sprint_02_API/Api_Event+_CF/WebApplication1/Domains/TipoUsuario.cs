﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_tarde.Domains
{
    [Table(nameof(TipoUsuario))]
    public class TipoUsuario
    {
        [Key] 
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Titulo do Tipo Usuario é obrigatório!")]
        public string? Titulo { get; set; }
    }
}
