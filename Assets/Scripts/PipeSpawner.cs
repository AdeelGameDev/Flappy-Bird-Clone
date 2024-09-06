using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPipe", 2, 2);
    }

    void SpawnPipe()
    {
        if (PipeBehaviour.speed != 0)
            Instantiate(pipe, new Vector3(12, Random.Range(-1, 2.5f), 0), transform.rotation);
    }
}
