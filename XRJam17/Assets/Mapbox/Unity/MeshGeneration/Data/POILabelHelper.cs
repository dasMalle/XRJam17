using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
namespace Mapbox.Unity.MeshGeneration.Data
{
	using TMPro;
	using UnityEngine;
	using Mapbox.Unity.MeshGeneration.Interfaces;
	using System.Collections.Generic;

	public class POILabelHelper : MonoBehaviour, IFeaturePropertySettable
	{
		[SerializeField]
		TextMeshPro _tmp;

		[SerializeField]
		TextMeshPro _detailText;

		Dictionary<string, object> _props;

		AbstractMap _map;

		public void Set(Dictionary<string, object> props)
		{
			// HACK!
			_map = FindObjectOfType<AbstractMap>();

			_props = props;
			_tmp.text = props["name"].ToString();

			int localrank;
			int scalerank;
			int.TryParse(props["scalerank"].ToString(), out scalerank);
			int.TryParse(props["localrank"].ToString(), out localrank);
			transform.localScale *= 3f / scalerank + 1f / localrank;

			var geoPosition = transform.GetGeoPosition(_map.CenterMercator, _map.WorldRelativeScale);
			string text = string.Format("{0}\n{1:0.0000},{2:0.0000}", props["type"], geoPosition.x, geoPosition.y);

			if (_detailText)
			{
				_detailText.text = text;
			}
		}
	}
}