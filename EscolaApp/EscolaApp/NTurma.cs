using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EscolaApp
{
    static class NTurma
    {

        //private Turma[] turmas = new Turma[10];
        private static List<Turma> turmas = new List<Turma>();
        public static void Inserir(Turma t) {
            Abrir();
            //Procurar o maior Id
            int id = 0;
            foreach (Turma obj in turmas)
                if (obj.Id > id) id = obj.Id;
            t.Id = id + 1;
            turmas.Add(t);
            Salvar();
        }
        public static List<Turma> Listar()
        {
            Abrir();
            return turmas;
        }
        public static void Atualizar(Turma t)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            foreach(Turma obj in turmas)
                if (obj.Id == t.Id)
                {
                    obj.Curso = t.Curso;
                    obj.Descricao = t.Descricao;
                    obj.AnoLetivo = t.AnoLetivo;
                }
            Salvar();
        }
        public static void Excluir(Turma t)
        {
            Abrir();
            // Percorrer a lista de turma procurando o id informado (t.Id)
            Turma x = null;
            foreach (Turma obj in turmas)
                if (obj.Id == t.Id) x = obj;
            if (x != null) turmas.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                // objeto que transforma uma lista de turmas em texto em XML
                XmlSerializer xml = new XmlSerializer(typeof(List<Turma>));
                // objeto que abre um texto em um arquivo
                f = new StreamReader("./turmas.xml");
                // chama a operação de desserialização informando o destino do texto XML
                turmas = (List<Turma>)xml.Deserialize(f);
                // fecha o arquivo
            }
            catch
            {
                turmas = new List<Turma>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            // objeto que transforma uma lista de turmas em texto em XML
            XmlSerializer xml = new XmlSerializer(typeof(List<Turma>));
            // objeto que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./turmas.xml", false);
            // chama a operação de serialização informando o destino do texto XML
            xml.Serialize(f, turmas);
            // fecha o arquivo
            f.Close();
        }

    }
}
