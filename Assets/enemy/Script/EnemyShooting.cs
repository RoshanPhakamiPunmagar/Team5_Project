using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject dart;
    [SerializeField] private Transform dartPos;
    

    private float timer;
    // Start is called before the first frame update
   
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }
    void shoot()
    {
        Instantiate(dart, dartPos.position, Quaternion.identity);
    }
   
}
