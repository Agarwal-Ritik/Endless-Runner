using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTilePrefab;
    Vector3 nextspawnPoint;

    //function for spawning ground
    public void spawnTile(){
        GameObject tempGround = Instantiate(groundTilePrefab, nextspawnPoint, Quaternion.identity);
        nextspawnPoint = tempGround.transform.GetChild(1).transform.position;  //to tell where to spawn in the scene
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnTile();
        }
    }
}
