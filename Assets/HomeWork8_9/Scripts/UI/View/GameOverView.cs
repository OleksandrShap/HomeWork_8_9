using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private MovePlayer _movePlayer;
    [SerializeField] private ViewManager _viewManager;
    
    [SerializeField] private TMP_Text _distanceResult;
    [SerializeField] private TMP_Text _coinResult;
    [SerializeField] private Button _buttonRestart; 
    [SerializeField] private Button _buttonMenu;

    private void OnEnable()
    {
        _buttonRestart.onClick.AddListener(RestartCurrentScene);
        _buttonMenu.onClick.AddListener(() => _viewManager.ActivateView(1));
    }

    private void Update()
    {
        if (_movePlayer.IsGameOver)
        {
            _distanceResult.text = $"Distance:  {PlayerModel.Distance}";
            _coinResult.text = $"Coin:  {PlayerModel.Coin}";
        }
    }

    private void OnDisable()
    {
        _buttonRestart.onClick.RemoveListener(RestartCurrentScene);
        _buttonMenu.onClick.RemoveAllListeners();
    }
    private void RestartCurrentScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        PlayerModel.Distance = 0;
        PlayerModel.Coin = 0;
        //Time.timeScale = 1f;
    }
}
