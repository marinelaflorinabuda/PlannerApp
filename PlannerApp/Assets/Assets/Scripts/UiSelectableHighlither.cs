using Lean.Touch;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Component inheritances LeanSelectableBehaviour for OnSelect and OnDeselect. For the highligh is used a Image that expands in every direction but backside with 20 cm. Modified its transform acording to the size of the furniture object's texture, meanwhile the pivot point is on left.
/// Author: Marinela
/// </summary>
public class UiSelectableHighlither : LeanSelectableBehaviour
{
    #region Fields
    [Header("Settings")]
	public float offset=20;

	[Header("References")]
	public RectTransform highlightRectTransform;

	private Sprite _currentTexture;

    #endregion

    #region Awake
    private void Awake()
	{
		UpdateCurrentTexture();
	}
    #endregion

    #region LeanFinger 

    protected override void OnSelect(LeanFinger finger)
	{
		ToggleHighlight(true);
	}

	protected override void OnDeselect()
	{
		ToggleHighlight(false);
	}

	#endregion

	#region HighlightHandler

	private void UpdateCurrentTexture()
	{
		var image = GetComponent<Image>();
		if (image)
			_currentTexture = image.sprite;
	}

	private void ToggleHighlight(bool active)
	{
		if (active)
			highlightRectTransform.sizeDelta = GetHilightSize();
		else
			highlightRectTransform.sizeDelta = Vector2.zero;
	}

	private Vector2 GetHilightSize()
	{
		return new Vector2(_currentTexture.rect.width + offset, _currentTexture.rect.height + offset);
	} 

	#endregion
}
