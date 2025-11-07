using System.Collections;
using UnityEngine;

public enum elements
{
    neutro,
    Agua,
    fuego,
}
public class SlimeController : Singleton<SlimeController>
{
    //variables
    [SerializeField] elements elementState;
    [SerializeField] SpriteRenderer sp;

    [Header("Movement")]
    [SerializeField] float speed = 10f;
    Vector3 move;

    [Header("Jump")]
    [SerializeField] float jumpForce = 200f;
    [SerializeField] float fallingGravity = 15;
    [SerializeField] float jumpTime = 0.3f;
    [SerializeField] bool isJumping;

    [Header("checkGround")]
    [SerializeField] Vector2 groundCheckerBoxSize;
    [SerializeField] float groundCheckerCastDistance;
    [SerializeField] LayerMask groundLayer;

    //properties
    public elements CurrentElement { get => elementState;}
    protected override bool persistent => false;

    //methods

    private void OnEnable()
    {
        InputManager.OnMove += Move;
    }

    private void OnDisable()
    {
        InputManager.OnMove -= Move;
    }

    private void Update()
    {
        transform.position += move * speed * Time.deltaTime;

        if (!isGrounded() && !isJumping)
        {
            transform.position += Vector3.down * fallingGravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Jump();
        }

        if (isJumping)
        {
            transform.position += Vector3.up * jumpForce * Time.deltaTime;
        }
    }

    void Move(Vector2 _move)
    {
        move = new Vector3(_move.x, 0);
    }

    public void SwitchElement(elements element)
    {
        elementState = element;

        switch(elementState)
        {
            case elements.neutro:
                sp.color = Color.white;
                break;

            case elements.fuego: 
                sp.color = Color.red;
                break;

            case elements.Agua:
                sp.color = Color.blue;
                break;
        }
    }

    void Jump()
    {
        StartCoroutine(JumpMov());
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, groundCheckerBoxSize, 0, -transform.up, groundCheckerCastDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator JumpMov()
    {
        float Force = jumpForce;
        float falling = fallingGravity;
        isJumping = true;

        yield return new WaitForSeconds(jumpTime);

        for (float i = 0; i  < .3f; i+=Time.deltaTime)
        {
            jumpForce = Mathf.Lerp(Force, 0, i/.3f);
            yield return null;
        }
        isJumping = false;
        jumpForce = Force;

        for (float i = 0; i < .3f; i += Time.deltaTime)
        {
            fallingGravity = Mathf.Lerp(0, falling, i/.3f);
            yield return null;
        }
        fallingGravity = falling;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * groundCheckerCastDistance, groundCheckerBoxSize);
    } 
    
}
