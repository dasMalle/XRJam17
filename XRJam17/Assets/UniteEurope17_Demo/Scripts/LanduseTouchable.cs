namespace Demo.Utilities
{
	using Mapbox.Unity.MeshGeneration.Components;
	using UnityEngine;

	public class LanduseTouchable : MonoBehaviour, ITouchable
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
		}

		public void Deactivate()
		{
		}

		public void Focus()
		{
			if (_feature == null)
			{
				_feature = GetComponent<FeatureBehaviour>();
				_description = string.Format("Type: {0}\nClass: {1}", _feature.Data.Properties["type"], _feature.Data.Properties["class"]);
			}
		}
	}
}
