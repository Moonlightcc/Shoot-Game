using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;
    private Transform m_Transform;
    private Transform point_Transform;
    private LineRenderer m_LineRenderer;
    private Transform parent_Transform;
    private AudioSource m_AudioSource;

    private bool handCanMove = false;
	// Use this for initialization
	void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        point_Transform = m_Transform.FindChild("Point");
        m_LineRenderer = point_Transform.gameObject.GetComponent<LineRenderer>();
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if(handCanMove)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                m_Transform.LookAt(hit.point);
                Debug.DrawLine(point_Transform.position, hit.point, Color.red);

                m_LineRenderer.SetPosition(0, point_Transform.position);
                m_LineRenderer.SetPosition(1, hit.point);

                if (hit.collider.gameObject.tag == "FeiPan" && Input.GetMouseButtonDown(0))
                {
                    parent_Transform = hit.collider.gameObject.GetComponent<Transform>().parent;
                    Transform[] feiPans = parent_Transform.GetComponentsInChildren<Transform>();
                    for (int i = 0; i < feiPans.Length; i++)
                    {
                        feiPans[i].gameObject.AddComponent<Rigidbody>();
                        
                    }
                    if (parent_Transform.gameObject.GetComponent<Shooter>().testIsOK)
                    {
                        GameObject.Destroy(parent_Transform.FindChild("Test").gameObject);
                        parent_Transform.gameObject.GetComponent<Shooter>().testIsOK = false;
                    }
                    GameObject.Destroy(parent_Transform.gameObject, 1.5f);
                    m_AudioSource.Play();
                    
                }
            }
        }
       
	}
    public void ChangeHandMove(bool status)
    {
        handCanMove = status;
    }
}
