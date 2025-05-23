using TMPro;
using UnityEngine;

public class ViewController : MonoBehaviour {

	public static ViewController instance;

	[Header("Data Model")]
	private AnimationCategory selectedCategory;
	private AnimationType selectedType;
	public AnimationCategory SelectedCategory => selectedCategory;
	public AnimationPlayer animationPlayer;

	[Header("Prefabs")]
	public AnimationCell cellPrefab;
	public TMP_Text nonePrefab;

	[Header("UI Elements")]
	public TMP_Text animationListHeader;
	public RectTransform animationList;

	private void Awake() {
		instance = this;
	}

	private void Start() {
		SetAnimationCategory(null);
	}

	public void SetAnimationCategory(AnimationCategory category) {
		selectedCategory = category;
		SetAnimationType(null);

		RefreshAnimationList();
	}

	public void SetAnimationType(AnimationType type) {
		selectedType = type;
		animationPlayer.InstantiateAndPlay(type?.prefab);
	}

	private void RefreshAnimationList() {
		// Clear existing entries
		foreach(RectTransform child in animationList) {
			Destroy(child.gameObject);
		}

		// Check if we've selected anything.
		if(selectedCategory == null) {
			animationListHeader.text = "";
			return;
		}

		// Set the proper content.
		animationListHeader.text = selectedCategory.name;
		foreach(AnimationType animationType in selectedCategory.animations) {
			AnimationCell cell = Instantiate(cellPrefab, animationList);
			cell.Setup(animationType);
		}

		// Set empty indicator
		if(selectedCategory.animations.Count == 0) {
			TMP_Text label = Instantiate(nonePrefab, animationList);
			label.text = $"No {selectedCategory.name} animations available";
		}
	}

}
