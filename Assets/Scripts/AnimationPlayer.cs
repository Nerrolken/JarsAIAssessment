using UnityEditor;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour {

	[Header("Animation References")]
	public Transform parentTransform;
	private GameObject instantiatedObject;
	private AnimationClip animationClip;
	private Animation animationComponent;

	[Header("UI Elements")]
	public GameObject controlPanel;

	// Call this to instantiate the FBX and auto-play its animation
	public void InstantiateAndPlay(GameObject fbxPrefab) {
		controlPanel.SetActive(fbxPrefab != null);

		// Destroy any previously spawned instance
		if(instantiatedObject != null) {
			DestroyImmediate(instantiatedObject);
		}

		if(fbxPrefab == null || parentTransform == null) {
			return;
		}

		// Instantiate the prefab at localPosition zero
		instantiatedObject = Instantiate(fbxPrefab, parentTransform);
		instantiatedObject.transform.localPosition = Vector3.zero;
		instantiatedObject.transform.localRotation = Quaternion.identity;
		instantiatedObject.transform.localScale = Vector3.one;

		// Load animation clip from the FBX file
		string assetPath = AssetDatabase.GetAssetPath(fbxPrefab);
		Object[] assets = AssetDatabase.LoadAllAssetsAtPath(assetPath);

		foreach(Object asset in assets) {
			if(asset is AnimationClip clip && !clip.name.Contains("__preview__")) {
				animationClip = clip;
				break;
			}
		}

		if(animationClip == null) {
			Debug.LogError("No valid AnimationClip found in FBX asset.");
			return;
		}

		// Add legacy Animation component if needed
		animationComponent = instantiatedObject.GetComponent<Animation>();
		if(animationComponent == null) {
			animationComponent = instantiatedObject.AddComponent<Animation>();
		}

		// Add and play the clip
		animationComponent.AddClip(animationClip, animationClip.name);
		animationComponent.clip = animationClip;
		animationComponent.Play();
	}

	public void PlayAnimation() {
		if(animationComponent != null && animationClip != null) {
			animationComponent.Play(animationClip.name);
		}
	}

	public void StopAnimation() {
		if(animationComponent != null) {
			animationComponent.Stop();
		}
	}

	public void RestartAnimation() {
		if(animationComponent != null && animationClip != null) {
			animationComponent.Stop();
			animationComponent.Play(animationClip.name);
		}
	}
}
