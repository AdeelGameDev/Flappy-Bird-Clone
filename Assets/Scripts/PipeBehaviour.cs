using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    public static float speed;

    private void Start()
    {
        speed = 5;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}
