using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] GameController game;
    [SerializeField] LevelController level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            level.GenerateSpawner();

            game.PlayerSucceed();
        }

        Destroy(collision.gameObject);
    }
}
