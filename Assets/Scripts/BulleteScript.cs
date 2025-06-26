using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleteScript : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void Move()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.gameObject.tag == "Alien" || collision.gameObject.tag == "AlienBullet")
        {
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
}
