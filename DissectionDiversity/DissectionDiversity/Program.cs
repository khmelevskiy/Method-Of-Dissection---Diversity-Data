//Method of Dissection - Diversity Data

using System;
using System.Collections.Generic;
using System.IO;

namespace DissectionDiversity
{
    class Program
    {
        //I think everything is clear from the title :)
        static int theNumberOfBlocks;
        static int[] keyColumn;
        static int theNumberOfColumns;
        static int[] keyRow;
        static string theInputString;
        static int maxSizeArray; //jagged array[][this size]
        static string[][] arrayKeys;
        static int lengthRow;//jagged array[this size][] and for corect table key-value
        static Dictionary<int, string> DictionaryBlockValue;
        StreamWriter sw;//For record everything in the file


        //Because values must not be repeated, check there is the element or not
        public bool SearchForValuesInAnArray(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
                if (value == arr[i])
                    return false;
            return true;
        }

        //to fill key columns and rows of keys
        public void MyRandom(ref int[] arr, int maxValue)
        {
            int counter = 1;
            int temp;
            Random rnd = new Random();
            arr = new int[maxValue];
            arr[0] = rnd.Next(1, maxValue + 1);
            while (counter != maxValue)
            {
                temp = rnd.Next(1, maxValue + 1);
                if (SearchForValuesInAnArray(arr, temp))
                    arr[counter++] = temp;
            }
        }

        //filling of the massif = to values of lines and columns
        //and
        //output table key-value
        public void SetKeysAndPrint(ref string[][] arr)
        {
            int row = keyRow[0], column = 0, counterLengthString = 0, valueForKeysRows = keyRow[0], counterForPrint = -1, counterKeyRowInTable = -1;

            //indentation from before the column numbers for correct display
            if (keyRow.Length < 10)
            {
                Console.Write(" |");
                sw.Write(" |");
            }
            else if (keyRow.Length >= 10 && keyRow.Length < 100)
            {
                Console.Write("  |");
                sw.Write("  |");
            }
            else if (keyRow.Length >= 100 && keyRow.Length < 1000)
            {
                Console.Write("   |");
                sw.Write("   |");
            }
            //the end of a space before numbers of columns

            //display of values of columns
            for (int count = 0; count < theNumberOfColumns; count++)
            {
                if (keyColumn.Length < 10)
                {
                    Console.Write("{0}|", keyColumn[count]);
                    sw.Write("{0}|", keyColumn[count]);
                }
                else if (keyColumn.Length >= 10 && keyColumn.Length < 100)
                {
                    if (keyColumn[count] < 10)
                    {
                        Console.Write(" {0}|", keyColumn[count]);
                        sw.Write(" {0}|", keyColumn[count]);
                    }
                    else if (keyColumn[count] >= 10)
                    {
                        Console.Write("{0}|", keyColumn[count]);
                        sw.Write("{0}|", keyColumn[count]);
                    }
                }
                else if (keyColumn.Length >= 100 && keyColumn.Length < 1000)
                {
                    if (keyColumn[count] < 10)
                    {
                        Console.Write("  {0}|", keyColumn[count]);
                        sw.Write("  {0}|", keyColumn[count]);
                    }
                    else if (keyColumn[count] >= 10 && keyColumn[count] < 100)
                    {
                        Console.Write(" {0}|", keyColumn[count]);
                        sw.Write(" {0}|", keyColumn[count]);
                    }
                    else
                    {
                        Console.Write("{0}|", keyColumn[count]);
                        sw.Write("{0}|", keyColumn[count]);
                    }
                }
                else if (keyColumn.Length >= 1000 && keyColumn.Length < 10000)
                {
                    if (keyColumn[count] < 10)
                    {
                        Console.Write("   {0}|", keyColumn[count]);
                        sw.Write("   {0}|", keyColumn[count]);
                    }
                    else if (keyColumn[count] >= 10 && keyColumn[count] < 100)
                    {
                        Console.Write("  {0}|", keyColumn[count]);
                        sw.Write("  {0}|", keyColumn[count]);
                    }
                    else if (keyColumn[count] >= 100 && keyColumn[count] < 1000)
                    {
                        Console.Write(" {0}|", keyColumn[count]);
                        sw.Write(" {0}|", keyColumn[count]);
                    }
                    else
                    {
                        Console.Write("{0}|", keyColumn[count]);
                        sw.Write("{0}|", keyColumn[count]);
                    }
                    //end of display of values of columns
                }
            }

            Console.WriteLine();
            sw.WriteLine();

            //approximate filling with a symbol "-" after numbers of columns
            if (keyRow.Length < 10)
            {
                Console.WriteLine("-".PadRight(keyColumn.Length * 4, '-'));
                sw.WriteLine("-".PadRight(keyColumn.Length * 4, '-'));
            }
            //end filling

            //for corect display table key-value.        The number of rows = number of rows / number of columns
            for (int rows = 0; rows < lengthRow; rows++)
            {
                //Check for the correct filling of numbers of rows 
                if (counterKeyRowInTable < keyRow.Length - 1)
                    counterKeyRowInTable++;
                else
                    counterKeyRowInTable = 0;

                //validate display of value for keys rows 
                if (valueForKeysRows > keyRow.Length)
                {
                    ++rows;
                    valueForKeysRows = keyRow[0];
                }
                valueForKeysRows = keyRow[counterKeyRowInTable];

                //display of values of rows
                if (keyRow.Length < 10)
                {
                    Console.Write("{0}|", valueForKeysRows);
                    sw.Write("{0}|", valueForKeysRows);
                }
                else if (keyRow.Length >= 10 && keyRow.Length < 100)
                {
                    if (valueForKeysRows < 10)
                    {
                        Console.Write(" {0}|", valueForKeysRows);
                        sw.Write(" {0}|", valueForKeysRows);
                    }
                    else
                    {
                        Console.Write("{0}|", valueForKeysRows);
                        sw.Write("{0}|", valueForKeysRows);
                    }
                }
                else if (keyRow.Length >= 100 && keyRow.Length < 1000)
                {
                    if (valueForKeysRows < 10)
                    {
                        Console.Write("  {0}|", valueForKeysRows);
                        sw.Write("  {0}|", valueForKeysRows);
                    }
                    else if (valueForKeysRows >= 10 && valueForKeysRows < 100)
                    {
                        Console.Write(" {0}|", valueForKeysRows);
                        sw.Write(" {0}|", valueForKeysRows);
                    }
                    else
                    {
                        Console.Write("{0}|", valueForKeysRows);
                        sw.Write("{0}|", valueForKeysRows);
                    }
                }
                //end display of values of rows

                //filling of the massif of keys
                for (int j = 0; j < keyColumn.Length; j++)
                {
                    row = keyRow[counterKeyRowInTable] - 1;
                    column = keyColumn[j] - 1;
                    if (counterLengthString == theInputString.Length)
                        break;
                    arr[row][column] += Convert.ToString(theInputString[counterLengthString++]);
                    //end filling of the massif of keys

                    //The output of the input string in the table
                    if (keyColumn.Length < 10)
                    {
                        Console.Write("{0}|", theInputString[++counterForPrint]);
                        sw.Write("{0}|", theInputString[counterForPrint]);
                    }
                    else if (keyColumn.Length >= 10 && keyColumn.Length < 100)
                    {
                        Console.Write(" {0}|", theInputString[++counterForPrint]);
                        sw.Write(" {0}|", theInputString[counterForPrint]);
                    }
                    else if (keyColumn.Length >= 100 && keyColumn.Length < 1000)
                    {
                        Console.Write("  {0}|", theInputString[++counterForPrint]);
                        sw.Write("  {0}|", theInputString[counterForPrint]);
                    }
                    else if (keyColumn.Length >= 1000 && keyColumn.Length < 10000)
                    {
                        Console.Write("   {0}|", theInputString[++counterForPrint]);
                        sw.Write("   {0}|", theInputString[counterForPrint]);
                    }
                    //End output
                }
                Console.WriteLine();
                sw.WriteLine();
            }
            //end display corect table key-value.

        }

        //formation of blocks and display
        public bool FormingBlocks()
        {
            //sw = File.CreateText("Block.txt");
            int row = 0, column = 0;
            int k = 0;
            Console.WriteLine("\nFormed blocks:");
            sw.WriteLine("\nFormed blocks:");
            Console.WriteLine("Block number - Contents\n");
            sw.WriteLine("Block number - Contents\n");

            for (int i = 0; i < keyRow.Length; i++)
            {
                row = keyRow[i] - 1;
                for (int j = 0; j < keyColumn.Length; j++)
                {
                    column = keyColumn[j] - 1;
                    k = (theNumberOfColumns * (row + 1 - 1) + column + 1);//k =  n*(r(j) - 1) + s
                    DictionaryBlockValue[k - 1] = arrayKeys[row][column];//record in the dictionary a key - value (formation of blocks)
                }
            }

            //key-value displaying
            for (int counnt = 0; counnt < DictionaryBlockValue.Count; counnt++)
            {
                Console.WriteLine("{0} - {1}", counnt + 1, DictionaryBlockValue[counnt]);
                sw.WriteLine("{0} - {1}", counnt + 1, DictionaryBlockValue[counnt]);
            }
            //end key-value displaying
            sw.Close();
            return false;
        }

        //input of basic data
        public bool InputData()
        {
            sw = File.CreateText("Note.txt");

            Console.WriteLine("The number of blocks has to share totally on number of columns!");
            Console.Write("Enter the number of blocks: ");
            theNumberOfBlocks = Int32.Parse(Console.ReadLine());
            Console.Write("Enter the number of columns: ");
            theNumberOfColumns = Int32.Parse(Console.ReadLine());
            if (theNumberOfBlocks % theNumberOfColumns != 0)
                InputData();
            Console.WriteLine("\nString length must be greater than the number of blocks!");
            Console.Write("\nEnter the input string:");
            theInputString = Console.ReadLine();
            if (theInputString.Length <= theNumberOfBlocks)
            {
                Console.Clear();
                Console.WriteLine("Incorrect string length!");
                InputData();
            }
            MyRandom(ref keyColumn, theNumberOfColumns);
            MyRandom(ref keyRow, theNumberOfBlocks / theNumberOfColumns);
            maxSizeArray = keyColumn.Length + 1;
            lengthRow = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(theInputString.Length) / Convert.ToDouble(keyColumn.Length)));
            arrayKeys = new string[lengthRow][];
            for (int i = 0; i < lengthRow; i++)
                arrayKeys[i] = new string[maxSizeArray];
            DictionaryBlockValue = new Dictionary<int, string>();

            sw.WriteLine("the number of blocks = {0}", theNumberOfBlocks);
            sw.WriteLine("the number of columns = {0}", theNumberOfColumns);
            sw.WriteLine("the input string:{0}\n\n\n", theInputString);

            SetKeysAndPrint(ref arrayKeys);
            FormingBlocks();
            return false;
        }

        //start
        public void Run()
        {
            while (InputData()) ;
        }


        static void Main(string[] args)
        {
            Program Obj = new Program();

            try
            {
                Obj.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
