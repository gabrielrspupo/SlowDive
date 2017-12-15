using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager gm;
    public Transform playerPrefab;
    public Transform spawnPoint;
    public int timeToRespawn = 0;

    void Start()
    {
        if (gm == null)
            //gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
            gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
    }

    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine( gm.RespawnPlayer());
        Debug.Log("TODO: ADD Spawn Particles");
    }
    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(timeToRespawn);
        Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
        transform.Find("TimeManager").GetComponent<TimeManager>().buscarPlayer();
    }
    public void setSpawnPoint(Transform point) {
        spawnPoint = point;
    }
    /*public void KillPlayer(GameObject player)
    {
        Destroy(gameObject);
    }*/
}
