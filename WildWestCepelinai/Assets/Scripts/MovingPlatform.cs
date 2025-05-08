using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed = 1f;

    private Vector3 lastPosition;
    public Vector3 Velocity { get; private set; }

    void Start()
    {
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (tim.remainingTime <= 0)
        {
            Velocity = Vector3.zero;
            return;
        }

        float t = Mathf.PingPong(Time.time * speed, 1f); // loop nuo 0 iki 1 ir atgal
        Vector3 newPos = Vector3.Lerp(posA.position, posB.position, t);

        Velocity = (newPos - lastPosition) / Time.fixedDeltaTime;
        lastPosition = newPos;

        transform.position = newPos;
    }
}
