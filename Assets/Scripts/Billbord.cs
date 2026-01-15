using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        Camera cam = Camera.main;
        if (cam != null)
            transform.LookAt(transform.position + cam.transform.forward);
    }
}