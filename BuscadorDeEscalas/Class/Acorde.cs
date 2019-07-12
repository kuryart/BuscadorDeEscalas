using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscadorDeEscalas.Class
{
    class Acorde
    {
        public Intervalos intervalosDoAcorde;
        public Notas notasDoAcorde;

        // Modelos de acordes
        public static Intervalos acorde_M = new Intervalos(new List<Intervalo>() { Intervalos.i_T, Intervalos.i_3M, Intervalos.i_5 });
        public static Intervalos acorde_m = new Intervalos(new List<Intervalo>() { Intervalos.i_T, Intervalos.i_3m, Intervalos.i_5 });
               
        public Acorde()
        {

        }

        public Acorde(Nota tonica, Intervalos _intervalos)
        {
            intervalosDoAcorde = _intervalos;             

            foreach (Intervalo intervalo in _intervalos.intervalosSelecionados) 
            {
                notasDoAcorde.notasSelecionadas.Add(Notas.CalculaNota(tonica, intervalo));
            }
        }
    }
}
