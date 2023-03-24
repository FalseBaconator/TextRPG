﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Map
    {
        private Render rend;

        private char[,] map;

        public Map(char[,] grid, Render rend)
        {
            map = grid;
            this.rend = rend;
        }

        public void DrawMap()   //sets rend arrays to map chars
        {
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int j = 0; j < map.GetLength(0); j++)
                {
                    if (map[j,i] == '▓' || map[j,i] == ',')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }else if (map[j,i] == '█')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    rend.ScreenChars[j, i] = map[j, i];
                    rend.ScreenColors[j, i] = Console.ForegroundColor;
                }
            }
        }

        public bool isFloorAt(int x, int y) //returns true if the provided coords is a floor
        {
            bool isFloor = false;
            if (map[y,x] == ',') isFloor = true;
            return isFloor;
        }


    }
}
