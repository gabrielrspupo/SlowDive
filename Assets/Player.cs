using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //Make sure that we can see class in Inspector
    [System.Serializable]
    public class PlayerStats
    {
        public float Health = 100f;

    }

    PlayerStats playerStats = new PlayerStats();
    public float fallBoundary = -15;

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if(playerStats.Health <= 0)
        {
            Debug.Log("Kill Player");
            GameManager.KillPlayer(this);
        }
    }

    void Update()
    {
        if (transform.position.y <= fallBoundary)
        {
            DamagePlayer(int.MaxValue);
        } 
    }
}
