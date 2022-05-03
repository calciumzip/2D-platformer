using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
       if (horizontalInput < -0.4752f)
            transform.localScale = new Vector3(-0.4752f, 0.4752f, 0.4752f);
        else if (horizontalInput < 0.4752f)
            transform.localScale = new Vector3(0.4752f, 0.4752f, 0.4752f);

        if (Input.GetKey(KeyCode.Space) && grounded)
            glide();

        //sets animation parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }
    private void glide()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("glide");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}