using System;
using System.Collections.Generic;
using System.Text;

namespace PersonaFit.AI.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Persona(int id, string? name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
