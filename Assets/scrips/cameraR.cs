using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraR : MonoBehaviour
{
	public GameObject CameraRotate;
	public float speed = 90f;
    void Update()
    {
        
    }
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "ColorChanger")
		{
			CameraRotate.transform.Rotate(0f, 0f, speed);
		}
	}
}
