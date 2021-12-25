﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zip
{

    class ZipTable
    {
       public string mainKey = "";
       public string key = "";
       public string value = "";
       public int phase = 0;
    }


    class Program
    {

        static List<ZipTable> tabelList = new List<ZipTable>();

        Program()
        {
            uint incrementalNumber = 0; // 2 bytes value


            for (var i = 97; i <= 122; i++)
            {
                for (var j = 97; j <= 122; j++)
                {
                    var zipTable = new ZipTable();

                  
                    var mainKey = Convert.ToChar(i).ToString();
                    var key = Convert.ToChar(i).ToString() + Convert.ToChar(j).ToString();

                    var value = Convert.ToChar(incrementalNumber).ToString();

                    //var value = (char)incrementalNumber;

                    zipTable.mainKey = mainKey.ToString();
                    zipTable.key = key;
                    zipTable.value = value;

                    Console.WriteLine(mainKey + " " + key + " " + value);

                    tabelList.Add(zipTable);

                    incrementalNumber += 1;

                }
            }

            
        }


        void execute()
        {
            string text = @"anilkumarp[padding]";

            Console.WriteLine("**************Hello World!**************");

            int phases = 2;

            if(text.Length %2 != 0)
            {
                text += "0";
            }
          

            var zipped = zip(text, phases);

           

            var unzipped = unZip(zipped, phases);

            Console.WriteLine("Original Text :::");
  
            Console.WriteLine( text);
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Zipped ::: ");
            Console.WriteLine(zipped);
            Console.WriteLine("");


            Console.WriteLine("Un zipped ::: ");
            Console.WriteLine(unzipped);
            Console.WriteLine("");

            Console.ReadKey();

        }

        string zip(string text, int phases)
        {
            string result = "";

            for (var j = 0; j < text.Length; j += 2) {
                for (int i = 0; i < tabelList.Count; i++)
                {
                    string to = (Convert.ToChar(text[j]).ToString() + "" + Convert.ToChar(text[j+1]).ToString()).ToString();

                    if( tabelList[i].key == to)
                    {
                        result += tabelList[i].value;
                    }
                    
                }
            }

            return result;
        }

        string unZip(string text, int phases)
        {

            string result = "";

            for (var j = 0; j < text.Length; j += 1)
            {
                for (int i = 0 ; i< tabelList.Count ; i++)
                {
                    string to = (Convert.ToChar(text[j]).ToString()).ToString();

                    if (tabelList[i].value == to)
                    {
                        result += tabelList[i].key;
                    }
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            p.execute();
           
        }

    }
}
