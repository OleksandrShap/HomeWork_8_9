using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField] private ViewManager _viewManager;

    [SerializeField] private Button _toPlayButton;
    [SerializeField] private Button _toExitButton;

    private void OnEnable()
    {
        _toPlayButton.onClick.AddListener(() => _viewManager.ActivateView(0));
        _toExitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _toPlayButton.onClick.RemoveAllListeners();
        _toExitButton.onClick.RemoveAllListeners();
    }

    private void Exit()
    {
        Application.Quit();
    }
}
