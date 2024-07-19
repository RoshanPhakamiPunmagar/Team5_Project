using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackLogic : MonoBehaviour
{
    [SerializeField] private float normalSpeed = 10f;
    [SerializeField] private float normalDamage = 1f;
    [SerializeField] private float destroyTime = 10f;
    [SerializeField] private LayerMask whatDestroysAtk;
    private Rigidbody2D rb;


    private float damage;
    public enum atkType{
        Normal,
        Special

    }
    public atkType bulletType;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = normalDamage;
        SetDestroyTime();
        SetStraightVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        
        if ((whatDestroysAtk.value & (1 << collision.gameObject.layer)) > 0) {

            IDamagable iDamagable = collision.gameObject.GetComponent<IDamagable>();
            //dmg enemy
            if (iDamagable != null) {
                iDamagable.Damage(damage);
            }
            //destroy obj
            Destroy(gameObject);
        }
    }
    private void SetStraightVelocity() {
        rb.velocity = transform.right * normalSpeed;
    }
    private void SetDestroyTime() { 
        Destroy(gameObject, destroyTime);
    }
}
