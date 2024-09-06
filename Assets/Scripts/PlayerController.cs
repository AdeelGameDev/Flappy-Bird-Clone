using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float force;
    private bool spacePressed = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.AddForce(Vector2.up * force);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            spacePressed = true;
        }


    }

    private void FixedUpdate()
    {
        if (spacePressed)
        {
            playerRb.velocity = new Vector2(0, 0);
            playerRb.AddForce(Vector2.up * force, ForceMode2D.Force);
            spacePressed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "ScoreBound")
        {
            GameObject.FindObjectOfType<GameManager>().Score();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            GameObject.FindObjectOfType<GameManager>().GameOver();

        }
    }




}
