using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    public float m_Speed = 10.0f;
    public GameObject m_Player;
    private float axis_value;

	// Use this for initialization
	void Start () {
        if (m_Player == null)
        {
            m_Player = GameObject.FindGameObjectWithTag("Player");
        }
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("X axis") * m_Speed * Time.deltaTime;
        Debug.Log(Input.GetAxisRaw("X axis"));
        axis_value = Input.GetAxisRaw("X axis");
        this.gameObject.transform.Rotate(0.0f,translation,0.0f);
	}

    void OnGUI()
    {
        GUI.TextArea(new Rect(400, 300, 250, 50), "Axis Value : " + axis_value);
    }
}
