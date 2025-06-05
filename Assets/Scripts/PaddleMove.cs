using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    public float speed = 5f;

    public float fireRate = 1f;

    public GameObject bullet;

    public float timeFromLastShot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float speedDir = x * speed * Time.deltaTime;

        transform.position += new Vector3(speedDir, 0f, 0f);
    }
    void Shoot()
    {
        timeFromLastShot += Time.deltaTime;

        Vector3 pos = transform.position + new Vector3(0f, 1f, 0f);

        if (timeFromLastShot >= 1f/fireRate )
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Instantiate(bullet, pos, Quaternion.identity);

                timeFromLastShot = 0f;
            }
        }
    }
}
