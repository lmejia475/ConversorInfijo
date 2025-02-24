using System.Collections;

namespace PilaBlazor.Services
{
    public class Pila 
    {
        public string[] Elementos { get; set; }

        public static int Prioridad(string operador)
        {
            switch(operador)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 0;
            }
        }

        public static double EvaluarPostfija(string postfija)
        {
            Stack<double> pila = new Stack<double>();

            for (int i = 0; i < postfija.Length; i++)
            {
                char valor = postfija[i];

                if (char.IsDigit(valor)) 
                {
                    pila.Push(char.GetNumericValue(valor));
                }
                else if (valor == '+' || valor == '-' || valor == '*' || valor == '/' || valor == '^')
                {
                    
                    double op2 = pila.Pop(); 
                    double op1 = pila.Pop(); 
                    double resultado = 0;

                    switch (valor)
                    {
                        case '+': resultado = op1 + op2; break;
                        case '-': resultado = op1 - op2; break;
                        case '*': resultado = op1 * op2; break;
                        case '/': resultado = op1 / op2; break;
                        case '^': resultado = Math.Pow(op1, op2); break;
                    }

                    pila.Push(resultado); 
                }
            }
            return pila.Pop(); 
        }

        public int MAX { get; set; }

        public int TOPE { get; set; }

        public int Valor { get; set; }

        public Pila(int max)
        {
            MAX = max;
            Elementos = new string[MAX];
            TOPE = 0;
        }

        public bool IsEmpty => TOPE == 0;

        public bool IsFull => TOPE == Elementos.Length;

        public void Push(string valor)
        {
            if (IsFull) return;

            Elementos[TOPE] = valor;
            TOPE++;
        }

        public string Pop()
        {
            if (IsEmpty) return "";

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
