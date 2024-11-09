using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest
{
    [Test]
    public void Move_SetsCorrectVelocity()
    {
        // Tesztobjektum és komponensek beállítása
        var playerObject = new GameObject();
        var rb = playerObject.AddComponent<Rigidbody2D>();
        var playerMovement = playerObject.AddComponent<Bober>();
        playerMovement.rb = rb;

        // Tesztértékek beállítása
        playerMovement.moveDirection = new Vector2(1, 0); // Jobbra irány
        playerMovement.moveSpeed = 5f;

        // Move() metódus hívása és ellenőrzés
        playerMovement.Move();
        Assert.AreEqual(new Vector2(5f, 0), rb.velocity);

        
    }
}
