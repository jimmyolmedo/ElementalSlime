using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;
    [SerializeField] Transform[] Positions;


    private void OnEnable()
    {
        ZoneManager.OnChangeZone += ChangeCamera;
    }

    private void OnDisable()
    {
        ZoneManager.OnChangeZone -= ChangeCamera;
    }


    void ChangeCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if(i == index)
            {
                cameras[i].gameObject.SetActive(true);
                SlimeController.instance.transform.position = Positions[i].transform.position;
            }
            else
            {
                cameras[i].gameObject.SetActive(false);
            }
        }
    }
}
