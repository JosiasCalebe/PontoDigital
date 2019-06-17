using System;

namespace teste.Models
{
    public class Depoimento
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Profissao { get; set; }
        public string Texto { get; set; }
        public DateTime Data {get; set;}
        public string Aprovado {get;set;}
    }
}