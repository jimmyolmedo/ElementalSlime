using UnityEngine;

public class LevelPooler : MonoBehaviour
{
    [SerializeField] GameObject[] grounds;
    [SerializeField] int separateValue;
    [SerializeField] Transform poolPosition;

    void Start()
    {
        for (int i = 0; i < 5f; i++)
        {
            int x = Random.Range(0, grounds.Length);
            Instantiate(grounds[x], poolPosition.position, Quaternion.identity);
            poolPosition.position += Vector3.right * separateValue;

        }
    }
    
    
}
