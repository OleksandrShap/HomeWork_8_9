using UnityEngine;

public class ChangeColorModule : ActionBase
{
    [SerializeField] private SpriteRenderer _targetRenderer;
    [SerializeField] private Color _defaultColor;

    public void ChangeColor(Color newColor)
    {
        if(_targetRenderer ==  null)
        {
            Debug.LogError("Target rendere is null");
            return;
        }

        _targetRenderer.color = newColor;
    }

    public void ChangeColorToDefault()
    {
        ChangeColor(_defaultColor);
    }

    protected override void ExecuteInternal()
    {
        ChangeColorToDefault();
    }
}
