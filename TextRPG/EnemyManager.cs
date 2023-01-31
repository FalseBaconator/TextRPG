﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class EnemyManager
    {
        public List<Enemy> Enemies = new List<Enemy>();
        public Map map;
        public Player player;
        public Random random = new Random();
        public bool toMove;

        public EnemyManager(Map map)
        {
            this.map = map;
        }

        public void GenerateEnemies(int count)
        {
            for (int i = 3; i < 35; i += 7)
            {
                for (int j = 3; j < 35; j += 7)
                {
                    if(i != player.x || j != player.y)
                    {
                        int chance = random.Next(10);
                        switch (chance)
                        {
                            case 0:
                            case 1:
                                Enemies.Add(new Slime(i, j, map, player, this));
                                break;
                            case 2:
                            case 3:
                                Enemies.Add(new Goblin(i, j, map, player, this));
                                break;
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                                break;
                        }
                    }
                }
            }
        }

        public void MoveEnemies()
        {
            if (toMove)
            {
                foreach(Enemy enemy in Enemies)
                {
                    enemy.Move();
                }
            }
            toMove = !toMove;
        }

        public Enemy EnemyCheck(int x, int y)
        {
            Enemy foundEnemy = null;
            foreach(Enemy enemy in Enemies)
            {
                if(enemy.x == x && enemy.y == y)
                {
                    foundEnemy = enemy;
                }
            }
            return foundEnemy;
        }

        public void RemoveEnemy(Enemy enemy)
        {
            if (Enemies.Contains(enemy))
            {
                Enemies.Remove(enemy);
            }
        }

    }
}
