using System;

namespace teste.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento{get;set;}
        public string Admin {get;set;}

        public Usuario (string nome, string sobrenome, string email, string senha, DateTime dataNascimento){
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.Senha = senha;
            this.DataNascimento = dataNascimento;
            this.Admin = "False";
        }
          public Usuario (int id,string nome, string sobrenome, string email, string senha, DateTime dataNascimento){
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.Senha = senha;
            this.DataNascimento = dataNascimento;
            this.Admin = "False";
        }

        public Usuario(){}
    }
}