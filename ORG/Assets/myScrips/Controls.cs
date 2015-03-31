using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    public float m_Speed = 10.0f;
    public GameObject m_Player;
    public float axis_value;
    private Transform m_groundCheck;
    public bool m_isGrounded;
    public float m_fallSpeed = -7.0f;
	// Use this for initialization
	void Start () {

       
        if (m_Player == null)
        {
            m_Player = GameObject.FindGameObjectWithTag("Player");
        }
        m_groundCheck = m_Player.transform.Find("groundCheck");
        //m_groundCheck = transform.Find("groundCheck");
	}
	
	// Update is called once per frame
	void Update () {
       
        axis_value = Input.GetAxisRaw("X axis");
       
        Debug.DrawRay(m_Player.transform.position, m_groundCheck.position);
     
	}

    void FixedUpdate()
    {

        float translation = Input.GetAxis("X axis") * m_Speed * Time.deltaTime;
        this.gameObject.transform.Rotate(0.0f,translation,0.0f);

        m_isGrounded = Physics.Raycast(m_Player.transform.position, m_groundCheck.position, 0.5f, 1 << LayerMask.NameToLayer("Ground"));
        if (m_isGrounded == false)
        {
            this.transform.Translate(0.0f,m_fallSpeed * Time.deltaTime,0.0f);
        }

    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(400, 300, 250, 50), "Axis Value : " + axis_value);
        GUI.TextArea(new Rect(400, 550, 250, 50), "m_isGrounded Value : " + m_isGrounded);
    }
}
