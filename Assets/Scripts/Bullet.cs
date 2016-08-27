using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 100;
    public float lifespan = 4;
    private float timeSpawned;

    // Use this for initialization
    void Start()
    {
        timeSpawned = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Time.time > timeSpawned + lifespan)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
