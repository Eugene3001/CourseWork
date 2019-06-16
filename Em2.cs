using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Em2
    {
        public Сolumn Number { get; set; }

        public Сolumn Comand { get; set; }

        public Сolumn[] Registers { get; set; }

        public Сolumn Sign { get; set; }

        public Сolumn Type { get; set; }

        public int Omega { get; set; }

        public Em2()
        {
            ToZero();
        }

        private void Add(string register1, string register2)
        {
            int i1 = Convert.ToInt32(register1) - 1, i2 = Convert.ToInt32(register2) - 1;
            string[] adds = { Registers[1].Col[i1], Registers[1].Col[i2] };

            adds = OverflowResolution(adds, new int[] { i1, i2 });

            string sum = Convert.ToString(Convert.ToDouble(adds[0]) + Convert.ToDouble(adds[1]));

            Result(sum, i2);
        }

        private void Sub(string register1, string register2)
        {
            int i1 = Convert.ToInt32(register1) - 1, i2 = Convert.ToInt32(register2) - 1;
            string[] subs = { Registers[1].Col[i1], Registers[1].Col[i2] };

            subs = OverflowResolution(subs, new int[] { i1, i2 });

            string difference = Convert.ToString(Convert.ToDouble(subs[0]) - Convert.ToDouble(subs[1]));

            Result(difference, i2);
        }

        private void Mult(string register1, string register2)
        {
            int i1 = Convert.ToInt32(register1) - 1, i2 = Convert.ToInt32(register2) - 1;
            string[] mults = { Registers[1].Col[i1], Registers[1].Col[i2] };

            mults = OverflowResolution(mults, new int[] { i1, i2 });

            string mult = Convert.ToString(Convert.ToDouble(mults[0]) * Convert.ToDouble(mults[1]));

            if (mult == "0")
            {
                Type.Col[i2] = "i";
            }

            Result(mult, i2);
        }

        private void Div(string register1, string register2)
        {
            int i1 = Convert.ToInt32(register1) - 1, i2 = Convert.ToInt32(register2) - 1;
            string[] divs = { Registers[1].Col[i1], Registers[1].Col[i2] };

            divs = OverflowResolution(divs, new int[] { i1, i2 });

            if (Convert.ToDouble(divs[1]) == 0)
            {
                throw new Exception("На ноль делить низзя.");
            }

            string div = Convert.ToString(Convert.ToDouble(divs[0]) / Convert.ToDouble(divs[1]));

            Result(div, i2);
        }

        private void Mod(string register1, string register2)
        {
            int i1 = Convert.ToInt32(register1) - 1, i2 = Convert.ToInt32(register2) - 1;
            string[] mods = { Registers[1].Col[i1], Registers[1].Col[i2] };

            mods = OverflowResolution(mods, new int[] { i1, i2 });

            if (Convert.ToDouble(mods[1]) == 0)
            {
                throw new Exception("Сложно найти остаток от деления на ноль.");
            }

            string div = Convert.ToString(Convert.ToDouble(mods[0]) % Convert.ToDouble(mods[1]));

            Result(div, i2);
        }

        private void ArrayPlacement(string register1, string register2, string[] array)
        {
            int start = Convert.ToInt32(register1) - 1, n = Convert.ToInt32(register2);

            for (int i = 0; i < n; i++)
            {
                Result(array[i], start + i);
            }
        }

        private int UnconditionalTransition(string register2)
        {
            return Convert.ToInt32(register2) - 1;
        }

        private int ConditionalTransition(string register1, string register2)
        {
            int way1 = Convert.ToInt32(register1) - 1, way2 = Convert.ToInt32(register2) - 1, trueWay = 0;

            if (Omega == 0)
            {
                trueWay = way1;
            }

            else if (Omega == 2)
            {
                trueWay = way2;
            }

            return trueWay;
        }

        private void OmegaCorrection(string register1, string register2)
        {
            int i1 = Convert.ToInt32(register1) - 1, i2 = Convert.ToInt32(register2) - 1;
            string[] nums = { Registers[1].Col[i1], Registers[1].Col[i2] };

            nums = OverflowResolution(nums, new int[] { i1, i2 });

            if (Convert.ToDouble(nums[0]) > Convert.ToDouble(nums[1]))
            {
                Omega = 0;
            }

            else if (Convert.ToDouble(nums[0]) <= Convert.ToDouble(nums[1]))
            {
                Omega = 2;
            }
        }

        private void Output(string register1, string register2, List<string> output)
        {
            int whence = Convert.ToInt32(register1) - 1, how = Convert.ToInt32(register2);

            for (int i = 0; i < how; i++)
            {
                output.Add(Sign.Col[whence + i] == "-" ? "-" : "");
                output[i] += Type.Col[whence + i] == "d" ? 
                    Convert.ToString(Convert.ToInt32(Registers[0].Col[whence + i])) + ',' + Registers[1].Col[whence + i] :
                    Convert.ToString(Convert.ToInt32(Registers[0].Col[whence + i] + Registers[1].Col[whence + i]));
            }
        }

        private void ItemByIndex(string register1, string register2)
        {
            int i1 = Convert.ToInt32(register1) - 1, i2 = Convert.ToInt32(register2) - 1;

            Registers[1].Col[i2] = Registers[1].Col[Convert.ToInt32(Registers[1].Col[i1]) - 1];
            Registers[0].Col[i2] = Registers[0].Col[Convert.ToInt32(Registers[1].Col[i1]) - 1];
            Sign.Col[i2] = Sign.Col[Convert.ToInt32(Registers[1].Col[i1]) - 1];
        }

        public void Actions(string[] array, List<string> output)
        {
            int i = 0;

            while (i < 100)
            {
                bool flag = false;

                if (Comand.Col[i] == "015")
                {
                    break;
                }

                if (Comand.Col[i] == "013")
                {
                    Output(Registers[0].Col[i], Registers[1].Col[i], output);
                }

                if (Comand.Col[i] == "010")
                {
                    ArrayPlacement(Registers[0].Col[i], Registers[1].Col[i], array);
                }

                if (Comand.Col[i] == "005")
                {
                    Add(Registers[0].Col[i], Registers[1].Col[i]);
                }

                if (Comand.Col[i] == "006")
                {
                    Sub(Registers[0].Col[i], Registers[1].Col[i]);
                }

                if (Comand.Col[i] == "007")
                {
                    Mult(Registers[0].Col[i], Registers[1].Col[i]);
                }

                if (Comand.Col[i] == "008")
                {
                    Div(Registers[0].Col[i], Registers[1].Col[i]);
                }

                if (Comand.Col[i] == "016")
                {
                    Mod(Registers[0].Col[i], Registers[1].Col[i]);
                }

                if (Comand.Col[i] == "011")
                {
                    OmegaCorrection(Registers[0].Col[i], Registers[1].Col[i]);
                }

                if (Comand.Col[i] == "014")
                {
                    ItemByIndex(Registers[0].Col[i], Registers[1].Col[i]);
                }

                if (Comand.Col[i] == "009")
                {
                    i = UnconditionalTransition(Registers[1].Col[i]);
                    flag = true;
                }

                if (Comand.Col[i] == "012")
                {
                    i = ConditionalTransition(Registers[0].Col[i], Registers[1].Col[i]);
                    flag = true;
                }

                if (!flag)
                {
                    i++;
                }
            }
        }

        public void ToZero()
        {
            Number = new Сolumn();
            for (int i = 0; i < Number.Col.Count; i++)
            {
                if (i < 9)
                {
                    Number.Col[i] = "00" + (i + 1).ToString();
                }

                else if (i > 8 && i < 99)
                {
                    Number.Col[i] = "0" + (i + 1).ToString();
                }

                else
                {
                    Number.Col[i] = (i + 1).ToString();
                }
            }

            Comand = new Сolumn();

            Registers = new Сolumn[2];
            for (int i = 0; i < 2; i++)
            {
                Registers[i] = new Сolumn();
            }

            Sign = new Сolumn("+");

            Type = new Сolumn("i");

            Omega = -1;
        }

        private string Trim(string correct)
        {
            if (correct.Length == 1)
            {
                correct = correct.Insert(0, "00");
            }

            else if (correct.Length == 2)
            {
                correct = correct.Insert(0, "0");
            }

            return correct;
        }

        private string ReverseTrim(string correct)
        {
            if (correct.Length == 1)
            {
                correct = correct.Insert(correct.Length, "00");
            }

            else if (correct.Length == 2)
            {
                correct = correct.Insert(correct.Length, "0");
            }

            return correct;
        }

        private string[] OverflowResolution(string[] operands, int[] indexes)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                if (Type.Col[indexes[i]] == "d")
                {
                    operands[i] = operands[i].Insert(0, Convert.ToString(Convert.ToInt32(Registers[0].Col[indexes[i]])) + ".");
                }

                else if (Type.Col[indexes[i]] == "i" && Registers[0].Col[indexes[i]] != "000")
                {
                    operands[i] = operands[i].Insert(0, Registers[0].Col[indexes[i]]);
                }

                if (Sign.Col[indexes[i]] == "-")
                {
                    operands[i] = operands[i].Insert(0, "-");
                }
            }

            return operands;
        }

        private void Result(string result, int i)
        {
            if (result[0] == '-')
            {
                Sign.Col[i] = "-";
                result = result.Substring(1);
            }

            else
            {
                Sign.Col[i] = "+";
            }

            if (result.Contains("."))
            {
                if (result.Substring(result.IndexOf('.') + 1).Length > 3)
                {
                    result = result.Substring(0, result.IndexOf('.') + 4);
                }

                Type.Col[i] = "d";
                Registers[0].Col[i] = Trim(result.Substring(0, result.IndexOf('.')));
                Registers[1].Col[i] = ReverseTrim(result.Substring(result.IndexOf('.') + 1));
            }

            else
            {
                if (result.Length < 4)
                {
                    result = Trim(result);

                    Registers[1].Col[i] = result;
                }

                else if (result.Length > 3 && result.Length < 7)
                {
                    Registers[1].Col[i] = result.Substring(result.Length - 3);

                    result = Trim(result.Substring(0, result.Length - 3));

                    Registers[0].Col[i] = result;
                }

                else
                {
                    throw new Exception("Register overflow.");
                }
            }
        }

        public override string ToString()
        {
            string field = "";

            for (int i = 0; i < 100; i++)
            {
                field += Number.Col[i] + ' ' + Comand.Col[i] + ' ' + Registers[0].Col[i] + ' ' + Registers[1].Col[i];
                field += Sign.Col[i] == "+" ? "" : " -";
                field += Type.Col[i] == "i" ? "\n" : " d\n";
            }

            return field;
        }
    }
}
