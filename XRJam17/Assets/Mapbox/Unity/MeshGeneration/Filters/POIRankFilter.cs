namespace Mapbox.Unity.MeshGeneration.Filters
{
	using Mapbox.Unity.MeshGeneration.Data;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Mapbox/Filters/POI Scale Rank Filter")]
	public class POIRankFilter : FilterBase
	{
		public override string Key { get { return "scalerank"; } }

		[SerializeField]
		int _rank;

		public override bool Try(VectorFeatureUnity feature)
		{
			var scalerank = System.Convert.ToSingle(feature.Properties[Key]);
			return scalerank <= _rank;
		}
	}
}
