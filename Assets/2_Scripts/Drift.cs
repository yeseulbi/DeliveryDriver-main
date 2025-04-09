using UnityEngine;

public class Drift : MonoBehaviour
{
    [SerializeField] float acceleration = 20f;      //전진,후진 가속도
    [SerializeField] float steering = 3f;           //조향 속도
    [SerializeField] float maxSpeed = 7f;          //최대 속도 제한
    [SerializeField] float driftFactor = 0.95f;     //낮을 수록 더 미끄러짐

    [SerializeField] ParticleSystem smokeLeft;
    [SerializeField] ParticleSystem smokeRight;
    [SerializeField] TrailRenderer leftTrail;
    [SerializeField] TrailRenderer rightTrail;

    Rigidbody2D rb;
    AudioSource audioSource;

    float defaultAcceleration;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = rb.GetComponent<AudioSource>();

        defaultAcceleration = acceleration;
    }

    void FixedUpdate()
    {
        float speed = Vector2.Dot(rb.linearVelocity, transform.up);
        if (speed < maxSpeed)
        {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * acceleration);
        }
        //float turnAmount = Input.GetAxis("Horizontal") * steering * speed * Time.fixedDeltaTime;
        float turnAmount = Input.GetAxis("Horizontal") * steering * Mathf.Clamp(speed / maxSpeed, 0.4f, 1f);
        rb.MoveRotation(rb.rotation - turnAmount);

        //Drift
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forwardVelocity + sideVelocity * driftFactor;
    }

    private void Update()
    {
        float sidewayVelocity = Vector2.Dot(rb.linearVelocity, transform.right);

        bool isdrifting = rb.linearVelocity.magnitude > 2f && Mathf.Abs(sidewayVelocity) > 1;
        if (isdrifting)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (!smokeLeft.isPlaying) smokeLeft.Play();
            if (!smokeRight.isPlaying) smokeRight.Play();
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Stop();
            if (smokeLeft.isPlaying) smokeLeft.Stop();
            if (smokeRight.isPlaying) smokeRight.Stop();
        }

        leftTrail.emitting = isdrifting;
        rightTrail.emitting = isdrifting;
    }
/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boost"))
        {
            acceleration = boostAccelerationRatio;
            Debug.Log("Boost");

            Invoke(nameof(ResetAccleration), 5f);
        }

    }

    void ResetAccleration()
    {
        acceleration = defaultAcceleration;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        acceleration = slowAccelerationRatio;

        Invoke(nameof(ResetAccleration), 3f);
    }*/
}
