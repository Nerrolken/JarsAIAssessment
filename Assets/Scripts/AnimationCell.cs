using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class AnimationCell : Cell {

	private static List<AnimationCell> allCells;

	[Header("Data Model")]
	private AnimationType animationType;

	[Header("UI Elements")]
	public TMP_Text title;
	public TMP_Text subtitle;

	private void Awake() {
		allCells ??= new List<AnimationCell>();
		if(allCells.Contains(this) == false) allCells.Add(this);
	}

	public void Setup(AnimationType animationType) {
		this.animationType = animationType;

		title.text = animationType.name;
		subtitle.text = $"Animation • {FormatDurationFromSeconds(animationType.duration)}";
	}

	public override void OnTapped() {
		foreach(AnimationCell cell in allCells) {
			cell.SetSelected(cell == this);
		}

		ViewController.instance.SetAnimationType(animationType);
	}

	private string FormatDurationFromSeconds(int totalSeconds) {
		if(totalSeconds <= 0) return "0s";

		const int secondsPerMinute = 60;
		const int secondsPerHour = secondsPerMinute * 60;
		const int secondsPerDay = secondsPerHour * 24;

		int remainingSeconds = totalSeconds;

		int days = remainingSeconds / secondsPerDay;
		remainingSeconds -= days * secondsPerDay;

		int hours = remainingSeconds / secondsPerHour;
		remainingSeconds -= hours * secondsPerHour;

		int minutes = remainingSeconds / secondsPerMinute;
		remainingSeconds -= minutes * secondsPerMinute;

		int seconds = remainingSeconds; // whatever is left

		StringBuilder builder = new();

		if(days > 0) builder.Append(days + "d ");
		if(hours > 0) builder.Append(hours + "h ");
		if(minutes > 0) builder.Append(minutes + "m ");
		if(seconds > 0 || builder.Length == 0) builder.Append(seconds + "s"); // Show seconds if they’re non‑zero, or if every other component was zero.

		return builder.ToString().TrimEnd();
	}

	private void OnDestroy() {
		if(allCells.Contains(this) == false) allCells.Remove(this);
	}

}
