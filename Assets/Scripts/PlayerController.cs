using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float lookSpeed = 5;

    public AudioSource shotSoundEffect;
    public float secondsBetweenShots = 0.1f;
    private float lastShot;

    public int maxHealth = 100;
    public int currentHealth;

    private new Camera camera;
    private Rigidbody body;

    private float minimumX = -80;
    private float maximumX = 80;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
        currentHealth = maxHealth;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float mouseHorizontal = Input.GetAxis("Mouse X");
        float mouseVertical = Input.GetAxis("Mouse Y");

        body.MovePosition(transform.position + (transform.forward * vertical + transform.right * horizontal).normalized * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, mouseHorizontal * lookSpeed * Time.deltaTime, 0));
        rotateAboutX(-mouseVertical);

        if (Input.GetButton("Fire1") && Time.time > lastShot + secondsBetweenShots)
            shoot();
    }

    void rotateAboutX(float value)
    {
        camera.transform.Rotate(value, 0, 0);

        camera.transform.localRotation = ClampRotationAroundXAxis(camera.transform.localRotation);
    }

    void shoot()
    {
        Ray ray = camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        Debug.DrawRay(transform.position, ray.direction);

        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Enemies")))
        {
            EnemyController enemy = hit.collider.GetComponent<EnemyController>();
            enemy.takeDamage(20);
        }

        rotateAboutX(Random.Range(-0.75f, -1.25f));
        shotSoundEffect.Play();
        lastShot = Time.time;
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, minimumX, maximumX);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
