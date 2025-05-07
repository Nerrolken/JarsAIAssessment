using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationType", menuName = "AnimationType")]
public class AnimationType : ScriptableObject {

	public new string name;
	public int duration;
	public GameObject prefab;

#if UNITY_EDITOR

	private void OnValidate() {
		if(prefab == null) {
			Debug.LogWarning("No FBX asset assigned.");
			return;
		}

		// Check clip duration automatically.
		string assetPath = AssetDatabase.GetAssetPath(prefab);
		Object[] allAssets = AssetDatabase.LoadAllAssetsAtPath(assetPath);
		foreach(Object asset in allAssets) {
			if(asset is AnimationClip clip && !clip.name.Contains("__preview__")) {
				Debug.Log($"Clip '{clip.name}' duration: {clip.length} seconds");
				duration = Mathf.CeilToInt(clip.length);
			}
		}
	}

#endif

}
