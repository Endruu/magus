using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Helpers;

namespace Sandbox
{

    class Program
    {
        static void Main(string[] args)
        {
            //string v = "\\u0151";
            //Console.WriteLine(v);

            //var ascii = Encoding.ASCII;
            //var utf8 = Encoding.UTF8;
            //var ab = ascii.GetBytes(v);
            //var ub = Encoding.Convert(ascii, utf8, ab);

            //char[] uc = new char[utf8.GetCharCount(ub, 0, ub.Length)];
            //utf8.GetChars(ub, 0, ab.Length, uc, 0);
            //var vv = new string(uc);

            //Console.WriteLine(vv);

            var gsh = new GSheet();
            var response = gsh.Get("Mérgek!A2:J22");

            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    // Print columns A and E, which correspond to indices 0 and 4.
                    Console.WriteLine("{0}, {1}, {2}", row[0], row[1], row[2]);
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }

            using (WebClient wc = new WebClient())
            {
                string url = "http://dreonar.hu/index.php?pf=api&data=character&karakter_id=37092&api_key=e710a98438afe534e068b0d7b41ef233051497016541";
                var j = Newtonsoft.Json.JsonConvert.DeserializeObject<Outer>(wc.DownloadString(url).TrimStart(new char[] { '(', '\r', '\n' }).TrimEnd(')'));
            }
        }
    }
}
