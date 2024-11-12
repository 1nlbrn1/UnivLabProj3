using System;

namespace UnivLabProj3
{
    public class Matrix
    {
        int[,] data;
        public Matrix()
        {
            data = new int[2,2] { {0, 0}, {0, 0} };
        }
        public Matrix(int[,] data)
        {
            this.data = data;
        }
        public Matrix(Matrix m)
        {
            this.data = m.data;
        }
        public Matrix(int n, int m)
        {
            data = new int[n, m];
            string inp = Console.ReadLine();
            string[] inpspl = inp.Split(' ');
            int[] inparr = new int[inpspl.Length];
            for(int i = 0;i< inpspl.Length;++i)
            {
                inparr[i] = Convert.ToInt32(inpspl[i]);
            }
            int inpi = 0;

            int ist = n - 1;
            int kst = 0;
            int icur = 0;
            int kcur = 0;
            int COUNT = 0;
            while (kst <= m - 1)
            {
                COUNT += 1;
                Console.WriteLine("cOUNT = " + COUNT + "ist = " + ist + "kst = " + kst);
                icur = ist;
                kcur = kst;
                while((icur<=n-1)&&(kcur<=m-1))
                {
                    //Console.WriteLine("cOUNT = " + COUNT);
                    data[icur, kcur] = inparr[inpi];
                    icur += 1;
                    kcur += 1;
                    inpi += 1;
                }
                if (ist > 0)
                {
                    ist -= 1;
                }
                else
                {
                    kst += 1;
                }
            }
            Console.WriteLine("inpi = " + inpi);
        }
        public new string ToString()
        {
            string str = "";
            for(int i = 0; i < data.GetLength(0); ++i)
            {
                str += "[ ";
                for (int k = 0; k< data.GetLength(1); ++k)
                {
                    str += data[k, i] + ", ";
                }
                str += "]";
                str += "\n";
            }
            return str;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Matrix m = new Matrix(3,3);
            Console.WriteLine(m.ToString());

            Matrix m1 = new Matrix();
            Console.WriteLine(m1.ToString());

        }
    }
}

