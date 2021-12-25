using System;
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
            var incrementalNumber = 300;

            for (var i = 97; i <= 122; i++)
            {
                for (var j = 97; j <= 122; j++)
                {
                    var zipTable = new ZipTable();

                    incrementalNumber += 1;

                    var mainKey = Convert.ToChar(i).ToString();
                    var key = Convert.ToChar(i).ToString() + Convert.ToChar(j).ToString();

                    var value = Convert.ToChar(incrementalNumber).ToString();

                    zipTable.mainKey = mainKey.ToString();
                    zipTable.key = key;
                    zipTable.value = value;

                    Console.WriteLine(mainKey + " " + key + " " + value);

                    tabelList.Add(zipTable);
                }
            }

            
        }


        void execute()
        {
            string text = @"anilkumarp";

            Console.WriteLine("Hello World!");

            int phases = 2;

            var zipped = zip(text, phases);

            var unzipped = unZip(zipped, phases);


            Console.WriteLine(zipped);
            Console.WriteLine(unzipped);
            Console.WriteLine( "zipped " + text + " " + zipped);
            Console.WriteLine("un zipped " + text + " " + unzipped);
            Console.ReadLine();
            Console.ReadLine();
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

            Console.WriteLine(result);

            return result;
        }

        string unZip(string text, int phases)
        {

            string result = "";

            for (var j = 0; j < text.Length; j += 1)
            {
                for (int i = tabelList.Count -1; i >=0; i--)
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
