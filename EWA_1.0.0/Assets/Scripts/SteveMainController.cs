using UnityEngine;
using System.Collections;

public class SteveMainController : MonoBehaviour {

    Vector3 pos;

    GameObject head, torso, rArm, lArm, rLeg, lLeg;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;

        head = GameObject.Find("Head");
        torso = GameObject.Find("Torso");
        rArm = GameObject.Find("Right Arm");
        lArm = GameObject.Find("Left Arm");
        rLeg = GameObject.Find("Right Leg");
        lLeg = GameObject.Find("Left Leg");
    }

    // Update is called once per frame
    void Update()
    {
       
        // if none of the pieces exist any more
        if (!head.activeSelf &&
                 !torso.activeSelf &&
                 !rArm.activeSelf &&
                 !lArm.activeSelf &&
                 !rLeg.activeSelf &&
                 !lLeg.activeSelf)
        {
            // remove this instance of steve as well
            gameObject.SetActive(false);
        }
        // otherwise keep moving steve forward
        else
        {
            pos.x--;
            transform.position = pos;
        }
    }
}