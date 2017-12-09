using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;
using TMPro;
using Mapbox.Unity.Utilities;
using UnityEngine.Rendering;

public class Gaze : MonoBehaviour
{
	[SerializeField]
	Camera _camera;

	[SerializeField]
	Image _reticleImage;

	[SerializeField]
	Sprite _inactiveSprite;

	[SerializeField]
	Sprite _activeSprite;

	[SerializeField]
	float _activationTime;

	[SerializeField]
	AbstractMap _map;

	[SerializeField]
	TextMeshProUGUI _locationText;

	ITouchable _lastTouchable;

	float _elaspedTime;

	bool _hasBeenActivated;

	void Update()
	{
		Ray ray = _camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			var geoPosition = hit.point.GetGeoPosition(_map.CenterMercator, _map.WorldRelativeScale);
			_locationText.text = string.Format("{0:0.0000},{1:0.0000}", geoPosition.x, geoPosition.y);
			//_locationText.color = Color.white;

			var touchable = hit.transform.GetComponent<ITouchable>();
			if (touchable == null)
			{
				Deactivate();
			}
			else
			{
				if (touchable != _lastTouchable)
				{
					Deactivate();
					Activate(touchable);
					_lastTouchable = touchable;
				}

				_elaspedTime += Time.deltaTime;
				var t = _elaspedTime / _activationTime;
				if (t > 1f)
				{
					if (!_hasBeenActivated)
					{
						touchable.Activate();
						_hasBeenActivated = true;
					}
					_reticleImage.fillAmount = 0f;
				}
				else
				{
					_reticleImage.fillAmount = t;
				}
				//_locationText.color = Color.yellow;
				_locationText.text = touchable.Description;
			}
		}
		else
		{
			Deactivate();
		}
	}

	void Activate(ITouchable touchable)
	{
		_reticleImage.sprite = _activeSprite;
		_reticleImage.transform.localScale = Vector3.one * 3;
		touchable.Focus();
	}

	void Deactivate()
	{
		_elaspedTime = 0f;
		_hasBeenActivated = false;

		_reticleImage.transform.localScale = Vector3.one;
		_reticleImage.sprite = _inactiveSprite;
		_reticleImage.fillAmount = 1f;

		if (_lastTouchable != null)
		{
			_lastTouchable.Deactivate();
			_lastTouchable = null;
		}
	}
}