using UnityEngine;
using UnityEngine.EventSystems;

public class DragToRotate : MonoBehaviour {

	[SerializeField] private float rotationSpeedDegreesPerPixel = 0.25f;

	private bool isDragging;
	private Vector2 previousPointerPosition = Vector2.zero;

	private void Update() {
		HandleMouseInput();
	}

	private void HandleMouseInput() {
		if(Input.GetMouseButtonDown(0)) {
			if(PointerIsOverUiElement()) {
				isDragging = false;
				return;
			}

			isDragging = true;
			previousPointerPosition = Input.mousePosition;
		} else if(Input.GetMouseButton(0) && isDragging) {
			Vector2 currentPointerPosition = Input.mousePosition;
			float deltaX = currentPointerPosition.x - previousPointerPosition.x;

			ApplyRotation(deltaX);
			previousPointerPosition = currentPointerPosition;
		} else if(Input.GetMouseButtonUp(0)) {
			isDragging = false;
		}
	}

	private void ApplyRotation(float horizontalDeltaPixels) {
		float rotationAmount = horizontalDeltaPixels * rotationSpeedDegreesPerPixel;
		transform.Rotate(Vector3.up, -rotationAmount, Space.World);
	}

	private bool PointerIsOverUiElement() {
		return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
	}
}
