namespace Mapbox.Examples
{
	using UnityEngine;

	public class CameraMovement : MonoBehaviour
	{
		[SerializeField]
		float Speed = 20;

		[SerializeField]
		float _zoomSpeed = 500f;

		Vector3 _dragOrigin;
		Vector3 _cameraPosition;
		Vector3 _panOrigin;

		Quaternion _originalRotation;

		void Awake()
		{
			_originalRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
		}

		void Update()
		{
			if (Input.GetKey(KeyCode.A))
			{
				transform.Translate(-1 * Speed * Time.deltaTime, 0, 0, Space.World);
			}

			if (Input.GetKey(KeyCode.W))
			{
				transform.Translate(0, 0, 1 * Speed * Time.deltaTime, Space.World);
			}

			if (Input.GetKey(KeyCode.S))
			{
				transform.Translate(0, 0, -1 * Speed * Time.deltaTime, Space.World);
			}

			if (Input.GetKey(KeyCode.D))
			{
				transform.Translate(1 * Speed * Time.deltaTime, 0, 0, Space.World);
			}

			if (Input.GetMouseButtonDown(0))
			{
				_cameraPosition = transform.localPosition;
				_panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			}

			if (Input.GetMouseButton(0))
			{
				LeftMouseDrag();
			}
			else
			{
				var mouseScroll = Input.GetAxis("Mouse ScrollWheel");

				if (mouseScroll != 0)
				{
					transform.Translate(transform.forward * -mouseScroll * _zoomSpeed * Time.deltaTime, Space.World);
				}
			}
		}

		// TODO: add acceleration!
		void LeftMouseDrag()
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - _panOrigin;
			pos.z = pos.y;
			pos.y = 0;
			transform.localPosition = _cameraPosition + _originalRotation * (-pos * Speed);
		}
	}
}