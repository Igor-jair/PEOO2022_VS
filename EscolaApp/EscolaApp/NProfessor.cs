using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EscolaApp
{
    static class NProfessor
    {
        private static List<Professor> Professor = new List<Professor>();
        public static void Inserir(Professor p)
        {
            Abrir();
            Professor.Add(p);
            Salvar();
        }
        public static List<Professor> Listar()
        {
            Abrir();
            return Professor;
        }
        public static void Excluir(Professor p)
        {
            Abrir();
            // Percorrer a lista de Aluno procurando o id informado (t.Id)
            Professor x = null;
            foreach (Professor obj in Professor)  
                if (obj.Id == p.Id) x = obj;
            if (x != null) Professor.Remove(x);
            Salvar();
        }
        public static void Atualizar(Professor p)
        {
            Abrir();
            // Percorrer a lista de Aluno procurando o id informado (t.Id)
            foreach (Professor obj in Professor)
                if (obj.Id == p.Id)
                {
                    obj.Nome = p.Nome;
                    obj.Matricula = p.Matricula;
                    obj.Area = p.Area;
                }
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                // objeto que transforma uma lista de Alunos em texto em XML
                XmlSerializer xml = new XmlSerializer(typeof(List<Professor>));
                // objeto que abre um texto em um arquivo
                f = new StreamReader("./Professor.xml");
                // chama a operação de desserialização informando o destino do texto XML
                Professor = (List<Professor>)xml.Deserialize(f);
                // fecha o arquivo
            }
            catch
            {
                Professor = new List<Professor>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            // objeto que transforma uma lista de Alunos em texto em XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Professor>));
            // objeto que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./Professor.xml", false);
            // chama a operação de serialização informando o destino do texto XML
            xml.Serialize(f, Professor);
            // fecha o arquivo
            f.Close();
        }
        
    }
}
