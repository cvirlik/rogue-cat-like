using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Controller : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] float speed = 1f;
    private Vector2 input;
    private bool facingRight = false;

     void Update()
    {
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
        Vector3 scale = playerTransform.localScale;
        scale.x *= -1;
        playerTransform.localScale = scale;
    }
}
