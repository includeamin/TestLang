using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace lexical_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsReturnC = false;
            bool iskolan = false;
            bool IsOpen = false;
            bool IsLocalSee = false;
            List<string> output = new List<string>();
            Stream File = new FileStream("prog.lt", FileMode.Open);
            using (StreamReader reader = new StreamReader(File))
            {
                string temp;
                while ((temp = reader.ReadLine()) != null)
                {
                    if (temp.Contains("#"))
                    {
                        string[] comment = Regex.Split(temp, @"#");
                        temp = comment[0];
                    }
                    string t = Regex.Replace(temp, @"\s{1,}", " ");
                    string t2 = Regex.Replace(t, @"\(\)", "(  )");
                    string t4 = Regex.Replace(t2, @"-", " - ");
                    string t5 = Regex.Replace(t4, @"\+", " + ");
                    string t6 = Regex.Replace(t5, @"\)", " ) ");
                    string t7 = Regex.Replace(t6, @"\(", " ( ");
                    string t8 = Regex.Replace(t7, @"==", " == ");
                    string[] result = Regex.Split(t8, @"(\()|(\s)|(\-)|(\)) |(\;)|(\{)|(\+)|(\*)|(\%)|(\/)|(\>)|(\<)|(\=\=)|(\<\=)|(\>\=)|(\|\|)|(\&\&)|(\&)|(\|})|(\,)|(#)|(\=)|(\[)|(\])|(\s)");
                    foreach (var VARIABLE in result)
                    {
                        if (VARIABLE != string.Empty )
                        {
                            output.Add(VARIABLE.Trim());
                        }
                    }
                }
            }
            //List<string> output2 = new List<string>();
            //for (int i = 0; i < output.Count; i++)
            //{
            //    if (output[i] == "(")
            //        IsOpen = true;
            //    if (output[i] == ")" )
            //    {
            //        IsOpen = false;
            //    }

            //    if (output[i].Contains("def") )
            //    {
            //        if (IsOpen)
            //        {
            //            output2.Add(output[i]);
            //        }
            //        else
            //        {
            //            Regex r = new Regex("def");
            //            string te = r.Replace(output[i], "def ", 1);
            //            string[] te2 = Regex.Split(te, @"\s");
            //            foreach (var VARIABLE in te2)
            //            {
            //                output2.Add(VARIABLE);
            //            }
                       
            //        }
                   
            //    }
            //    else
            //    {
            //        if (output[i].Contains("local"))
            //        {
                       
            //            if (IsOpen)
            //            {
            //                output2.Add(output[i]);
            //            }
            //            else
            //            {
                            
            //                Regex r = new Regex("local");
            //                string te = r.Replace(output[i], "local ", 1);

            //                string[] te2 = Regex.Split(te, @"\s");
            //                foreach (var VARIABLE in te2)
            //                {
            //                    output2.Add(VARIABLE);
            //                }

                            
            //            }                            
            //        }
            //        else
            //        {
            //            if (output[i].Contains("return") & !IsReturnC)
            //            {
            //                Regex r = new Regex("return");
            //                string te = r.Replace(output[i], "return ", 1);
            //                string[] te2 = Regex.Split(te, @"return");                          
            //                output2.Add("return");
            //                foreach (var VARIABLE in te2)
            //                {
            //                    output2.Add(VARIABLE);
                               
            //                }
            //                IsReturnC = true;
            //            }
            //            else
            //            {
            //                output2.Add(output[i]);
                            
            //            }
            //        }                   
            //    }
            //}
            foreach (var VARIABLE in output)
            {
                if (VARIABLE != "")
                {
                    Console.WriteLine(VARIABLE);
                }
            }
            Console.Read();
        }

    }
}
