using System;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Cinema : Evento
    {
        public string Genero { get; set; }
        public DateTime[] Sessoes{ get; set; }
        
    }
}