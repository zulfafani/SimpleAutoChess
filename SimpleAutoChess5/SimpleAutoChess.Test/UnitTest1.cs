using NUnit.Framework; //1
using System.Globalization;

namespace SimpleAutoChess.Test;

public class Tests
{
    private GameManager gameManager; //2

    [SetUp]
    public void Setup() //akan terpanggil pertama kali
    {
        gameManager = new GameManager(); //3
    }

    [Test] //membuat metode
	public void PlayerExists() //cari salah satu metode
    {
        //Assert.Pass();
        //variable -> arrange
        string playerName = "Zulfa";
        string expected = "Zulfa";

        // var apa = gameManager.method(parametr) -> action manggil methodnya
        bool result = gameManager.IsPlayerNameExists(playerName);

        Assert.Pass(expected, result);

        // Assert.AreEqual(1, apa) -> assert
    }

	public void AddPlayer()
	{
		string playerName = "Zulfa";
        string id = "KLN3RE";
        int point = 100;
        int gold = 2;
        int level = 1;
		Player player = new Player(playerName, id, point, gold, level);
		string expected = playerName;

		bool result = gameManager.AddPlayer(player);

		Assert.Pass(expected, result);
	}

	public void NumberOfUnits()
	{
		int level = 1;
		int expected = level;

		int result = gameManager.NumberOfUnits();

		//Assert.AreEqual(expected, result);
		Assert.That(result, Is.EqualTo(expected));
	}

	public void SpawnUnit()
	{
		string playerName = "Zulfa";
		string id = "KLN3RE";
		int point = 100;
		int gold = 2;
		int level = 1;
		Player player = new Player(playerName, id, point, gold, level);
		string expected = playerName;
		IUnitFactory factory = new TuskChampionFactory();

		bool result = gameManager.SpawnUnit(player, factory);

		Assert.Pass(expected, result);
	}

	public class TuskChampionFactory : IUnitFactory
	{
		public IUnit CreateUnit()
		{
			return new TuskChampion(
				52 + (((int)Race.Beast + (int)Class.Warior) * (int)Quality.Common), 650, (int)Quality.Common);
		}
	}
}