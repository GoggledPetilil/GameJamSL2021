using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMov : MonoBehaviour
{
    public GameObject m_FocusObject;
    public float m_Speed;
    private Vector3 m_MovDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float m_MovX = 0f;
        float m_MovY = 0f;

        m_MovX = Input.GetAxisRaw("Vertical");
        m_MovY = Input.GetAxisRaw("Horizontal");

        m_MovDir = new Vector3(m_MovX, m_MovY, m_MovDir.z).normalized;
    }

    // FixedUpdate is called 60 times per second
    void FixedUpdate()
    {
        transform.RotateAround(m_FocusObject.transform.position, m_MovDir, m_Speed * Time.deltaTime);
        transform.LookAt(m_FocusObject.transform.position);
    }
}
