using Mapbox.Unity.MeshGeneration.Components;
using Mapbox.Unity.MeshGeneration.Modifiers;
using UnityEngine;
using Demo.Utilities;

[CreateAssetMenu(menuName = "Mapbox/Modifiers/Attach Building Touchable Modifier")]
public class AttachBuildingTouchableModifier : GameObjectModifier
{
	public override void Run(FeatureBehaviour fb)
	{
		fb.gameObject.AddComponent<BuildingTouchable>();
	}
}
