using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    private Controller Player;
    void Start()
    {
        Controller playerController = (Controller)FindAnyObjectByType(typeof(Controller));
        if (playerController != null)
        {
            Player = playerController;
        }
        else
        {
            Debug.LogError("Player GameObject not found");
        }
    }

    void Update()
    {
        Debug.Log(Player.Health);
        healthBar.fillAmount = Player.Health / Player.MaxHealth;
    }
}
