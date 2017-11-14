using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Cinema : Evento
    {
        public string Genero { get; set; }
        public string[] Sessoes{ get; set; }
        public string[] Elenco  { get; set; }

        public Cinema(){

        }

        public Cinema(string Titulo, string Local, int Lotacao, string Duracao, int Classificacao, DateTime Data, string[] _Sessoes, string[] _Elenco, string _Genero){
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;
            this.Elenco = _Elenco;
            this.Sessoes = _Sessoes;
            this.Genero = _Genero;
        }


           public override bool Cadastrar(){
            bool efetuado=false;
            StreamWriter arquivo = null;

            string membros="";
            bool efetuado = false;

            foreach(string Membro in Elenco){
                if(Elenco[Elenco.Length-1]==Membro)
                {
                    membros = Membro;    
                }
                else
                {
                    membros = Membro + ",";
                }
            }

            string sessoes="";
            efetuado = false;

            foreach(string Sessao in Sessoes){
                if(Elenco[Elenco.Length-1]==Sessao)
                {
                    sessoes = Sessao;    
                }
                else
                {
                    sessoes = Sessao+ ",";
                }
            }

            try
            {
                arquivo = new StreamWriter("cinema.csv",true);
                arquivo.WriteLine(Titulo+";"+Local+";"+Lotacao+";"+Duracao+";"+Classificacao+";"+Data+";"+Sessoes+";"+membros+";"+Genero);
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
                ler = new StreamReader("cinema.csv",Encoding.Default);
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
                ler = new StreamReader("cinema.csv",Encoding.Default);
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