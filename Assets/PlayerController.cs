using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameController game;
    [SerializeField] private LevelController level;
    [SerializeField] private float speed;
    public bool canMoveForward;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMoveForward = true;
    }

    // Update is called once per frame
    void Update()
    {
        float speedCoef = Input.GetKey(KeyCode.LeftShift) ? 0.03f : 0.01f;
        float h = Input.GetAxis("Horizontal") * speedCoef * speed;
        float v = 0;

        if (!canMoveForward && (Input.GetAxis("Vertical") > 0))
        {
            level.Scroll(Input.GetAxis("Vertical") * speedCoef * speed);
        }
        else
        {
            v = Input.GetAxis("Vertical") * speedCoef * speed;
        }

        rb.position = new Vector2(Math.Min(4.53f, Math.Max(-4.53f, rb.position.x + h)), Math.Min(4.53f, Math.Max(-4.53f, rb.position.y + v)));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            game.Reset();
        }
    }
}
