using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscadorDeEscalas
{
    public class Nota
    {
        public int id;
        public string nome;
        public int oitava;
        public int frequencia;

        public Nota()
        {
            id = -1;
            nome = "";
        }

        public Nota(int _id, string _nome)
        {
            id = _id;
            nome = _nome; 
        }


        public Nota(Nota _nota)
        {
            id = _nota.id;
            nome = _nota.nome;
        }

        public Nota(int _id)
        {
            id = _id;
            nome = Notas.todasNotas[id].nome;
        }
    }
}
