using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;




    void ChangeCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if(i == index)
            {
                cameras[i].gameObject.SetActive(true);
            }
            else
            {
                cameras[i].gameObject.SetActive(false);
            }
        }
    }
}
