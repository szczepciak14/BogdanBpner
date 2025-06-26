using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLeaderScript : MonoBehaviour
{
    public GameObject alienBullet;
    public float speed = 5.0f;
    public float borderValue = 8f;

    private Vector3 target;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3 (borderValue, transform.position.y, transform.position.z);
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        var step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if(Vector3.Distance(transform.position, target) < 0.001f)
        {
            target = new Vector3(target.x * -1, transform.position.y, transform.position.z);
        }
    }

    void Shoot()
    {
        Vector3 pos = transform.position - new Vector3(0, 1, 0);

        Instantiate(alienBullet, pos, Quaternion.identity);
    }

    void ToggleVisible()
    {
        rend.enabled = !rend.enabled;
    }

    public void StartLeader()
    {
        Invoke("ToggleVisible", 6);
        InvokeRepeating("Shoot", 6, 2);
    }

    public void StopLeader()
    {
        CancelInvoke("Shoot");
        ToggleVisible();
    }
}
