using System;

namespace UnivLabProj3 {
    public static class check {

        static public bool isokinputint(string s, int left, int right) {
            bool ok;
            int a;
            ok = int.TryParse(s, out a);
            if(ok)
                if(a < left || a > right)
                    ok = false;
            return ok;
        }
        static public bool isokinputbyte(string s, byte left, byte right) {
            bool ok;
            byte a;
            ok = byte.TryParse(s, out a);
            if(ok)
                if(a < left || a > right)
                    ok = false;
            return ok;
        }

    }
    public class Matrix {
        private int[,] data;
        public Matrix() {
            data = new int[2, 2] { { 0, 0 }, { 0, 0 } };
        }
        public Matrix(int[,] data) {
            this.data = data;
        }
        public Matrix(Matrix m) {
            this.data = m.data;
        }
        public Matrix(int n, bool mode = false) {
            data = new int[n, n];
            if(mode == false) {
                if(n == 1) {
                    data[0, 0] = 1;
                    return;
                }
                int i = n / 2;
                int k;
                if(n % 2 == 0) {
                    k = n / 2 - 1;
                } else {
                    k = n / 2;
                }
                int doubleaddstep = 0;
                int count = 1;
                data[k, i] = count;
                count += 1;
                while(true) {//start
                    if(count <= n * n) {//left
                        for(int dist = 0; dist < 1 + doubleaddstep / 2; ++dist) {//left
                            i -= 1;
                            if(count > n * n) { break; }
                            data[k, i] = count;
                            count += 1;
                        }
                        doubleaddstep += 1;
                    } else { break; }
                    if(count <= n * n) {//down
                        for(int dist = 0; dist < 1 + doubleaddstep / 2; ++dist) {//down
                            k += 1;
                            if(count > n * n) { break; }
                            data[k, i] = count;
                            count += 1;
                        }
                        doubleaddstep += 1;
                    } else { break; }
                    if(count <= n * n) {//right
                        for(int dist = 0; dist < 1 + doubleaddstep / 2; ++dist) {//right
                            i += 1;
                            if(count > n * n) { break; }
                            data[k, i] = count;
                            count += 1;
                        }
                        doubleaddstep += 1;
                    } else { break; }
                    if(count <= n * n) {//up
                        for(int dist = 0; dist < 1 + doubleaddstep / 2; ++dist) {//up
                            k -= 1;
                            if(count > n * n) { break; }
                            data[k, i] = count;
                            count += 1;
                        }
                        doubleaddstep += 1;
                    } else { break; }
                }
            } else {
                var rnd = new Random();
                for(int i = 0; i < data.GetLength(0); ++i) {
                    for(int k = 0; k < data.GetLength(1); ++k) {
                        data[k, i] = rnd.Next(0, 10)-k*11;
                    }
                }
        }
        }
        public Matrix(int n, int m) {
            data = new int[m, n];
                string inp;
                string[] inpspl;
                bool isok;
                while(true) {
                    Console.Out.WriteLine("Input array.");
                    inp = Console.ReadLine();
                    inpspl = inp.Split(' ');
                    isok = true;
                    if(inpspl.Length == n * m) {
                        foreach (string s in inpspl) {
                            if(!check.isokinputint(s,int.MinValue, int.MaxValue)) {
                                Console.Out.WriteLine("Input Error.");
                                isok = false;
                            }
                        }
                        if(isok) {
                            break;
                        }
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }

                }
                int[] inparr = new int[inpspl.Length];
                for(int i = 0; i < inpspl.Length; ++i) {
                    inparr[i] = Convert.ToInt32(inpspl[i]);
                }
                int inpi = 0;
                int ist = n - 1;
                int kst = 0;
                int icur = 0;
                int kcur = 0;
                while(kst <= m - 1) {
                    icur = ist;
                    kcur = kst;
                    while((icur <= n - 1) && (kcur <= m - 1)) {
                        data[kcur, icur] = inparr[inpi];
                        icur += 1;
                        kcur += 1;
                        inpi += 1;
                    }
                    if(ist > 0) {
                        ist -= 1;
                    } else {
                        kst += 1;
                    }
                }
        }
        public new string ToString() {
            string str = "";
            for(int i = 0; i < data.GetLength(0); ++i) {
                for(int k = 0; k < data.GetLength(1); ++k) {
                    str += data[i, k] + "\t";
                }
                str += "\n";
            }
            return str;
        }
    }
    internal class Program {
        static void Main(string[] args) {
            string inp;
            string[] spl;
            Matrix m;
            while(true) {
                Console.WriteLine("Input N and M for Matrix(N, M, 0):");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length == 2) {
                    if(check.isokinputint(spl[0], 1, int.MaxValue) && check.isokinputint(spl[1], 1, int.MaxValue)) {
                        m = new Matrix(Convert.ToInt32(spl[0]), Convert.ToInt32(spl[1]));
                        Console.WriteLine(m.ToString());
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }

            Matrix m2;
            while(true) {
                Console.WriteLine("Input N for Matrix(N):");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length == 1) {
                    if(check.isokinputint(spl[0], 1, int.MaxValue)) {
                        m2 = new Matrix(Convert.ToInt32(spl[0]), true);
                        Console.WriteLine(m2.ToString());
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }
            Matrix m1;
            while(true) {
                Console.WriteLine("Input N for Matrix(N):");
                inp = Console.ReadLine();
                spl = inp.Split(' ');
                if(spl.Length ==1) {
                    if(check.isokinputint(spl[0], 1, int.MaxValue)) {
                        m1 = new Matrix(Convert.ToInt32(spl[0]));
                        Console.WriteLine(m1.ToString());
                        break;
                    } else {
                        Console.Out.WriteLine("Input Error.");
                    }
                } else {
                    Console.Out.WriteLine("Input Error.");
                }
            }

        }
    }
}
