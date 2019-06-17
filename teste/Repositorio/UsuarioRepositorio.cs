using System;
using System.Collections.Generic;
using System.IO;
using teste.Models;

namespace teste.Repositorio
{
    public class UsuarioRepositorio
{
        public Usuario Cadastrar (Usuario usuario) {

            if (File.Exists ("Database/usuarios.csv")) {
                usuario.Id = File.ReadAllLines ("Database/usuarios.csv").Length + 1;
            } else {
                usuario.Id = 1;
            }

            StreamWriter sw = new StreamWriter ("Database/usuarios.csv", true);
            sw.WriteLine ($"{usuario.Id};{usuario.Nome};{usuario.Sobrenome};{usuario.Email};{usuario.Senha};{usuario.DataNascimento};{usuario.Admin}");
            sw.Close ();
            return usuario;
        }

        


        public Usuario ProcurarUsuario (string email, string senha) {
            string[] linhas = File.ReadAllLines ("Database/usuarios.csv");
            foreach (var item in linhas) {
                string[] linha = item.Split (";");
                if (email.Equals (linha[3]) && senha.Equals(linha[4])) {
                    Usuario usuario = new Usuario();
                    usuario.Id = int.Parse(linha[0]);
                    usuario.Nome = linha[1];
                    usuario.Sobrenome = linha[2];
                    usuario.Email = linha[3];
                    usuario.Senha = linha[4];
                    usuario.DataNascimento = DateTime.Parse(linha[5]);
                    usuario.Admin = linha[6];
                    return usuario;
                }
            }
            return null;
        }

        public int ContarUsuarios (){
            int i = 0;
            string[] linhas = File.ReadAllLines ("Database/usuarios.csv");
            foreach (var item in linhas) {
                i++;
            }
            return i;
        }


        public List<Usuario> ListarUsuarios () {
            List<Usuario> listaDeUsuarios = new List<Usuario> ();

            string[] linhas = File.ReadAllLines ("Database/usuarios.csv");
            Usuario usuario;
            foreach (var item in linhas) {
                if (string.IsNullOrEmpty (item)) {
                    continue;
                }
                string[] linha = item.Split (";");
                usuario = new Usuario ();
                usuario.Id = int.Parse(linha[0]);
                usuario.Nome = linha[1];
                usuario.Sobrenome= linha[2];
                usuario.Email= linha[3];
                usuario.Senha= linha[4];
                usuario.DataNascimento = DateTime.Parse(linha[5]);
                usuario.Admin= linha[6];

                listaDeUsuarios.Add (usuario);
            }
            return listaDeUsuarios;
        }
    }
}