using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Kecepatan Asteroid bergerak
    [SerializeField] private float rotateSpeed = 100f; // Kecepatan rotasi Asteroid
    private Vector2 newPosition; // Posisi baru yang akan dituju asteroid

    private void Start()
    {
        ChangePosition(); // Inisialisasi posisi awal asteroid
    }

    private void Update()
    {
        // Menggerakkan asteroid dan membuatnya berputar
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        // Jika asteroid mendekati posisi baru, ubah posisi lagi
        if (Vector2.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition();
        }
    }

    private void ChangePosition()
    {
        // Menentukan posisi baru secara acak
        newPosition = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jika asteroid bertabrakan dengan Player
        if (other.CompareTag("Player"))
        {
            // Panggil LevelManager untuk load scene baru
            FindObjectOfType<LevelManager>().LoadScene("Main");
        }
    }
}
