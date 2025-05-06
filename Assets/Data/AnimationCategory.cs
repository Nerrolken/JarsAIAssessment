using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationCategory", menuName = "AnimationCategory")]
public class AnimationCategory : ScriptableObject {

	public new string name;
	public List<AnimationType> animations;

}
