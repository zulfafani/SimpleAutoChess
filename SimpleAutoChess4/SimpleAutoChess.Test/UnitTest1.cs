using NUnit.Framework; //1
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
	public void Test1() //cari salah satu metode
    {
        //Assert.Pass();
        //variable -> arrange
        string playerName = "Zulfa";
        IPlayer player = new Player();
        player.SetName(playerName);
        string expected = "Zulfa";

        // var apa = gameManager.method(parametr) -> action manggil methodnya
        bool result = gameManager.PlayerExists(player);

        Assert.Pass(expected, result);

        // Assert.AreEqual(1, apa) -> assert
    }
}