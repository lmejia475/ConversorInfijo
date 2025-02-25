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




    }

}
