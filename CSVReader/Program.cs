using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    class Program
    {
        static void Main(string[] args)
        {

            //add data to datatable
            DataTable dt = new DataTable();
            dt.Columns.Add("datetime", typeof(int));
            dt.Columns.Add("user", typeof(Int64));
            dt.Columns.Add("os", typeof(int));
            dt.Columns.Add("device", typeof(int));

            StreamReader csvreader = new StreamReader(@"C:\Users\mo\Downloads\data.csv");
            string inputLine = "";

            try
            {
                while ((inputLine = csvreader.ReadLine()) != null)
                {
                    var visits = new Point();
                    string[] csvArray = inputLine.Split(new char[] { ',' });
                    visits.datetime = int.Parse(csvArray[0]);
                    visits.user = Int64.Parse(csvArray[1]);
                    visits.os = int.Parse(csvArray[2]);
                    visits.device = int.Parse(csvArray[3]);

                    dt.Rows.Add(new object[] { visits.datetime, visits.user, visits.os, visits.device });

                    //Point.viewPoints.Add(visits);
                }
            }
            catch(OutOfMemoryException ex)
            {
                Console.WriteLine(ex);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            //foreach (Point point in Point.viewPoints)
            //{
            //    dt.Rows.Add(new object[] { point.datetime, point.user, point.os, point.device });
            //}

            //System.IO.StringWriter sw;
            //string output;

            //DataTable dt = new DataTable();
            //using (StreamReader sr = new StreamReader(@"C:\Users\mo\Downloads\data.csv"))
            //{
            //    string[] headers = sr.ReadLine().Split(',');
            //    foreach (string header in headers)
            //    {
            //        dt.Columns.Add(header);
            //    }
            //    while (!sr.EndOfStream)
            //    {
            //        string[] rows = sr.ReadLine().Split(',');
            //        DataRow dr = dt.NewRow();
            //        for (int i = 0; i < headers.Length; i++)
            //        {
            //            dr[i] = rows[i];
            //        }
            //        dt.Rows.Add(dr);

            //    }

            //    foreach (DataRow row in dt.Rows)
            //    {
            //        sw = new System.IO.StringWriter();
            //        foreach (DataColumn col in dt.Columns)
            //            sw.Write(row[col].ToString() + "\t");
            //        output = sw.ToString();
            //        Console.WriteLine(output);
            //    }
            //    Console.ReadKey();



            //}

            //var source = File.ReadLines(@"C:\Users\mo\Downloads\data.csv").Select(line => line.Split(','));
            //var result = source.Any(items => items[3] == "0");
            //Console.WriteLine(result.ToString());



        }

        public class Point
        {
            public static List<Point> viewPoints = new List<Point>();
            public int datetime { get; set; }
            public Int64 user { get; set; }
            public int os { get; set; }
            public int device { get; set; }

        }
    }
}
