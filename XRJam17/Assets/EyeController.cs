using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{

	public Vector3 eulerAngleOffset;

	public Transform rightEye;
	public Transform leftEye;

    void Start () {

    }

    void Update () {

    }

	public void LookAt(Vector3 worldPoint)
	{
		OrientSingleEye(rightEye, worldPoint);
		OrientSingleEye(leftEye, worldPoint);
	}

	private void OrientSingleEye(Transform t, Vector3 point)
	{
		Vector3 directionToPoint = point - t.transform.position;
		t.rotation = Quaternion.LookRotation(directionToPoint);
	}
}
