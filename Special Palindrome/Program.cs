using System;
using System.Collections.Generic;
using System.Linq;

namespace Special_Palindrome
{
    class Program
    {
        //Special Palindrome Again Problem - Solution By DeltaFoX aka Russo Paolo Rito 
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string to determinate how many palindromic substrings can be formed :\n");
            string s = Console.ReadLine().Trim();
            //Se Input è minore o uguale a 0 Esco dal Soft
            if (s.Length <= 0)
                Environment.Exit(0);
            Console.WriteLine("\nPartial Result :\n");
            //Printo a Video su singola linea i singoli valori dell'array che sono palindromi per definizione
            Console.Write("{" + s[0]);
            for (int i = 1; i < s.Length; i++)
                Console.Write(", " + s[i]);
            //Invio al Calcolo l'array messo in input di cui Calcolo il Numero di valori e gli aggiungo la lunghezza dei singoli valori dell'array che sono palindromi per definizione
            int d = GetPalindromes(s).Count() + s.Trim().Length;
            Console.WriteLine("}\n\nSubstrings can be formed from it :\n");
            //Printo a Video La somma ottenuta
            Console.Write(d.ToString());
            //Attendo Input da parte Utente per chiudere la win della Console
            Console.ReadLine();
        }
        //Uso la Funzione List per gestire tutte le possibili varianti palindrome
        private static List<string> GetPalindromes(string source)
        {
            //Inizializzo la variabile subsets come nuova lista
            List<string> subsets = new List<string>();
            //Inizializzo un ciclo for su tutto l'array stringa inserito in Input
            for (int i = 0; i < source.Length - 1; i++)
            {
                //Ulteriore ciclo for sullo stesso array ma con + 1
                for (int j = i + 1; j <= source.Length; j++)
                {
                    //Verifico che i valore dell'array precedente esiste e che i successivi alla selezione siano uguali al valore parsato al momento nell'array array
                    if (j - i > 1 && source[j - 1] == source[i])
                    {
                        //In caso positivo ne prelevo il valore
                        string currentSubset = source.Substring(i, j - i);
                        //Lo invio al metodo che ne verifica la Proprietà Palindroma senza escludere eventuali doppioni
                        if (IsPalindrome(currentSubset))
                        {
                            //In Caso Positivo Printo il valore della stringa palindroma individuata divisi per comma
                            Console.Write(", " + currentSubset);
                            //Aggiungo alla List il valore Palindromo Trovato
                            subsets.Add(currentSubset);
                        }
                    }
                }
            }
            //Ritorno la List Completa Settata
            return subsets;
        }
        private static bool IsPalindrome(string str)
        {
            //Verifico che la sequenza della stringa data in Ingresso sia equivalente alla stessa ma reversata 
            return str.SequenceEqual(str.Reverse());
        }
    }
}
