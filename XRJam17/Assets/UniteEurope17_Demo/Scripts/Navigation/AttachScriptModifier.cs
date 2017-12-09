using Mapbox.Unity.MeshGeneration.Components;
using Mapbox.Unity.MeshGeneration.Modifiers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mapbox/Modifiers/Attach Script Modifier")]
public class AttachScriptModifier : GameObjectModifier
{
	public override void Run(FeatureBehaviour fb)
	{
		fb.gameObject.AddComponent<NavMeshSourceTag>();
	}
}
