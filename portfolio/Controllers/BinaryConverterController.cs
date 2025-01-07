using Microsoft.AspNetCore.Mvc;
using portfolio.Models;
using System.Diagnostics;

namespace portfolio.Controllers
{
    public class BinaryConverterController : Controller
    {
        public IActionResult Index()
        {
            var bc = new BinaryConverter();
            return View(bc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BinaryConverter obj)
        {
            var bc = new BinaryConverter();
            bc.binoutput = bintodemi(obj.bininput);
            bc.demioutput = demitobin(obj.demiinput);
            return View(bc);
        }
        public string bintodemi(long input)
        {
            string inputstring = input.ToString();
            for(int i=0;i<inputstring.Length;i++)
            {
                if (inputstring[i] != '0' && inputstring[i] != '1')
                {
                    return "Please insert only 0 or 1";
                }
            }
            string s = "";
            int a = 0;
            double sum = 0;            
            s = input.ToString();
            int n = s.Length - 1;
            for (int i = 0; i < s.Length; i++)
            {
                a = (int)s[i] - 48;
                sum += a * Math.Pow(2, n);
                n--;
            }
            return sum.ToString();
        }
        public string demitobin(int input)
        {
            List<string> str = new List<string>();
            int nummod = input;
            int thisinput = input;
            while (true)
            {
                if (thisinput != 1 && thisinput != 0)
                {
                    str.Add((nummod % 2).ToString());
                    thisinput /= 2;
                    nummod = thisinput;
                }
                else
                {
                    str.Add("1");
                    break;
                }
            }
            string strn = String.Join("", str);
            string answer = new string(strn.Reverse().ToArray());
            return answer;
        }
    }
}
