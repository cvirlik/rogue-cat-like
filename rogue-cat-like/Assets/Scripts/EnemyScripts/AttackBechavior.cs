using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Controller Player;
    [SerializeField] float damage = 10f;
    [SerializeField] float damageTimeout = 1f;
    private bool canTakeDamage = true;

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
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            if (canTakeDamage)
            {
                Player.TakeDamage(damage);
                StartCoroutine(DamageTimeout());
            }
        }
    }

    private IEnumerator DamageTimeout()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }
}
