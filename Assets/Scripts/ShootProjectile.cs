using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject mProjectile;
    public Vector2 mProjectileSpeed = new Vector2 (10f, 10f);

    public bool cooldown = false;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        print("hi");
        if (Input.GetMouseButton(1)){
            if(cooldown == false){
                Shoot ();
                Invoke("ResetCooldown",0.5f);
                cooldown = true;
            }
            
        }
    }

     void ResetCooldown(){
     cooldown = false;
    }

    void Shoot(){
        scoreText.scoreValue += 100;
        GameObject clone = (GameObject)Instantiate (mProjectile, transform.position, Quaternion.identity);
    }

private void OnTriggerEnter2D(Collider2D collision) {
        scoreText.scoreValue += 100;
        print("hi");
        Destroy(collision.gameObject);
            
        
    }

}