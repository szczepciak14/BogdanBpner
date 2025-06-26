using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    int life = 3;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeLife()
    {
        Color[] colors = { Color.red, Color.green, Color.blue, };

        life--;

        if (life < 0)
        {
            Destroy(gameObject);
            return;
        }
        rend.material.color = colors[life];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Alien")
        {
            Destroy(gameObject);
            
        }

        if (collision.gameObject.tag == "AlienBullet")
        {
            Destroy(collision.gameObject);
            ChangeLife();
        }
    }
}
