using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameController game;
    [SerializeField] private PlayerController pusher;
    [SerializeField] private SpawnerController spawner;
    [SerializeField] private GameObject startPane;
    [SerializeField] private float spawnerOffset;
    public List<GameObject> spawnedBuses = new List<GameObject>();


    public bool scroll;

    private List<SpawnerController> spawners = new List<SpawnerController>();

    public void Reset()
    {
        spawners.ForEach(spawner => Destroy(spawner));
        spawners.Clear();

        for (int initialSpawnersCount = 0; initialSpawnersCount < 10; initialSpawnersCount++)
        {
            spawners.Add(Instantiate(spawner, new Vector2(spawner.gameObject.transform.position.x, spawner.gameObject.transform.position.y + (spawnerOffset * initialSpawnersCount)), Quaternion.identity));
        }
    }

    public void GenerateSpawner()
    {
        Vector2 lastSpawnerCoordinantes = spawners[spawners.Count - 1].transform.position;
        SpawnerController newSpawner = Instantiate(spawner, new Vector2(6, lastSpawnerCoordinantes.y + spawnerOffset), Quaternion.identity);
        newSpawner.difficulty = game.difficulty;

        spawners.Add(newSpawner);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pusher.canMoveForward = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pusher.canMoveForward = true;
        }
    }

    public void Scroll(float speed)
    {
        if (startPane != null)
        {
            startPane.transform.position = new Vector2(startPane.transform.position.x, startPane.transform.position.y - speed);
        }

        spawners = spawners.FindAll(spawner => spawner != null);

        spawners.ForEach(spawner =>
        {
            spawner.transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y - speed);
        });

        spawnedBuses = spawnedBuses.FindAll(spawnedBuse => spawnedBuse != null);

        spawnedBuses.ForEach(spawnedBus =>
        {
            spawnedBus.transform.position = new Vector2(spawnedBus.transform.position.x, spawnedBus.transform.position.y - speed);
        });
    }
}
