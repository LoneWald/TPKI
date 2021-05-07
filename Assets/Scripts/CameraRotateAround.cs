using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraRotateAround : MonoBehaviour
{

	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3; // чувствительность мышки
	public float limit = 80; // ограничение вращения по Y
	public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 10; // макс. увеличение
	public float zoomMin = 3; // мин. увеличение
	public Joystick joystick;
	private float X, Y;
	public Vector3 napr;

	void Start()
	{
		Cursor.visible = true;
		limit = Mathf.Abs(limit);
		if (limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
		transform.position = target.position + offset;
	}

	void Update()
	{
		//if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
		//else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
		offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
		napr = transform.forward;
		Y = transform.localEulerAngles.y + joystick.Horizontal * sensitivity;
		X += joystick.Vertical * sensitivity;
		X = Mathf.Clamp(X, -limit, -5);
		transform.localEulerAngles = new Vector3(-X, Y, 0);
		transform.position = transform.localRotation * offset + target.position;
	}
}
