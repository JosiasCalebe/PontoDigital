using System;
using System.Collections.Generic;
using System.IO;
using teste.Models;

namespace teste.Repositorio
{
    public class DepoimentoRepositorio
    {
        public Depoimento Cadastrar (Depoimento depoimento) {
            if (File.Exists ("Database/depoimentos.csv")) {
                depoimento.Id = File.ReadAllLines ("Database/depoimentos.csv").Length + 1;
            } else {
                depoimento.Id = 1;
            }
            depoimento.Data = DateTime.Now;
            StreamWriter sw = new StreamWriter ("Database/depoimentos.csv", true);
            sw.WriteLine ($"{depoimento.Id};{depoimento.Nome};{depoimento.Profissao};{depoimento.Texto};{depoimento.Data};{depoimento.Aprovado}");
            sw.Close ();
            return depoimento;
        }

        public List<Depoimento> ListarDepoimentos () {
            List<Depoimento> listaDeDepoimentos = new List<Depoimento> ();

            string[] linhas = File.ReadAllLines ("Database/depoimentos.csv");
            Depoimento depoimento;
            foreach (var item in linhas) {
                if (string.IsNullOrEmpty (item)) {
                    continue;
                }
                string[] linha = item.Split (";");
                depoimento = new Depoimento ();
                depoimento.Id = int.Parse(linha[0]);
                depoimento.Nome = linha[1];
                depoimento.Profissao= linha[2];
                depoimento.Texto= linha[3];
                depoimento.Data = DateTime.Parse(linha[4]);
                depoimento.Aprovado= linha[5];

                listaDeDepoimentos.Add (depoimento);
            }
            return listaDeDepoimentos;
        }

        public void TrocarLinha (string texto, string arquivo, int linha) {
            string[] arrayLinhas = File.ReadAllLines (arquivo);
            arrayLinhas[linha - 1] = texto;
            File.WriteAllLines (arquivo, arrayLinhas);
        }

        public int ContarDepoimentos(string a){
            string[] linhas = File.ReadAllLines ("Database/depoimentos.csv");
            int i = 0;
            foreach (var item in linhas) {
                string[] linha = item.Split (";");
                if(a=="True"){
                    if(linha[5] == a){
                    i++;
                    }
                }
                if(a=="False"){
                    if(linha[5] == a){
                    i++;
                    }
                }
                if(a=="Excluido"){
                    if(linha[5] == a){
                    i++;
                    }
                }
                
            }
            return i;
        }


        public Depoimento ProcurarDepoimento (int id) {
            string[] linhas = File.ReadAllLines ("Database/depoimentos.csv");
            foreach (var item in linhas) {
                string[] linha = item.Split (";");
                if (id.ToString().Equals(linha[0])) {
                    Depoimento depoimento = new Depoimento();
                    depoimento.Id = int.Parse(linha[0]);
                    depoimento.Nome = linha[1];
                    depoimento.Profissao = linha[2];
                    depoimento.Texto = linha[3];
                    depoimento.Data = DateTime.Parse(linha[4]);
                    depoimento.Aprovado = linha[5];
                    return depoimento;
                }
            }
            return null;
        }
    }
}