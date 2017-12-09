using Mapbox.Unity.MeshGeneration.Components;
using Mapbox.Unity.MeshGeneration.Modifiers;
using UnityEngine;
using Demo.Utilities;

[CreateAssetMenu(menuName = "Mapbox/Modifiers/Attach Landuse Touchable Modifier")]
public class AttachLanduseTouchableModifier : GameObjectModifier
{
	public override void Run(FeatureBehaviour fb)
	{
		fb.gameObject.AddComponent<LanduseTouchable>();
	}
}
