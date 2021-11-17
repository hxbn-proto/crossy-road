using System.Collections;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private float busOffsetTimer;
    [SerializeField] private float busSpeed;
    internal float difficulty;

    [SerializeField] GameObject bus;
    [SerializeField] private LevelController level;

    public void Start()
    {
        StartCoroutine(StartSpawning());
    }

    public IEnumerator StartSpawning()
    {
        while (true)
        {
            float initialGap = busOffsetTimer - busOffsetTimer * difficulty;
            yield return new WaitForSeconds(Random.Range(0, initialGap));

            GameObject spawned = Instantiate(bus, transform.position, Quaternion.identity);
            spawned.GetComponent<Rigidbody2D>().velocity = new Vector2(-busSpeed, 0);

            level.spawnedBuses.Add(spawned);
        }
    }
}
