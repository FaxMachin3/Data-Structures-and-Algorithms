using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class CrossW
{

    static string[] result;
    // Complete the crosswordPuzzle function below.
    static void crosswordPuzzle(string[] crossword, List<string> words)
    {
        if (Valid(crossword, words))
        {
            result = crossword;
            return;
        }

        if (words.Count == 0)
        {
            return;
        }

        for (int w = 0; w < words.Count; w++)
        {
            string word = words[w];

            string[] copyCrossword = CopyCrossWord(crossword);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    if (crossword[i][j] != '+')
                    {
                        bool canPutWord = true;
                        if (j + word.Length <= crossword.Length)
                        {
                            for (int x = 0; x < word.Length; x++)
                            {
                                var ch = crossword[i][j + x];
                                if (ch == '-' || ch == word[x])
                                {
                                    StringBuilder sb = new StringBuilder(copyCrossword[i]);
                                    sb[j + x] = word[x];
                                    copyCrossword[i] = sb.ToString();
                                }
                                else
                                {
                                    canPutWord = false;
                                    break;
                                }
                            }

                            if (canPutWord)
                            {
                                words.RemoveAt(w);
                                crosswordPuzzle(copyCrossword, words);
                                words.Insert(w, word);
                            }

                            copyCrossword = CopyCrossWord(crossword);
                        }

                        canPutWord = true;

                        if (i + word.Length <= crossword.Length)
                        {
                            for (int x = 0; x < word.Length; x++)
                            {
                                var ch = crossword[i + x][j];
                                if (ch == '-' || ch == word[x])
                                {
                                    StringBuilder sb = new StringBuilder(copyCrossword[i + x]);
                                    sb[j] = word[x];
                                    copyCrossword[i + x] = sb.ToString();
                                }
                                else
                                {
                                    canPutWord = false;
                                    break;
                                }
                            }

                            if (canPutWord)
                            {
                                words.RemoveAt(w);
                                crosswordPuzzle(copyCrossword, words);
                                words.Insert(w, word);
                            }

                            copyCrossword = CopyCrossWord(crossword);
                        }
                    }
                }
            }
        }
    }


    static string[] CopyCrossWord(string[] crossword)
    {
        string[] arr = new string[10];

        for (int i = 0; i < 10; i++)
        {
            arr[i] = string.Copy(crossword[i]);
        }

        return arr;
    }

    static bool Valid(string[] crossword, List<string> words)
    {
        if (words.Count != 0)
        {
            return false;
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (crossword[i][j] == '-')
                {
                    return false;
                }
            }
        }

        return true;
    }

    // static void Main(string[] args)
    // {
    //     string[] crossword = new string[10]{
    //         "+-++++++++",
    //         "+-++++++++",
    //         "+-------++",
    //         "+-++++++++",
    //         "+-++++++++",
    //         "+------+++",
    //         "+-+++-++++",
    //         "+++++-++++",
    //         "+++++-++++",
    //         "++++++++++",
    //     };

    //     string words = "AGRA;NORWAY;ENGLAND;GWALIOR";
    //     crosswordPuzzle(crossword, words.Split(';').ToList());

    //     Console.WriteLine(string.Join("\n", result));
    // }
}