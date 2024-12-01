using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level;
    protected Rigidbody2D rb;
    public CombatManager combatManager;
    public EnemySpawner enemySpawner;

    private void OnDestroy()
    {
        if (enemySpawner != null && combatManager != null)
        {
            enemySpawner.onDeath();
            combatManager.onDeath(this); // Pass the enemy instance
        }
    }
}
