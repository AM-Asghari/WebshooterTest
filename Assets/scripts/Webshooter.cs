using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webshooter : MonoBehaviour
{
    [Header("Input")]
    public KeyCode swingkey = KeyCode.Mouse0;

    [Header("References")]
    public LineRenderer lr;
    public Transform gunTip, cam, player;
    public LayerMask whatIsGrappleable;

    [Header("Swinging")]
    private float maxSwingDistance = 100f;
    private Vector3 swingPoint;
    private SpringJoint joint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(swingkey)) StartSwing();
        if (Input.GetKeyUp(swingkey)) StopSwing();
    }

    void LateUpdate()
    {
        DrawRope();
    }

    private void StartSwing()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxSwingDistance, whatIsGrappleable))
        {
            swingPoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = swingPoint;

            float distanceFromPoint = Vector3.Distance(player.position, swingPoint);

            //distance between grapple point and grapple
            joint.maxDistance = distanceFromPoint * 0.7f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //customize values
            joint.spring = 15f;
            joint.damper = 1f;
            joint.massScale = 7f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }

    void StopSwing()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //Don't draw rope when not grappling
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, swingPoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, swingPoint);
    }

}
