using UnityEngine.UI;
using UnityEngine;

public class GameRecords : MonoBehaviour
{
    Player player;
    public Slider PlayerHealthSlider;
    public Text enemiesKilled;

    [HideInInspector]
    public int enemiesDied=0;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }


    private void Update()
    {
        enemiesKilled.text = enemiesDied.ToString();
    }
    public void playerHealth(float health)
    {
        PlayerHealthSlider.maxValue = player.startingHealth;
        PlayerHealthSlider.value -= health;
    }
}
