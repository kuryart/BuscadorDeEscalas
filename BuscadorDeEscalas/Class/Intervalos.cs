using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscadorDeEscalas
{
    public class Intervalos
    {
        // === VARIÁVEIS DA CLASSE (INSTANCIÁVEIS) ===
        // Um grupo de intervalos
        public List<Intervalo> intervalosSelecionados = new List<Intervalo>();

        // === VARIÁVEIS ESTÁTICAS === 
        // Intervalos
        public static Intervalo i_T = new Intervalo(0, "T");
        public static Intervalo i_2b = new Intervalo(1, "2b");
        public static Intervalo i_2 = new Intervalo(2, "2");
        public static Intervalo i_3m = new Intervalo(3, "3m");
        public static Intervalo i_3M = new Intervalo(4, "3M");
        public static Intervalo i_4 = new Intervalo(5, "4");
        public static Intervalo i_5b = new Intervalo(6, "5b");
        public static Intervalo i_5 = new Intervalo(7, "5");
        public static Intervalo i_5_sharp = new Intervalo(8, "5#");
        public static Intervalo i_6 = new Intervalo(9, "6");
        public static Intervalo i_7 = new Intervalo(10, "7");
        public static Intervalo i_7M = new Intervalo(11, "7M");
        
        // Todos os intervalos
        public static Intervalos todosIntervalos1 = new Intervalos(new Intervalo[] {i_T, i_2b, i_2, i_3m, i_3M, i_4, i_5b, i_5, i_5_sharp, i_6, i_7, i_7M}.ToList());

        // === CONSTANTES ===        
        public const int semitom = 1;
        public const int tom = 2;

        // === INDEXADORES ===
        // Método Length
        public int Length
        {
            get { return intervalosSelecionados.Count(); }
        }

        // Métodos Add
        public void Add(Intervalo intervalo)
        {
            intervalosSelecionados.Add(intervalo);
        }

        public void Add(int intervalo)
        {
            intervalosSelecionados.Add(new Intervalo(intervalo));
        }

        // Método Clear
        public void Clear()
        {
            intervalosSelecionados.Clear();
        }

        // Indexador da lista
        public Intervalo this[int index]
        {
            get
            {
                return intervalosSelecionados[index];
            }

            set
            {
                intervalosSelecionados[index] = value;
            }
        }

        // Iterador
        public IEnumerator<Intervalo> GetEnumerator()
        {
            foreach (Intervalo intervalo in intervalosSelecionados)
            {
                yield return intervalo;
            }
        }

        // === CONSTRUTORES DA CLASSE ===
        public Intervalos()
        {

        }

        public Intervalos(List<int> idsIntervalos)
        {       
            if (idsIntervalos != null)
            {
                foreach (int idIntervalo in idsIntervalos)
                {
                    intervalosSelecionados.Add(new Intervalo(idIntervalo, todosIntervalos1.intervalosSelecionados.Find(x => x.id == idIntervalo).nome));
                }
            }
        }

        public Intervalos(List<Intervalo> intervalos)
        {
            if (intervalos != null)
            {
                foreach (Intervalo intervalo in intervalos)
                {
                    intervalosSelecionados.Add(new Intervalo(intervalo));
                }
            }
        }

        // === MÉTODOS ESTÁTICOS ===
        // Calcula distância entre um intervalo e outro

        public static Intervalo CalculaIntervalo(Nota notaInicial, Nota notaFinal)
        {
            int resultado = notaFinal.id - notaInicial.id;            
            if (resultado < 0)
            {
                resultado += 12;
            }
            Intervalo intervaloReturn = new Intervalo(resultado);

            return intervaloReturn;
        }

    }
}
