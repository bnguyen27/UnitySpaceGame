using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class knobMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;

    public GameObject player;


    private Rigidbody2D rb;

    private Vector2 movement;

    public static knobMove instance;

    public bool b = false;

    void Start()
    {

        instance = this;
        gameObject.tag = "Enemy";
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

       
    }

    void FixedUpdate() {
        moveCharacter(movement);
         if(b == true){
               SceneManager.LoadScene(2);
               
            }
        }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            b = true;
            
        }
    }


}
