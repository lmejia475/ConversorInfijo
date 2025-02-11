using System.Collections;

namespace PilaBlazor.Services
{
    public class Pila //  : IEnumerable
    {
        public int[] Elementos { get; set; }

        public int MAX { get; set; }

        public int TOPE { get; set; }

        public int Valor { get; set; }

        public Pila(int max)
        {
            MAX = max;
            Elementos = new int[MAX];
            TOPE = 0;
        }

        public bool IsEmpty => TOPE == 0;

        public bool IsFull => TOPE == Elementos.Length;

        public void Push(int valor)
        {
            if (IsFull) return;

            Elementos[TOPE] = valor;
            TOPE++;
        }

        public int Pop()
        {
            if (IsEmpty) return -1;

            TOPE--;

            return Elementos[TOPE];
        }

        //public IEnumerator GetEnumerator()
        //{
        //    for (int i = TOPE - 1; i >= 0; i--)
        //    {
        //        yield return Elementos[i];
        //    }
        //}
    }

}
