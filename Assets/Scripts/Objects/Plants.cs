using UnityEngine;
using UnityEngine.Events;

public class Plants : MonoBehaviour
{
    [SerializeField] bool inRange;
    [SerializeField] elements currentState;

    public UnityEvent onFireEvent;
    public UnityEvent onWaterEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(inRange)
            {
                Activate(currentState);
                Debug.Log("activate mierda");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out SlimeController player))
        {
            inRange = true;
            currentState = player.CurrentElement;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out SlimeController player))
        {
            inRange = false;
        }
    }

    void Activate(elements state)
    {
        if(state == elements.fuego)
        {
            onFireEvent?.Invoke();
        }
        else if(state == elements.Agua)
        {
            onWaterEvent?.Invoke();
        }
    }
}
