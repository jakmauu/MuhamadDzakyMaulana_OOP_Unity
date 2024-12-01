using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private Label pointsLabel;
    private Label healthLabel;
    private Label waveLabel;
    private Label enemiesLabel;

    private Player player;
    private CombatManager combatManager;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Mengakses elemen berdasarkan nama yang baru
        pointsLabel = root.Q<Label>("points");
        healthLabel = root.Q<Label>("health");
        waveLabel = root.Q<Label>("wave");
        enemiesLabel = root.Q<Label>("enemiesleft");

        player = Player.Instance;
        combatManager = FindObjectOfType<CombatManager>();
    }

    void Update()
    {
        if (player != null && healthLabel != null)
        {
            healthLabel.text = "Health: " + player.GetComponent<HealthComponent>().CurrentHealth;
        }
    }

    public void UpdatePoints(int points)
    {
        if (pointsLabel != null)
        {
            pointsLabel.text = "Points: " + points;
        }
    }

    public void UpdateWave(int wave)
    {
        if (waveLabel != null)
        {
            waveLabel.text = "Wave: " + wave;
        }
    }

    public void UpdateEnemiesLeft(int enemiesLeft)
    {
        if (enemiesLabel != null)
        {
            enemiesLabel.text = "Enemies Left: " + enemiesLeft;
        }
    }
}
