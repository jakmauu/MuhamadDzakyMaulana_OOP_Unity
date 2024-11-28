using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy; // Prefab enemy yang akan di-spawn

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3; // Minimum kill untuk meningkatkan jumlah spawn
    public int totalKill = 0; // Jumlah total kill yang dilakukan pemain
    private int totalKillWave = 0; // Jumlah total kill dalam satu wave

    [SerializeField] private float spawnInterval = 3f; // Interval waktu antar spawn

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0; // Jumlah enemy yang di-spawn saat ini
    public int defaultSpawnCount = 1; // Default jumlah enemy yang di-spawn pada awal
    public int spawnCountMultiplier = 1; // Faktor pengali jumlah enemy
    public int multiplierIncreaseCount = 1; // Increment multiplier setiap peningkatan jumlah spawn

    public CombatManager combatManager; // Referensi ke CombatManager
    public bool isSpawning = false; // Apakah spawner sedang aktif

    private void Start()
    {
        StartSpawning(); // Memulai proses spawning
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating(nameof(SpawnEnemies), 0, spawnInterval); // Memulai spawn dengan interval tertentu
        }
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            if (spawnedEnemy != null)
            {
                Instantiate(spawnedEnemy, transform.position, Quaternion.identity); // Spawn enemy pada posisi spawner
            }
        }
        totalKillWave = 0; // Reset jumlah kill dalam wave
    }

    public void IncreaseSpawnCount()
    {
        if (totalKill >= minimumKillsToIncreaseSpawnCount)
        {
            spawnCount += multiplierIncreaseCount; // Tambahkan jumlah spawn
            totalKill = 0; // Reset jumlah kill
        }
    }
}
