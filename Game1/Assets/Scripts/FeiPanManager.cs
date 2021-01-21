using UnityEngine;
using System.Collections;

public class FeiPanManager : MonoBehaviour {

    public GameObject feiPan_Object;
    private Transform par_Transform;
	// Use this for initialization
	void Start () {
        par_Transform = gameObject.GetComponent<Transform>();
    }
	
    public void StartCreateFeiPan()
    {
        InvokeRepeating("CreateFeiPan", 0f, 1.5f);
    }

    public void StopCreateFeiPan()
    {
        CancelInvoke();
    }

    void CreateFeiPan()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 Positionc = new Vector3(Random.Range(-4, 4), Random.Range(1, 2.6f), Random.Range(0.45f, 4));
            GameObject go = GameObject.Instantiate(feiPan_Object, Positionc, Quaternion.identity) as GameObject;
            go.transform.SetParent(par_Transform);
        }
    }

}
