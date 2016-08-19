using UnityEngine;
using System.Collections;

public class RayLine : MonoBehaviour {

    public float rayRange = 100f; // Ray distance from camera.
    private Camera cam;

    void Start () {
        cam = GetComponentInParent<Camera>();
    }

    void Update () {
        Vector3 origin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.DrawRay(origin, cam.transform.forward * rayRange, Color.red);
    }
}
