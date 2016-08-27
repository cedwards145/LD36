using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private new Camera camera;
    private Rigidbody body;

    private float minimumX = -80;
    private float maximumX = 80;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float mouseHorizontal = Input.GetAxis("Mouse X");
        float mouseVertical = Input.GetAxis("Mouse Y");

        body.MovePosition(transform.position + (transform.forward * vertical + transform.right * horizontal).normalized * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, mouseHorizontal, 0));
        camera.transform.Rotate(-mouseVertical, 0, 0);

        camera.transform.localRotation = ClampRotationAroundXAxis(camera.transform.localRotation);
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
