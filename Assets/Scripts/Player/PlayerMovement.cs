using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f; // Kecepatan maksimum
    [SerializeField] private float accelerationTime = 0.5f; // Waktu untuk mencapai kecepatan maksimum
    [SerializeField] private float decelerationTime = 0.5f; // Waktu untuk berhenti
    [SerializeField] private float stopClamp = 0.1f; // Batas kecepatan untuk menghentikan

    private Vector2 moveDirection; // Arah gerakan
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Mengambil komponen Rigidbody2D
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from the PlayerMovement object.");
        }
    }

    private void FixedUpdate()
    {
        Move();
        ApplyFriction(); // Terapkan gesekan setelah gerakan
    }

    public void Move()
    {
        // Ambil input dari pemain
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(inputX, inputY).normalized; // Normalisasi arah gerakan

        // Hitung kecepatan baru
        Vector2 targetVelocity = moveDirection * maxSpeed;
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.fixedDeltaTime / accelerationTime);
    }

    private void ApplyFriction()
    {
        // Jika tidak ada input, perlambat kecepatan
        if (moveDirection.magnitude < stopClamp)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.fixedDeltaTime / decelerationTime);
        }
    }

    public bool IsMoving()
    {
        // Mengembalikan true jika ada gerakan yang signifikan
        return rb.velocity.magnitude > 0.1f;
    }
}
