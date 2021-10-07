using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;


    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    // windows in unity Majuscule > minuscule
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;



    void FixedUpdate()
    {

        MovePlayer(horizontalMovement);

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        // avant de jouer l'animation
        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    // le faire se retourner si on a une valeur negative en se deplacant vers la gauche
    void Flip(float _velocity)
    {
        if (_velocity < 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity > -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}