using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; // Objek weapon yang akan di-assign dari Inspector
    private Weapon weapon; // Objek weapon yang akan diberikan ke Player

    private void Awake()
    {
        // Inisialisasi weapon dari weaponHolder
        if (weaponHolder != null)
        {
            weapon = weaponHolder;
        }
        else
        {
            Debug.LogWarning("Weapon holder tidak diisi pada " + gameObject.name);
        }
    }

    private void Start()
    {
        if (weapon != null)
        {
            // Nonaktifkan tampilan weapon sampai diambil oleh Player
            TurnVisual(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jika objek yang terkena collider memiliki tag "Player"
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                // Berikan weapon ke Player
                player.EquipWeapon(weapon);

                // Aktifkan tampilan weapon setelah diambil
                TurnVisual(true);

                // Debug log untuk memastikan pickup berhasil
                Debug.Log("Player telah mengambil senjata: " + weapon.name);

                // Jika ingin, hancurkan pickup setelah diambil
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Komponen Player tidak ditemukan pada objek dengan tag Player");
            }
        }
    }

    private void TurnVisual(bool isVisible)
    {
        if (weapon != null)
        {
            weapon.gameObject.SetActive(isVisible);
        }
        else
        {
            Debug.LogWarning("Weapon belum diinisialisasi untuk " + gameObject.name);
        }
    }
}
