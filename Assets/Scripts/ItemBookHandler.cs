using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class ItemBookHandler : MonoBehaviour
{
    public static float Speed = 0.7f;


    // Use this for initialization
    void Start()
    {


    }

    void FixedUpdate()
    {
        transform.localPosition += new Vector3(0, 0, -1 * Speed);
        transform.Rotate(new Vector3(0, 2, 0));

    }
    protected void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            StageController.GetStartController().BookEventStart();
        }
    }

}
