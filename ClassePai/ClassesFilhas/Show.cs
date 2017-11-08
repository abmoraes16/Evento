using System;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    /// <summary>
    /// Classe herda atributos e métodos da classe Evento
    /// </summary>
    public class Show : Evento
    {
        public string Artista { get; set; }
        public string GeneroMusical { get; set; }
        
        public Show(){

        }

        public Show(string Titulo, string Local, int Lotacao, string Duracao, int Classificacao, DateTime Data, string Artista, string Genero)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;
            this.Artista = Artista;
            this.GeneroMusical = Genero;

        }

        public override bool Cadastrar(){
            return false;
        }
    }
}