using UnityEngine;
using System.Collections;

public class Occupy : MonoBehaviour
{

    public bool setOnStart = true, setOnDestroy = true;
	void Start ()
    {
        if(setOnStart)
            Take();
    }

	void OnDestroy()
    {
        if(setOnDestroy)
            Release();
    }

    public void Release()
    {
        PlacementManager.ReleasePosition(transform.position);
    }

    public void Take()
    {
        PlacementManager.OccupyPosition(transform.position);
    }
}
