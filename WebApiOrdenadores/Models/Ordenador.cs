﻿using System.ComponentModel.DataAnnotations;

namespace WebApiOrdenadores.Models;

public class Ordenador
{
    public int? Id { get; set; }
    [Required]
    public virtual List<Componente>? Componentes { get; set; }
    [MaxLength(100)]
    public string? Description { get; set; }
}