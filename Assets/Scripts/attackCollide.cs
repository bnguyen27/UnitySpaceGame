using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
                scoreText.scoreValue += 100;
                Destroy(other.gameObject);
                Destroy(gameObject);

                FindObjectOfType<AudioManager>().Play("ShipDeath");
            
        }
    }
}
