using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform target;

    private Vector3 targetStartPos;

	// Use this for initialization
	void Start () {
        targetStartPos = target.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position =  new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        //transform.LookAt (target);
		//transform.Rotate(0,target.rotation.y,0);
		//transform.LookAt (target);

	}
}
