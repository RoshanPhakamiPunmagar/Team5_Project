using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn; // The object that the user needs to collect
    [SerializeField] private float spawnInterval = 5f; // Interval between spawns in seconds
    [SerializeField] private LayerMask whatDestroys;
    logicManager lm;
    private float timer;
    private GameObject lastSpawnedObject;
    void Start()
    {
        // Find and assign the logicManager script
        lm = FindObjectOfType<logicManager>();

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        // Get the camera's world bounds
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found.");
            return;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenRatio;

        // Calculate the random position within the bounds
        float minX = mainCamera.transform.position.x - (cameraWidth / 2);
        float maxX = mainCamera.transform.position.x + (cameraWidth / 2);
        float minY = mainCamera.transform.position.y - (cameraHeight / 2);
        float maxY = mainCamera.transform.position.y + (cameraHeight / 2);

        Vector2 randomPosition = new Vector2(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY)
        );

        // Destroy the last spawned object if it exists
        if (lastSpawnedObject != null)
        {
            Destroy(lastSpawnedObject);
        }

        // Instantiate the object at the random position and keep a reference to it
        lastSpawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("ON");
        if ((whatDestroys.value & (1 << collision.gameObject.layer)) > 0)
        {
            lm.increaseScore(1);
            Destroy(gameObject);
        }
    }
}
