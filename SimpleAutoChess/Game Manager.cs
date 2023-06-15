﻿using System;
using System.Collections.Generic;
using SimpleAutoChess;

namespace SimpleAutoChess
{
	public class GameManager
	{
		private List<IPlayer> _players;
		private Dictionary<IPosition, List<IUnit>> _board;
		private Dictionary<IPlayer, List<IUnit>> _units;

		public GameManager()
		{
			_players = new List<IPlayer>();
			_board = new Dictionary<IPosition, List<IUnit>>();
			_units = new Dictionary<IPlayer, List<IUnit>>();
		}

		public void InvitePlayer(IPlayer player)
		{
			_players.Add(player);
		}

		public void AddUnitForPlayer(IPlayer player, IUnit unit)
		{
			if (!_units.ContainsKey(player))
			{
				_units[player] = new List<IUnit>();
			}
			_units[player].Add(unit);
		}

		public void AddUnitOnBoard(IPlayer player, IUnit unit, IPosition square)
		{
			if (!_board.ContainsKey(square))
				_board[square] = new List<IUnit>();

			_units[player].Add(unit);
			_board[square].Add(unit);
		}
		public void Battle()
		{


		}
        public void Battle(IUnit unit1, IUnit unit2, Action<IUnit> onBattleComplete)
        {
            while (unit1.GetHealth() > 0 && unit2.GetHealth() > 0)
            {
                unit2.ModifyHealth(-unit1.GetAttack());
                unit1.ModifyHealth(-unit2.GetAttack());
            }
            onBattleComplete?.Invoke(unit1.GetHealth() <= 0 ? unit1 : unit2);
        }
        public void OnModifyHealthHandler(int amount)
		{
			amount = (int)new Random().Next(10, 100);

        }
        public void OnModifyAttackHandler(int amount)
        {
            amount = (int)new Random().Next(10, 100);
        }
    }
}