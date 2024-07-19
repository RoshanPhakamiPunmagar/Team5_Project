using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    private logicManager lm;
    [SerializeField] private GameObject enemyToSpawn; // The enemy object to spawn
    [SerializeField] private Transform positionSpawn;
    [SerializeField] public GameObject enemySpawnFinal;

    private bool hasSpawnedEnemy = false;
    private bool hasSpawnedFinalEnemy = false;
    void Start()
    {
        // Find and assign the logicManager script
        lm = FindObjectOfType<logicManager>();

       
    }
    // Start is called before the first frame update
    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
       
        if (!hasSpawnedEnemy && lm.trash >= 10f)
        {
            Instantiate(enemyToSpawn, positionSpawn.position, Quaternion.identity);
            hasSpawnedEnemy = true;
        }
        if (!hasSpawnedFinalEnemy && lm.trash >= 20f)
        {
            Instantiate(enemySpawnFinal, positionSpawn.position, Quaternion.identity);
            hasSpawnedFinalEnemy = true;
        } 
        
       
    }
    public void Check() {
        if (hasSpawnedEnemy == true && hasSpawnedFinalEnemy == true) {
            SceneManager.LoadSceneAsync(3);
        }
    }

}

