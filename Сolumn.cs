using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Сolumn
    {
        public List<string> Col { get; set; }

        public Сolumn()
        {
            Col = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                Col.Add("000");
            }
        }

        public Сolumn(string content)
        {
            Col = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                Col.Add(content);
            }
        }
    }
}
