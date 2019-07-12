using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscadorDeEscalas
{
    public class Notas
    {
        // === VARIÁVEIS DA CLASSE (INSTANCIÁVEIS) ===
        public List<Nota> notasSelecionadas = new List<Nota>();

        // === VARIÁVEIS ESTÁTICAS ===
        public static Nota C = new Nota(0, "C");
        public static Nota C_sharp = new Nota(1, "C#");
        public static Nota D = new Nota(2, "D");
        public static Nota D_sharp = new Nota(3, "D#");
        public static Nota E = new Nota(4, "E");
        public static Nota F = new Nota(5, "F");
        public static Nota F_sharp = new Nota(6, "F#");
        public static Nota G = new Nota(7, "G");
        public static Nota G_sharp = new Nota(8, "G#");
        public static Nota A = new Nota(9, "A");
        public static Nota A_sharp = new Nota(10, "A#");
        public static Nota B = new Nota(11, "B");
        // Todas as notas
        public static Notas todasNotas = new Notas(new Nota[]{ C, C_sharp, D, D_sharp, E, F, F_sharp, G, G_sharp, A, A_sharp, B }.ToList());

        // === INDEXADORES ===
        // Método Length
        public int Length
        {
            get { return notasSelecionadas.Count(); }
        }
        
        // Métodos Add
        public void Add(Nota nota)
        {
            notasSelecionadas.Add(nota);
        }

        public void Add(int nota)
        {
            notasSelecionadas.Add(new Nota(nota));
        }

        // Método Clear
        public void Clear()
        {
            notasSelecionadas.Clear();
        }

        // Indexador da lista
        public Nota this[int index]
        {
            get
            {
                return notasSelecionadas[index];
            }

            set
            {
                notasSelecionadas[index] = value;
            }
        }

        // Iterador
        public IEnumerator<Nota> GetEnumerator()
        {
            foreach (Nota nota in notasSelecionadas)
            {
                yield return nota;
            }            
        }

        // === CONSTRUTORES ===
        public Notas()
        {

        }

        public Notas(List<int> idsNotas)
        {
            if (idsNotas != null)
            {
                foreach (int idNota in idsNotas)
                {
                    notasSelecionadas.Add(new Nota(idNota, todasNotas[idNota].nome));
                }
            }
        }

        public Notas(List<Nota> notas)
        {
            if (notas != null)
            {
                foreach (Nota nota in notas)
                {
                    notasSelecionadas.Add(new Nota(nota));
                }
            }
        }

        // === MÉTODOS ESTÁTICOS ===

        public static Nota CalculaNota(Nota nota, Intervalo intervalo)
        {
            int resultado = nota.id + intervalo.id;
            if (resultado > 11)
            {
                resultado -= 12;
            }
            Nota notaReturn = new Nota(resultado);
            return notaReturn;
        }
    }
}
