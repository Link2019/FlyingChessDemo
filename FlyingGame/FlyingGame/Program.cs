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
        public static int[] PlayerPos = new int[2];//声明一个静态数组用来存储玩家A跟玩家B的坐标
        public static string[] PlayerNames = new string[2];   //存储两个玩家的姓名
        //两个玩家的标记
        public static bool[] Flags = new bool[2];//Flags[0]默认是false，Flags[0]默认是false
        static void Main(string[] args)
        {

            GameShow(); //游戏头
            #region 输入玩家姓名
            Console.WriteLine("请输入玩家A的姓名");
            PlayerNames[0] = Console.ReadLine();
            while (PlayerNames[0] == "")
            {
                Console.WriteLine("玩家A的姓名不能为空，请重新输入");
                PlayerNames[0] = Console.ReadLine();
            }

            Console.WriteLine("请输入玩家B的姓名");
            PlayerNames[1] = Console.ReadLine();
            while (PlayerNames[1] == "" || PlayerNames[1] == PlayerNames[0])
            {
                if (PlayerNames[1] == "")
                {
                    Console.WriteLine("玩家B的姓名不能为空，请重新输入");
                    PlayerNames[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家B的姓名不能和玩家A的内容相同，请重新输入");
                    PlayerNames[1] = Console.ReadLine();
                }


            }
            #endregion();   
            //玩家姓名输入OK之后，我们首先应该清屏
            Console.Clear();//清屏
            GameShow(); //游戏头

            Console.WriteLine("{0}的士兵用A表示", PlayerNames[0]);
            Console.WriteLine("{0}的士兵用B表示", PlayerNames[1]);
            InitailMap();   //初始化地图
            DrawMap();  //画地图

            //当玩家A跟玩家B没有一个人在终点的时候，两个玩家不停地去玩游戏
            while (PlayerPos[0] < 99 && PlayerPos[1] < 99)
            {
                if(Flags[0]==false)
                {
                    PlayGame(0);
                   
                }
                else
                {
                    Flags[0] = false;
                }
                if(PlayerPos[0]>=99)
                {
                    Console.WriteLine("玩家{0}无耻的赢了玩家{1}", PlayerNames[0], PlayerNames[1]);
                    Win();
                    break;
                }
                if (Flags[1] == false)
                {
                    PlayGame(1);
                }
                else
                {
                    Flags[1] = false;
                }
                if (PlayerPos[1] >= 99)
                {
                    Console.WriteLine("玩家{0}无耻的赢了玩家{1}", PlayerNames[1], PlayerNames[0]);
                    Win();
                    break;
                }
            }//while


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
            //
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("图例:幸运轮盘:◎   地雷:☆   暂停:▲   时空隧道:卐");
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
            Console.WriteLine();

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
                str = "Ａ";
            }
            else if (PlayerPos[1] == i)
            {
                str = "Ｂ";
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

        public static void PlayGame(int playNumber)
        {
            #region 掷骰子
            Random r = new Random();
            int rNumber = r.Next(1,7);
            Console.WriteLine("{0}按任意键开始掷骰子", PlayerNames[playNumber]);
            Console.ReadKey(true);  //增加参数，会不显示输入的值
            Console.WriteLine("{0}掷出了{1}", PlayerNames[playNumber],rNumber);
            PlayerPos[playNumber] += rNumber;
            ChangePos();
            Console.ReadKey(true);
            Console.WriteLine("{0}按任意键开始行动", PlayerNames[playNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}行动完了", PlayerNames[playNumber]);
            Console.ReadKey(true);
            //玩家A有可能猜到玩家B 方块 幸运轮盘 地雷 暂停 时空隧道
            if (PlayerPos[playNumber] == PlayerPos[1 - playNumber])
            {
                Console.WriteLine("玩家{0}踩到了玩家{1},玩家{2}退6格", PlayerNames[playNumber], PlayerNames[1 - playNumber], PlayerNames[1 - playNumber]);
                PlayerPos[1 - playNumber] -= 6;
                ChangePos();
                Console.ReadKey(true);
            }
            else//踩到了关卡
            {
                //玩家的坐标
                switch (Maps[PlayerPos[playNumber]]) 
                {
                    case 0:
                        Console.WriteLine("玩家{0}踩到了方块, 安全。", PlayerNames[playNumber]);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("玩家{0}踩到了幸运轮盘, 1--交换位置, 2--轰炸对方。", PlayerNames[playNumber]);
                        string input = Console.ReadLine();
                        while (true) //一听到重新，要写道循环里面
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("玩家{0}选择和玩家{1}交换位置", PlayerNames[playNumber], PlayerNames[1 - playNumber]);
                                Console.ReadKey(true);
                                int temp = PlayerPos[playNumber];
                                PlayerPos[playNumber] = PlayerPos[1 - playNumber];
                                PlayerPos[1 - playNumber] = temp;
                                Console.WriteLine("交换完成！！请按任意键继续！！！");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("玩家{0}选择轰炸玩家{1}, 玩家{2}退6格", PlayerNames[playNumber], PlayerNames[1 - playNumber], PlayerNames[1 - playNumber]);
                                Console.ReadKey(true);
                                PlayerPos[1 - playNumber] -= 6;
                                ChangePos();
                                Console.WriteLine("玩家{0}退了6格", PlayerNames[1 - playNumber]);
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("只能输入1或者2, 1--交换位置, 2--轰炸对方。");
                                input = Console.ReadLine();
                            }

                        }
                        break;
                    case 2:
                        Console.WriteLine("玩家{0}踩到了地雷, 退6格。", PlayerNames[playNumber]);
                        PlayerPos[playNumber] -= 6;
                        ChangePos();
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}踩到了暂停, 暂停一回合。", PlayerNames[playNumber]);//最复杂，放到最后做
                        Flags[playNumber] = true;
                        
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("玩家{0}踩到了时空隧道，前进10格。", PlayerNames[playNumber]);
                        PlayerPos[playNumber] += 10;
                        ChangePos();
                        Console.ReadKey(true);
                        break;
                }//switch
            }//else
            ChangePos();
            Console.Clear();
            DrawMap();
            #endregion
        }
        /// <summary>
        /// 当玩家掉出地图的时候
        /// </summary>
        public static void ChangePos()
        {
            if(PlayerPos[0]<0)
            {
                PlayerPos[0] = 0;
            }
            if(PlayerPos[0]>=99)
            {
                PlayerPos[0] = 99;
            }
            if (PlayerPos[1] < 0)
            {
                PlayerPos[1] = 0;
            }
            if (PlayerPos[1] >= 99)
            {
                PlayerPos[1] = 99;
            }
        }

        public static void Win()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                          ◆                      ");
            Console.WriteLine("                    ■                  ◆               ■        ■");
            Console.WriteLine("      ■■■■  ■  ■                ◆■         ■    ■        ■");
            Console.WriteLine("      ■    ■  ■  ■              ◆  ■         ■    ■        ■");
            Console.WriteLine("      ■    ■ ■■■■■■       ■■■■■■■   ■    ■        ■");
            Console.WriteLine("      ■■■■ ■   ■                ●■●       ■    ■        ■");
            Console.WriteLine("      ■    ■      ■               ● ■ ●      ■    ■        ■");
            Console.WriteLine("      ■    ■ ■■■■■■         ●  ■  ●     ■    ■        ■");
            Console.WriteLine("      ■■■■      ■             ●   ■   ■    ■    ■        ■");
            Console.WriteLine("      ■    ■      ■            ■    ■         ■    ■        ■");
            Console.WriteLine("      ■    ■      ■                  ■               ■        ■ ");
            Console.WriteLine("     ■     ■      ■                  ■           ●  ■          ");
            Console.WriteLine("    ■    ■■ ■■■■■■             ■              ●         ●");
            Console.ResetColor();
        }
    }
}
