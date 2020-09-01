﻿using System;

namespace PracticeAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false; // 커서 보이지 않게 하기

            const int WAIT_TICK = 1000 / 30;
            const char CIRCLE = '\u25cf';

            int lastTick = 0;
            while (true)
            {
                #region 프레임 관리
                int currentTick = System.Environment.TickCount;

                // 만약 경과한 시간이 1/30초보다 작다면
                if (currentTick - lastTick < WAIT_TICK)
                    continue;

                lastTick = currentTick;
                #endregion

                // 입력

                // 로직

                // 렌더링
                Console.SetCursorPosition(0, 0); // 커서 위치

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(CIRCLE);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}