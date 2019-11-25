using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class NewHand : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;

    private SteamVR_Behaviour_Pose m_Pose = null;
    private FixedJoint m_Joint = null;

    private NewInteractable m_CurrentInteractable = null;
    private List<NewInteractable> m_ContactInteractables = new List<NewInteractable>();

    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }

    private void Update()
    {
        //Down
        if (m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + "Trigger Down");
            PickUp();
        }
        //UP
        if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            print(m_Pose.inputSource + "Trigger Up");
            PickUp();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactables"))
            return;
        m_ContactInteractables.Add(other.gameObject.GetComponent<NewInteractable>());
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactables"))
            return;
        m_ContactInteractables.Remove(other.gameObject.GetComponent<NewInteractable>());
    }
    public void PickUp()
    {
        // get nearest
        m_CurrentInteractable = GetNearestInteractable();

        // null check
        if (!m_CurrentInteractable)
            return;

        // already Held
        if (m_CurrentInteractable.m_ActiveHand)
            m_CurrentInteractable.m_ActiveHand.Drop();

        // position 
        m_CurrentInteractable.transform.position = transform.position;

        // attach
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        // set active Hand
        m_CurrentInteractable.m_ActiveHand = this;
    }
    public void Drop()
    {
        // null Check
        if (m_CurrentInteractable)
            return;

        // apply Velocity
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = m_Pose.GetVelocity();
        targetBody.angularVelocity = m_Pose.GetAngularVelocity();

        // Detach
        m_Joint.connectedBody = null;

        // clear
        m_CurrentInteractable.m_ActiveHand = null;
        m_CurrentInteractable = null;

    }
    private NewInteractable GetNearestInteractable()
    {
        NewInteractable nearest = null;
        float minDist = float.MaxValue;
        float dist = 0.0f;

        foreach(NewInteractable interactable in m_ContactInteractables)
        {
            dist = (interactable.transform.position - transform.position).sqrMagnitude;

            if(dist < minDist)
            {
                minDist = dist;
                nearest = interactable;
            }
        }

        return nearest;
    }
}
