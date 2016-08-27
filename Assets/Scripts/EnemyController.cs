using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    public float speed = 3;
    private PlayerController player;
    private Rigidbody body;
    public int maxHealth = 100;
    private int currentHealth;
    public float attackRange = 1.5f;
    public int damage = 10;
    private AudioSource deathSound;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        body = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        body.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
        {
            player.currentHealth -= damage;
        }
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            deathSound.Play();
            //gameObject.SetActive(false);
        }
    }
}
