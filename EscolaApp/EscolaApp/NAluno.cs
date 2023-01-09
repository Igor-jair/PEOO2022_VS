using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EscolaApp
{
    static class NAluno
    {

        //private Aluno[] Alunos = new Aluno[10];
        private static List<Aluno> Alunos = new List<Aluno>();
        public static void Inserir(Aluno t)
        {
            Abrir();
            Alunos.Add(t);
            Salvar();
        }
        public static List<Aluno> Listar()
        {
            Abrir();
            return Alunos;
        }
        public static void Atualizar(Aluno t)
        {
            Abrir();
            // Percorrer a lista de Aluno procurando o id informado (t.Id)
            foreach (Aluno obj in Alunos)
                if (obj.Id == t.Id)
                {
                    obj.Nome = t.Nome;
                    obj.Matricula = t.Matricula;
                    obj.Email = t.Email;
                }
            Salvar();
        }
        public static void Excluir(Aluno t)
        {
            Abrir();
            // Percorrer a lista de Aluno procurando o id informado (t.Id)
            Aluno x = null;
            foreach (Aluno obj in Alunos)
                if (obj.Id == t.Id) x = obj;
            if (x != null) Alunos.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                // objeto que transforma uma lista de Alunos em texto em XML
                XmlSerializer xml = new XmlSerializer(typeof(List<Aluno>));
                // objeto que abre um texto em um arquivo
                f = new StreamReader("./Alunos.xml");
                // chama a operação de desserialização informando o destino do texto XML
                Alunos = (List<Aluno>)xml.Deserialize(f);
                // fecha o arquivo
            }
            catch
            {
                Alunos = new List<Aluno>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            // objeto que transforma uma lista de Alunos em texto em XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Aluno>));
            // objeto que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./Alunos.xml", false);
            // chama a operação de serialização informando o destino do texto XML
            xml.Serialize(f, Alunos);
            // fecha o arquivo
            f.Close();
        }

    }
}
