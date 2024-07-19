using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dartScript : MonoBehaviour
{
    [SerializeField] private float normalDamage = 1f;
    [SerializeField] private LayerMask whatDestroysAtk;
    [SerializeField] private float destroyTime = 10f;
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {   
        damage = normalDamage;
        rb = GetComponent<Rigidbody2D>();
        SetDestroyTime();
        SetStraightVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetStraightVelocity() {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    }
    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ((whatDestroysAtk.value & (1 << collision.gameObject.layer)) > 0)
        {
            IDamagable iDamagable = collision.gameObject.GetComponent<IDamagable>();
            //dmg enemy
            if (iDamagable != null)
            {
                iDamagable.Damage(damage);
            }
            //destroy obj
            Destroy(gameObject);
        }
    }
 
}
