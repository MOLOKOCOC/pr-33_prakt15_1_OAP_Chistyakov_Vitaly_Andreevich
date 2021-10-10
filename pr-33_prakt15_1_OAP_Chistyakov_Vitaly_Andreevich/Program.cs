using System;
using System.Collections;
using System.IO;

namespace pr_33_prakt15_1_OAP_Chistyakov_Vitaly_Andreevich
{
    class Program
    {
        public static void Main()
        {
            StreamReader fileIn = new StreamReader("t.txt");
            string line = fileIn.ReadToEnd();
            fileIn.Close();
            Stack skobki = new Stack();
            bool flag = true;
            //проверяем баланс скобок 
            for (int i = 0; i < line.Length; i++)
            {
                //текущий символ открывающаяся скобка, то помещаем ее в стек
                if (line[i] == '(') skobki.Push(i);
                else if (line[i] == ')') //если текущий символ закрывающаяся скобка, то
                {
                    //если стек пустой, то для закрывающейся скобки не хватает парной открывающейся
                    if (skobki.Count == 0)
                    { flag = false; Console.WriteLine("Возможно в позиции " + i + " лишняя ) скобка"); }
                    else skobki.Pop(); //иначе извлекаем парную скобку
                }
            }
            //если после просмотра строки стек оказался пустым, то скобки сбалансированы
            if (skobki.Count == 0) { if (flag) Console.WriteLine("скобки сбалансированы"); }
            else //иначе баланс скобок нарушен
            {
                Console.Write("Возможно лишняя ( скобка в позиции: ");
                while (skobki.Count != 0)
                {
                    Console.Write("{0} ", (int)skobki.Pop());
                }
                Console.WriteLine();
            }
        }
    }
}
