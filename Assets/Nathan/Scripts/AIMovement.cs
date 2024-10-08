using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public float m_CloseDistance = 8f;
    public Transform m_Turret;
    private GameObject m_Player;
    private NavMeshAgent m_NavAgent;
    private Rigidbody m_Rigidbody;

    // Will be set to true when this tank should follow the player 
    private bool m_Follow;

    // Use this for initialization 
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
        if (m_Follow == false)
            return;

        // get distance from player to enemy tank 
        float distance = (m_Player.transform.position - transform.position).magnitude;
        // if distance is less than stop distance, then stop moving 
        if (distance > m_CloseDistance)
        {
            m_NavAgent.SetDestination(m_Player.transform.position);
            m_NavAgent.isStopped = false;
        }
        else
        {
            m_NavAgent.isStopped = true;
        }

        if (m_Turret != null)
        {
            m_Turret.LookAt(m_Player.transform);
        }
    }
    private void OnEnable()
    {
        // when the tank is turned on, make sure it is not kinematic 
        m_Rigidbody.isKinematic = false;
    }
    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
    }

    private void OnDisable()
    {
        // when the tank is turned off, set it to kinematic so it stops moving 
        m_Rigidbody.isKinematic = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = false;
        }
    }
}
