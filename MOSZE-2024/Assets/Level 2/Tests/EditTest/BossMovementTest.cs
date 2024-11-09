using NUnit.Framework;
using UnityEngine;

public class BossMovementTest
{
    [Test]
    public void OnTriggerEnter2D_ChangesDirection_WhenCollidingWithBoundary()
    {
        var bossObject = new GameObject();
        var bossMovement = bossObject.AddComponent<BossMovement>();
        bossMovement.moveSpeed = 5f;

        
        var boundaryObject = new GameObject { tag = "hatar" };
        var boundaryCollider = boundaryObject.AddComponent<BoxCollider2D>();
        
        bossMovement.OnTriggerEnter2D(boundaryCollider);
        Assert.AreEqual(-5f, bossMovement.moveSpeed);


    }
}

