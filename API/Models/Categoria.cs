using System;

namespace  API.Models
{
    public class Categoria
    {
    public Categoria() => CriadoEm = DateTime.Now;

    public int Id { get; set; }

    public String Nome { get; set; }

    public DateTime CriadoEm { get; set; }

    }
}