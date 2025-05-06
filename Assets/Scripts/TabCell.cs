using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabCell : Cell {

	private static List<TabCell> allCells;

	[Header("Data Model")]
	public AnimationCategory category;

	[Header("UI Elements")]
	public TMP_Text label;

	private void OnValidate() {
		label.text = category?.name;
	}

	private void Awake() {
		allCells ??= new List<TabCell>();
		if(allCells.Contains(this) == false) allCells.Add(this);
	}

	private void Start() {
		rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, label.preferredWidth + 30);
	}

	public override void OnTapped() {
		bool isAlreadySelected = ViewController.instance.SelectedCategory == category;
		AnimationCategory selection = isAlreadySelected ? null : category;

		foreach(TabCell cell in allCells) {
			bool shouldHighlightThisCell = cell == this && !isAlreadySelected;
			cell.SetSelected(shouldHighlightThisCell);
		}

		ViewController.instance.SetAnimationCategory(selection);
	}

}
