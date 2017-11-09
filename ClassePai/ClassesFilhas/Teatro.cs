using System;
using System.IO;
using System.Text;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Teatro : Evento
    {
        public string[] Elenco { get; set; }
        public string Diretor { get; set; }

        public Teatro(){

        }
        public Teatro(string Titulo, string Local, int Lotacao, string Duracao, int Classificacao, DateTime Data, string[] _Elenco, string _Diretor)
        {
            base.Titulo = Titulo;
            base.Local = Local;
            base.Lotacao = Lotacao;
            base.Duracao = Duracao;
            base.Classificacao = Classificacao;
            base.Data = Data;
            this.Elenco = _Elenco;
            this.Diretor = _Diretor;
        }

        public override bool Cadastrar()
        {
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

            try{
                arquivo = new StreamWriter("teatro.csv",true);
                arquivo.WriteLine(Titulo+";"+Local+";"+Lotacao+";"+Duracao+";"+Classificacao+";"+Data+";"+membros+";"+this.Diretor);
                efetuado = true;
            }
            catch(Exception ex){
                throw new Exception("Erro ao gravar arquivo "+ex.Message);
            }
            finally{
                arquivo.Close();
            }

            return efetuado;
        }

        public override string Pesquisar(string _Titulo)
        {
            StreamReader ler = null;
            string linha = "";
            string resultado = "Titulo não encontrado"; 

            try{
                ler = new StreamReader("teatro.csv",Encoding.Default);

                while((linha=ler.ReadLine())!=null){
                    string[] dados = linha.Split(';');

                    if(dados[0] == _Titulo){
                        resultado = linha;                    
                        break;
                    } 
                }

            }catch(Exception ex){
                resultado = "Erro ao ler arquivo "+ex.Message;
            }
            finally{
                ler.Close();
            }

            return resultado;
        }

        public override string Pesquisar(DateTime _Data)
        {
            StreamReader ler = null;
            string linha = "";
            string resultado = "Data não encontrada"; 

            try{
                ler = new StreamReader("teatro.csv",Encoding.Default);

                while((linha=ler.ReadLine())!=null){
                    string[] dados = linha.Split(';');

                    if(dados[5] == _Data.ToString()){
                        resultado = linha;                    
                        break;
                    } 
                }

            }catch(Exception ex){
                resultado = "Erro ao ler arquivo "+ex.Message;
            }
            finally{
                ler.Close();
            }

            return resultado;
        }
    }
}