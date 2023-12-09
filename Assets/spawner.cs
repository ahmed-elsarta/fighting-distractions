using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float heightRange = 10f;
    
    private logicManager logic;
    
    private float nextSpawnTime;

    private int rand;
    public Sprite[] enemy_sprites;


    private void Start()
    {
        logic = GameObject.FindGameObjectsWithTag("logic")[0].GetComponent<logicManager>();
    }

    private void Update()
    {
        rand = Random.Range(0, enemy_sprites.Length);
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnRate;
        // spawn 2 enemis at a random height
        float spawnHeight = Random.Range(-heightRange / 2f, heightRange / 2f);
        Vector3 firstPosition = new Vector3(transform.position.x, spawnHeight, transform.position.z);
        prefab.GetComponent<SpriteRenderer>().sprite = enemy_sprites[rand];
        Instantiate(prefab, firstPosition, Quaternion.identity);
        
        
    }

    private bool ShouldSpawn()
    {
        if(logic.isAlive == false)
        {
            return false;
        }
        return Time.time >= nextSpawnTime;
    }
}
