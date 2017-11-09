using System;
using System.IO;
using System.Text;

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
            bool efetuado=false;
            StreamWriter arquivo = null;

            try
            {
                arquivo = new StreamWriter("show.csv",true);
                arquivo.WriteLine(Titulo+";"+Local+";"+Lotacao+";"+Duracao+";"+Classificacao+";"+Data+";"+Artista+";"+GeneroMusical);
                efetuado = true;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao tentar gravar arquivo "+ex.Message);
            }
            finally
            {
                arquivo.Close();
            } 

            return efetuado;
        }

        public override string Pesquisar(string _Titulo){
            string resultado = "TItulo não encontrado";
            StreamReader ler = null;

            try{
                ler = new StreamReader("show.csv",Encoding.Default);
                string linha="";

                while((linha=ler.ReadLine())!=null){
                    string[] dados = linha.Split(';');

                    if (dados[0]==_Titulo){
                        resultado = linha;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                resultado = "Erro ao tentar ler arquivo "+ex.Message;
            }
            finally{
                ler.Close();
            }
            
            return resultado;
        }

        public override string Pesquisar(DateTime _Data){
            string resultado = "Data não encontrada";
            StreamReader ler = null;

            try{
                ler = new StreamReader("show.csv",Encoding.Default);
                string linha="";

                while((linha=ler.ReadLine())!=null){
                    string[] dados = linha.Split(';');

                    if (dados[5]==_Data.ToString()){
                        resultado = linha;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                resultado = "Erro ao tentar ler arquivo "+ex.Message;
            }
            finally{
                ler.Close();
            }

            return resultado;
        }

    }
}