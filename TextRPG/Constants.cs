﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    static class Constants
    {
        //Random
        public static Random rand = new Random();

        //Player Settings
        public const int playerBaseHP = 5;
        public const int playerBaseShield = 5;
        public const int playerBaseAttack = 2;
        public const char playerSprite = '@';
        public const ConsoleColor playerColor = ConsoleColor.White;

        //Enemy Settings
        public const int EnemySightRange = 5;
        public const int EnemyAmount = 50;

        //Slime Settings
        public const int slimeBaseHP = 1;
        public const int slimeBaseAttack = 1;
        public const char slimeSprite = 'O';
        public const ConsoleColor slimeColor = ConsoleColor.Cyan;
        public const string slimeName = "Slime";

        //Goblin Settings
        public const int goblinBaseHP = 5;
        public const int goblinBaseAttack = 2;
        public const char goblinSprite = 'X';
        public const ConsoleColor goblinColor = ConsoleColor.DarkGreen;
        public const string goblinName = "Goblin";

        //Kobold Settings
        public const int koboldBaseHP = 3;
        public const int koboldBaseAttack = 1;
        public const char koboldSprite = 'X';
        public const ConsoleColor koboldColor = ConsoleColor.DarkRed;
        public const string koboldName = "Kobold";

        //Boss Settings
        public const int bossBaseHP = 200;
        public const int bossBaseAttack = 3;
        public const char bossSprite = 'M';
        public const ConsoleColor bossColor = ConsoleColor.DarkRed;
        public const string bossName = "Boss";

        //Item Settings
        public const int itemAmount = 50;
        public const int bossItemAmount = 10;
        public const int healAmount = 3;
        public const int ATKBuffAmount = 1;
        public const int shieldRepairAmount = 3;
        public const char healSprite = '+';
        public const char ATKSprite = '*';
        public const char ShieldRepairSprite = '#';
        public const ConsoleColor healColor = ConsoleColor.Green;
        public const ConsoleColor ATKColor = ConsoleColor.Red;
        public const ConsoleColor ShieldRepairColor = ConsoleColor.Blue;
        public const string healName = "Health Potion";
        public const string ATKBuffName = "ATK Buff";
        public const string ShieldRepairName = "Shield Repair";

        //Map Settings
        public const int mapHeight = 9;
        public const int mapWidth = 9;
        public const int roomHeight = 7;
        public const int roomWidth = 7;
        public const int BossRoomWidth = 11;
        public const int BossRoomHeight = 11;
        public const int BossFloor = 3;
        public const int RoomsPerCategory = 3;

        //Cam Settings
        public const int camSize = 9;

        //Render Settings
        public const int rendWidth = 22;
        public const int rendHeight = 25;

        //HUD Settings
        public const int hudWidth = 21;
        public const int messageBoxHeight = 4;
        public const int statsHeight = 6;
        public const string playerStatsList = "Player|HP: X|SHLD: Y|ATK: Z|FLR: $/^";
        public const string enemyStatsList = "HP: X|ATK: Z";

        //Exit Settings
        public const char exitSprite = '¤';
        public const ConsoleColor exitColor = ConsoleColor.Yellow;

    }
}
