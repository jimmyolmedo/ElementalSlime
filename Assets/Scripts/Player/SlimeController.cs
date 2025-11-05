using System.Collections;
using UnityEngine;

public enum elements
{
    neutro,
    Agua,
    fuego,
    planta
}
public class SlimeController : MonoBehaviour
{
    //variables
    [SerializeField] elements elementState;
    [SerializeField] float speed = 10f;
    [SerializeField] SpriteRenderer sp;

    [Header("Jump")]
    [SerializeField] float jumpForce = 200f;
    [SerializeField] float fallingGravity = 15;
    [SerializeField] float jumpTime = 0.3f;
    [SerializeField] bool isJumping;

    [Header("checkGround")]
    [SerializeField] Vector2 groundCheckerBoxSize;
    [SerializeField] float groundCheckerCastDistance;
    [SerializeField] LayerMask groundLayer;

    //methods
    private void Update()
    {
        //transform.position += Vector3.right * speed * Time.deltaTime;

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


    public void SwitchElement(elements element)
    {
        elementState = element;

        switch(elementState)
        {
            case elements.neutro:
                sp.color = Color.white;
                break;

            case elements.planta:
                sp.color = Color.green;
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
