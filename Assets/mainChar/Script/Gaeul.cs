using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gaeul : MonoBehaviour, IDamagable
{
    //private float currentHealth;
    public Rigidbody2D myRigidbody;
    public float speed = 100;
    public logicManager lm;
    public bool playerIsAlive = true;
    private Camera mainCamera;
    [SerializeField] private LayerMask whatCollides;
    [SerializeField] private LayerMask collectibleLayer;

    // Start is called before the first frame update
    void Start()
    {
        if (lm == null)
        {
            lm = FindObjectOfType<logicManager>();

            if (lm == null)
            {
                Debug.LogWarning("LogicManager not found. Please assign it in the Inspector.");
            }
        }
        //currentHealth = lm.health;
        // Get reference to the main camera
        mainCamera = Camera.main;
    }
    public void Damage(float dmgAmt)
    {

        lm.decreaseHealth(dmgAmt);
        if (lm.health <= 0)
        {
            lm.gameOver();
            playerIsAlive = false;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {    
        if ( true && playerIsAlive)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            myRigidbody.MovePosition(myRigidbody.transform.position + tempVect);
        }
        ClampPositionWithinCameraBounds();
    }
    private void ClampPositionWithinCameraBounds()
    {
        // Get the world position of the camera's boundaries
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // Clamp the bird's position within the camera's vertical bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, bottomLeft.x, topRight.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bottomLeft.y, topRight.y);
        transform.position = clampedPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((whatCollides.value & (1 << collision.gameObject.layer)) > 0)
        {
            lm.decreaseHealth(1);
        }
        if ((collectibleLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            
        }
        if (lm.health <= 0)
        {
            lm.gameOver();
            playerIsAlive = false;
        }
    }

   

}

