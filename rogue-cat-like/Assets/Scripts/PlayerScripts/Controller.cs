using UnityEngine;

[RequireComponent(typeof(Transform)), RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(SpriteRenderer))]
public class Controller : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    private Vector3 originalPosition;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 1f;
    [SerializeField] float health = 100f;
    [SerializeField] float maxHealth = 100f;
    private Vector2 input;
    private bool facingRight = false;

    public float Health
    {
        get => health;
    }

    public float MaxHealth
    {
        get => maxHealth;
    }

    void Start(){
        originalPosition = playerTransform.position;
    }

    void Update()
    {
        if(health == 0) Respawn();
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input.x > 0 && !facingRight)
            Flip();
        else if (input.x < 0 && facingRight)
            Flip();
    }

    void FixedUpdate()
    {
        if(input != Vector2.zero)
        {
            Vector2 target = playerRigidbody.position + speed * Time.fixedDeltaTime * input.normalized;
            playerRigidbody.MovePosition(target);
            playerTransform.position += speed * Time.deltaTime * (Vector3)input.normalized;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0)
        {
            health = 0;
        }
    }

    public void Heal(float amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void Respawn(){
        transform.position = originalPosition;
        health = maxHealth;
    }
}
