using UnityEngine;

public class spwan : MonoBehaviour
{
    public GameObject stone;
    public float spwanRate = 2;
    public float timer = 0;
    public float heightOffset = 10;
    // Start is called before the first frame update
    void Start()
    {
        spwanStone();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spwanRate)
        {
            timer += Time.deltaTime;
        }
        else {
            spwanStone();
            timer = 0;
        }
        
        
    }
    void spwanStone() {
        float highestPoint = transform.position.y -heightOffset;
        float lowestPoint = transform.position.y + heightOffset;
        Instantiate(stone,new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

    }

