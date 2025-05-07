using UnityEngine;
using UnityEngine.UI;

public abstract class Cell : MonoBehaviour {

	[Header("Cell")]
	public Color normalColor;
	public Color selectedColor;
	public RectTransform rectTransform;
	public Image background;

	public void SetSelected(bool isSelected) {
		if(background == null) return;

		if(isSelected) {
			background.color = selectedColor;
		} else {
			background.color = normalColor;
		}
	}

	public virtual void OnTapped() {

	}

}
