﻿namespace RogueMetalicana.BattleGround
{
    using EnemyUnit;
    using PlayerUnit;
    using System;

    public static class BattleGround
    {
        /// <summary>
        /// Generate random stats.
        /// </summary>
        private static readonly Random getRandom = new Random();

        /// <summary>
        /// This method generate random player damage, player armor, enemy damage, enemy armor.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public static void Generate(Player player, Enemy enemy)
        {
            double randomDefensePlayerPoints = getRandom.Next(0, player.Defense);
            double randomDefenseEnemyPoints = getRandom.Next(0, enemy.Defense);

            double dealingDamagePlayer = getRandom.Next(1, player.Damage);
            double dealingDamageEnemy = getRandom.Next(1, enemy.Damage);

            double playerDefense = Math.Round((randomDefensePlayerPoints / dealingDamageEnemy), 2) ;
            double enemyDefense = Math.Round((randomDefenseEnemyPoints / dealingDamagePlayer), 2);

            Battle(dealingDamagePlayer, playerDefense, dealingDamageEnemy, enemyDefense, player, enemy);
        }

        /// <summary>
        /// Represent fighting.
        /// </summary>
        /// <param name="playerDealingDamage"></param>
        /// <param name="playerDefense"></param>
        /// <param name="enemyDealingDamage"></param>
        /// <param name="enemyDefense"></param>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public static void Battle(double playerDealingDamage, double playerDefense, double enemyDealingDamage, double enemyDefense, Player player, Enemy enemy)
        {
            player.TakeDamage(enemyDealingDamage - playerDefense);
            enemy.TakeDamage(playerDealingDamage - enemyDefense);

            if (enemy.IsAlive == true)
            {
                Generate(player, enemy);
            }
        }
    }
}
