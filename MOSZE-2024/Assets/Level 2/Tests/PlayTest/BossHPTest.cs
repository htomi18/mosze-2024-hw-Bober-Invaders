using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class BossHPTest
{
    private GameObject bossObject;
    private GameObject victoryUI;
    private BossHP bossScript;
    private Slider healthBar;

    [SetUp]
    public void Setup()
    {
        bossObject = new GameObject();
        victoryUI = new GameObject();
        victoryUI.SetActive(false);  // Kezdetben inaktív

        bossScript = bossObject.AddComponent<BossHP>();
        bossScript.victory = victoryUI;

        healthBar = bossObject.AddComponent<Slider>();
        bossScript.healthBar = healthBar;
        bossScript.health = 500;
        bossScript.Start();
    }

    [Test]
    public void TakeDamage_LowersHealthAndShowsVictory_WhenHealthIsZero()
    {
        // Sebzés
        bossScript.TakeDamage(500);

        // Ellenőrzés
        Assert.AreEqual(0, bossScript.healthBar.value);  // Élet 0
        Assert.IsTrue(victoryUI.activeSelf);  // Győzelem UI megjelenik
    }

}
