using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingGame
{
    class Program
    {
        public static int[] Maps = new int[100];//静态字段
        static int[] PlayerPos = new int[2];
        static void Main(string[] args)
        {

            GameShow();
            InitailMap();
            DrawMap();
            Console.ReadKey();
        }

        public static void GameShow()
        {
            #region 01画游戏头
            //Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("**************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**************************");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***0505.Net基础班飞行棋***");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("**************************");
            #endregion



        }

        public static void InitailMap()
        {
            #region 02初始化地图
            //将整数数组中的数字变成控制台中显示的特殊字符串的这个过程，就是初始化地图
            //五种类型的关卡
            //我用0表示普通,显示给用户就是 □
            //....1...幸运轮盘,显示组用户就◎ 
            //....2...地雷,显示给用户就是 ☆
            //....3...暂停,显示给用户就是 ▲
            //....4...时空隧道,显示组用户就 卐
            int[] luckyturn = { 6, 23, 40, 55, 69, 83 };//幸运轮盘◎
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };//地雷☆
            int[] pause = { 9, 27, 60, 93 };//暂停▲
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };//时空隧道卐
            for (int i = 0; i < luckyturn.Length; i++)
            {
                int n = luckyturn[i];
                Maps[n] = 1;
                //Maps[luckyturn[i]] = 1;
            }
            for (int i = 0; i < landMine.Length; i++)
            {
                int n = landMine[i];
                Maps[n] = 2;
            }
            for (int i = 0; i < pause.Length; i++)
            {
                int n = pause[i];
                Maps[n] = 3;
            }
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                int n = timeTunnel[i];
                Maps[n] = 4;
            }
            #endregion
        }

        public static void DrawMap()
        {
            #region 第一横行
            //第一横行
            for (int i = 0; i < 30; i++)
            {
                //两个半角所占的位置等于一个全角所占的位置
                //如果玩家A和玩家B的坐标相同，画一个尖括号（并且都在地图上PlayerPos[0] == i）

                Console.Write(DrawStringMap(i));
                //if (PlayerPos[0] == PlayerPos[1] && PlayerPos[0] == i)
                //{
                //    Console.Write("<>");
                //}
                //else if (PlayerPos[0] == i)
                //{
                //    Console.Write("A");
                //}
                //else if (PlayerPos[1] == i)
                //{
                //    Console.Write("B");
                //}
                //switch (Maps[i])
                //{
                //    case 0:
                //        Console.ForegroundColor = ConsoleColor.DarkYellow;
                //        Console.Write("□");
                //        break;
                //    case 1:
                //        Console.ForegroundColor = ConsoleColor.DarkRed;
                //        Console.Write("◎");
                //        break;
                //    case 2:
                //        Console.ForegroundColor = ConsoleColor.DarkGreen;
                //        Console.Write("☆");
                //        break;
                //    case 3:
                //        Console.ForegroundColor = ConsoleColor.DarkBlue;
                //        Console.Write("▲");
                //        break;
                //    case 4:
                //        Console.ForegroundColor = ConsoleColor.DarkYellow;
                //        Console.Write("卐");
                //        break;
                //}
            }
            #endregion
            //画完第一横行后，应该换行
            Console.WriteLine();
            #region 第一竖行
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j <= 28; j++)
                {
                    //Console.Write("**");
                    Console.Write("  ");    //用两个空格填充
                }

                Console.Write(DrawStringMap(i));
                Console.WriteLine();

            }



            #endregion

            #region 第二横行
            for (int i = 64; i >= 35; i--)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion
            //第二横行需要换行
            Console.WriteLine();
            #region 第二竖行
            for (int i = 65; i <= 69; i++)
            {
                Console.WriteLine(DrawStringMap(i));
            }
            #endregion
            #region 第三横行
            for (int i = 70; i <= 99; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion

        }
        /// <summary>
        /// 从画地图中抽象出来的一个方法
        /// </summary>
        /// <param name="i"></param>
        public static string DrawStringMap(int i)
        {
            string str = "";
            #region 相同代码
            if (PlayerPos[0] == PlayerPos[1] && PlayerPos[0] == i)
            {
                str = "<>";
            }
            else if (PlayerPos[0] == i)
            {
                str = "A";
            }
            else if (PlayerPos[1] == i)
            {
                str = "B";
            }
            else
            {
                switch (Maps[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        str = "□";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        str = "◎";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        str = "☆";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        str = "▲";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        str = "卐";
                        break;
                }
            }
            
            return str;

            #endregion
        }


    }
}
