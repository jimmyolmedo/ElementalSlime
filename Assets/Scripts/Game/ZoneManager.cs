using UnityEngine;

public class ZoneManager : Singleton<ZoneManager>
{
    public static event System.Action<int> OnChangeZone;
    int actualZone;

    protected override bool persistent => false;

    public void switchZone()
    {
        OnChangeZone.Invoke(actualZone);
        actualZone++;
    }
}
