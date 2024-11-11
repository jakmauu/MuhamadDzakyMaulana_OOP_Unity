using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public PlayerMovement playerMovement; // Komponen untuk menggerakkan pemain
    public Animator animator; // Komponen animator

    private Weapon equippedWeapon; // Variabel untuk menyimpan senjata yang diambil

    private void Awake()
    {
        // Singleton pattern untuk memastikan hanya ada satu instance dari Player
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Tidak menghancurkan Player saat scene berpindah
        }
        else
        {
            Destroy(gameObject); // Menghancurkan duplicate Player
        }
    }

    private void Start()
    {
        // Mengambil komponen PlayerMovement dan Animator
       playerMovement = GetComponent<PlayerMovement>();
    animator = GetComponentInChildren<Animator>();

        // Debug log untuk memastikan animator ditemukan
        if (animator == null)
        {
            Debug.LogWarning("Animator is null, please check if it is properly assigned in the Inspector.");
        }
    }

    private void FixedUpdate()
    {
        // Memanggil metode Move dari PlayerMovement
        playerMovement.Move();
    }

    private void LateUpdate()
    {
        // Set animator's IsMoving parameter berdasarkan status pergerakan
        if (animator != null) // Pastikan animator tidak null
        {
            animator.SetBool("IsMoving", playerMovement.IsMoving());
        }
        else
        {
            Debug.LogWarning("Animator is null, unable to set IsMoving.");
        }
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        equippedWeapon = newWeapon;
        Debug.Log("Senjata diambil: " + newWeapon.name);
        // Tambahkan logika lain jika diperlukan
    }

    public bool HasWeapon { get; set; } = false;

    public void PickUpWeapon()
    {
        HasWeapon = true;
    }
}
