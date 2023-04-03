﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class EnemyManager
    {
        private List<Enemy> Enemies = new List<Enemy>();
        private Enemy[,] EnemyMap = new Enemy[Constants.mapHeight * Constants.roomHeight, Constants.mapWidth * Constants.roomWidth];
        private Map map;
        private Random random = Constants.rand;
        private bool toMove;
        private Render rend;
        private ItemManager itemManager;
        private Enemy lastAttacked;
        GameManager manager;
        Exit exit;

        public EnemyManager(Map map, Render rend, ItemManager itemManager, GameManager manager, Exit exit)
        {
            this.map = map;
            this.rend = rend;
            this.itemManager = itemManager;
            this.manager = manager;
            this.exit = exit;
        }

        public void GenerateEnemies(Player player)
        {
            Position tempPos;
            Enemies.Clear();
            int placedEnemies = 0;
            while(placedEnemies < Constants.EnemyAmount)
            {
                //Console.WriteLine("Attempt(Enemy)");
                tempPos = new Position(random.Next(Constants.mapWidth * Constants.roomWidth), random.Next(Constants.mapHeight * Constants.roomHeight));
                if((Math.Abs(player.GetPos().x - tempPos.x) > 5 || Math.Abs(player.GetPos().y - tempPos.y) > 5) && map.isFloorAt(tempPos) && itemManager.ItemAt(tempPos) == null && exit.isExitAt(tempPos, false) == false && EnemyAt(tempPos, false) == null)
                {
                    switch (random.Next(5))
                    {
                        case 0:
                        case 1:
                            Enemies.Add(new Slime(tempPos, map, player, this, itemManager, rend, manager));
                            placedEnemies++;
                            break;
                        case 2:
                        case 3:
                            Enemies.Add(new Kobold(tempPos, map, player, this, itemManager, rend, manager));
                            placedEnemies++;
                            break;
                        case 4:
                            Enemies.Add(new Goblin(tempPos, map, player, this, itemManager, rend, manager));
                            placedEnemies++;
                            break;
                    }
                }
            }

            foreach (Enemy enemy in Enemies)
            {
                EnemyMap[enemy.GetPos().x, enemy.GetPos().y] = enemy;
            }

        }

        public void GenerateBoss(Player player)
        {
            Position tempPos;
            Enemies.Clear();
            bool placedBoss = false;
            while (placedBoss == false)
            {
                //Console.WriteLine("Attempt(Enemy)");\
                tempPos = new Position(random.Next(Constants.BossRoomWidth), random.Next(Constants.BossRoomHeight));
                if ((Math.Abs(player.GetPos().x - tempPos.x) > 2 || Math.Abs(player.GetPos().y - tempPos.y) > 2) && map.isFloorAt(tempPos) && itemManager.ItemAt(tempPos) == null && exit.isExitAt(tempPos, false) == false && EnemyAt(tempPos, false) == null)
                {
                    Enemies.Add(new Boss(tempPos, map, player, this, itemManager, rend, manager));
                    placedBoss = true;
                }
            }
        }

        public void UpdateEnemies() //Move each enemy on every other turn
        {
            if (toMove)
            {
                foreach(Enemy enemy in Enemies)
                {
                    EnemyMap[enemy.GetPos().x, enemy.GetPos().y] = null;
                    enemy.Update();
                    EnemyMap[enemy.GetPos().x, enemy.GetPos().y] = enemy;
                }
            }
            toMove = !toMove;
        }

        public Enemy EnemyAt(Position pos, bool isAttack)    //Returns the enemy at the provided coords. Saves lastAttacked enemy if attacking
        {
            Enemy foundEnemy = EnemyMap[pos.x, pos.y];
            if (isAttack && foundEnemy != null) lastAttacked = foundEnemy;
            return foundEnemy;
        }

        public void DrawEnemies()   //Save enemies to rend arrays
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw();
            }
        }

        public void RemoveEnemy(Enemy enemy)    //Removes enemy from enemies array
        {
            if (Enemies.Contains(enemy))
            {
                Enemies.Remove(enemy);
                EnemyMap[enemy.GetPos().x, enemy.GetPos().y] = null;
            }
        }

        public int GetEnemyCount()
        {
            return Enemies.Count();
        }

        public Enemy GetLastAttacked()
        {
            return lastAttacked;
        }

    }
}
