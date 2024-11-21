using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Enemy Spawners")]
    public EnemySpawner[] enemySpawners; // Array spawner musuh

    public float timer = 0; // Timer untuk interval wave
    [SerializeField] private float waveInterval = 5f; // Interval antar wave

    public int waveNumber = 1; // Nomor wave saat ini
    public int totalEnemies = 0; // Total musuh di wave saat ini

    private void Start()
    {
        // Validasi awal
        if (enemySpawners == null || enemySpawners.Length == 0)
        {
            Debug.LogError("No enemy spawners assigned to CombatManager.");
            return;
        }

        StartWave(); // Mulai wave pertama
    }

    private void Update()
    {
        // Hitung waktu untuk wave berikutnya
        timer += Time.deltaTime;

        if (timer >= waveInterval)
        {
            timer = 0; // Reset timer
            StartWave(); // Mulai wave berikutnya
        }
    }

    private void StartWave()
    {
        Debug.Log($"Starting Wave {waveNumber}...");

        totalEnemies = 0; // Reset total enemies di wave ini

        foreach (var spawner in enemySpawners)
        {
            // Validasi spawner sebelum digunakan
            if (spawner == null)
            {
                Debug.LogWarning("One of the enemy spawners is null. Skipping...");
                continue;
            }

            // Hitung jumlah spawn berdasarkan wave number
            spawner.spawnCount = spawner.defaultSpawnCount + (waveNumber - 1) * spawner.spawnCountMultiplier;

            // Tambahkan ke total enemies
            totalEnemies += spawner.spawnCount;

            // Aktifkan spawner
            spawner.StartSpawning();
        }

        Debug.Log($"Wave {waveNumber} started with {totalEnemies} enemies.");

        waveNumber++; // Naikkan nomor wave
    }
}
