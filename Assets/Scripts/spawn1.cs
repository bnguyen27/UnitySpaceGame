using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn1 : MonoBehaviour


{

    [SerializeField]
    private GameObject chaser;

    public GameObject player;

    public float respawnTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnChaser();
        StartCoroutine(chaserSpawns());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnChaser(){
        
        int count = Random.Range(0,200);
        if(count < 100){
            SpawnChaser();
        }else{
             GameObject a = Instantiate(chaser) as GameObject;
             Vector2 spawnPos = player.transform.position;
             a.transform.position = spawnPos + Random.insideUnitCircle * count;

        }

        

       
    }
    

    IEnumerator chaserSpawns(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            SpawnChaser();
        }
    }

}
