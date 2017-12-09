namespace Demo.Utilities
{
	using Mapbox.Unity.Utilities;
	using Mapbox.Unity.Map;
	using Mapbox.Unity;
	using Mapbox.Geocoding;
	using Mapbox.Unity.MeshGeneration.Components;
	using UnityEngine;

	public class BuildingTouchable : MonoBehaviour, ITouchable
	{
		FeatureBehaviour _feature;

		Material _focusMaterial;
		Material[] _originalMaterials;

		MeshRenderer _meshRenderer;

		string _description;
		public string Description
		{
			get
			{
				return _description;
			}
		}

		public void Activate()
		{
			// HACK!
			var map = FindObjectOfType<AbstractMap>();

			var geoCoords = GetComponent<Renderer>().bounds.center.GetGeoPosition(map.CenterMercator, map.WorldRelativeScale);
			var reverseGeocodeResource = new ReverseGeocodeResource(geoCoords);
			MapboxAccess.Instance.Geocoder.Geocode(reverseGeocodeResource, (ReverseGeocodeResponse obj) =>
			{
				if (obj.Features != null && obj.Features.Count > 0)
				{
					var feature = obj.Features[0];
					var name = feature.PlaceName;
					_description = name;
				}
			});
		}

		public void Deactivate()
		{
			_meshRenderer.materials = _originalMaterials;
		}

		public void Focus()
		{
			if (_feature == null)
			{
				_feature = GetComponent<FeatureBehaviour>();
				_meshRenderer = GetComponent<MeshRenderer>();
				_originalMaterials = _meshRenderer.sharedMaterials;
				_focusMaterial = Resources.Load<Material>("HighlightMaterial");
			}

			_meshRenderer.materials = new Material[] { _focusMaterial, _focusMaterial };

			_description = string.Format("Geocoding . . .\nType: {0}\nHeight: {1}", _feature.Data.Properties["type"], _feature.Data.Properties["height"]);
		}
	}
}
