using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Render
    {

        public char[,] ScreenChars = new char[Constants.mapHeight * Constants.roomHeight, Constants.mapWidth * Constants.roomWidth];

        public ConsoleColor[,] ScreenColors = new ConsoleColor[Constants.mapHeight * Constants.roomHeight, Constants.mapWidth * Constants.roomWidth];

        public ConsoleColor[,] BackgroundColors = new ConsoleColor[Constants.mapHeight * Constants.roomHeight, Constants.mapWidth * Constants.roomWidth];

        private Camera cam;

        private char[,] borderChars = new char[,]
        {
            {'╔','═','═','═','═','═','═','═','╗'},
            {'║',' ',' ',' ',' ',' ',' ',' ','║'},
            {'║',' ',' ',' ',' ',' ',' ',' ','║'},
            {'║',' ',' ',' ',' ',' ',' ',' ','║'},
            {'║',' ',' ',' ',' ',' ',' ',' ','║'},
            {'║',' ',' ',' ',' ',' ',' ',' ','║'},
            {'║',' ',' ',' ',' ',' ',' ',' ','║'},
            {'║',' ',' ',' ',' ',' ',' ',' ','║'},
            {'╚','═','═','═','═','═','═','═','╝'}
        };

        private char[,] printToScreenChars = new char[Constants.camSize + 2, Constants.mapWidth + Constants.camSize + 2];
        private ConsoleColor[,] printToScreenColors = new ConsoleColor[Constants.camSize + 2, Constants.mapWidth + Constants.camSize + 2];
        private ConsoleColor[,] printToScreenBackgroundColors = new ConsoleColor[Constants.camSize + 2, Constants.mapWidth + Constants.camSize + 2];

        private MiniMap mini;


        public void setCam(Camera camera)
        {
            cam = camera;
        }

        public void setMiniMap(MiniMap miniMap)
        {
            mini = miniMap;
        }

        public void DrawToScreen()  //Draws the map according to the arrays
        {
            Console.CursorVisible = false;
            int x = cam.x - (Constants.camSize / 2);
            int y = cam.y - (Constants.camSize / 2);


            //Add Border
            for (int i = 0; i < borderChars.GetLength(0); i++)
            {
                for (int j = 0; j < borderChars.GetLength(1); j++)
                {
                    printToScreenChars[i,j] = borderChars[i,j];
                    printToScreenColors[i, j] = ConsoleColor.White;
                    printToScreenBackgroundColors[i, j] = ConsoleColor.Black;
                }
            }

            //Add Camera
            for (int i = 0; i < Constants.camSize; i++)
            {
                for (int j = 0; j < Constants.camSize; j++)
                {

                    printToScreenChars[i + 1, j + 1] = ScreenChars[i+y,j+x];
                    printToScreenColors[i + 1, j + 1] = ScreenColors[i + y, j + x];
                    printToScreenBackgroundColors[i + 1, j + 1] = BackgroundColors[i + y, j + x];

                }
            }

            //Add MiniMap
            for (int i = 0; i < Constants.mapHeight; i++)
            {
                for (int j = 0; j < Constants.mapWidth; j++)
                {
                    printToScreenChars[i, j + Constants.camSize + 2] = mini.revealedMap[i, j];
                    printToScreenColors[i, j + Constants.camSize + 2] = mini.foregroundColors[i, j];
                    printToScreenBackgroundColors[i, j + Constants.camSize + 2] = mini.backgroundColors[i, j];
                }
            }

            //Print to Screen
            for (int i = 0; i < printToScreenChars.GetLength(0); i++)
            {
                for (int j = 0; j < printToScreenChars.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.BackgroundColor = printToScreenBackgroundColors[i, j];
                    Console.ForegroundColor = printToScreenColors[i, j];
                    Console.Write(printToScreenChars[i, j]);

                }
            }

        }

        public void ResetBackgrounds()                                      //
        {                                                                   //
            for (int i = 0; i < BackgroundColors.GetLength(1); i++)         //
            {                                                               //
                for (int j = 0; j < BackgroundColors.GetLength(0); j++)     //
                {                                                           //  Resets the background color of every char to black
                    BackgroundColors[j, i] = ConsoleColor.Black;            //
                }                                                           //
            }                                                               //
        }                                                                   //

    }
}
