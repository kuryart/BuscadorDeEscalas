using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscadorDeEscalas
{
    public class Intervalo
    {
        public int id;
        public string nome;
        public int oitava;

        public Intervalo()
        {
            id = -1;
            nome = "";
        }
               
        public Intervalo(int _id, string _nome)
        {
            id = _id;
            nome = _nome;
        }

        public Intervalo(Intervalo intervalo)
        {
            id = intervalo.id;
            nome = intervalo.nome;
        }

        public Intervalo(int _id)
        {
            id = _id;
            nome = Intervalos.todosIntervalos1.intervalosSelecionados.Find(x => x.id == id).nome;
        }
    }
}
