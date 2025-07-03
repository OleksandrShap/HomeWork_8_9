using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private ViewManager _viewManager;
    [SerializeField] private MovePlayer _movePlayer;

    [SerializeField] private TMP_Text _distanceText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Button _toMenuButton;

   
    private void OnEnable()
    {
        SubscribeToEvents();
    }

    private void Start()
    {
        Initialise();
    }

    private void Update()
    {
        CheckGameOver();
    }

    private void OnDisable()
    {
       UnSubscribeFromEvents();
    }

    private void Initialise()
    {
        OnDistanceChanged(PlayerModel.Distance);
        OnCoinValueChanged(PlayerModel.Coin);
    }

    private void SubscribeToEvents()
    {
        GameEvenBas.OnDistanceChange += OnDistanceChanged;
        GameEvenBas.OnCoinCountChanged += OnCoinValueChanged;
        _toMenuButton.onClick.AddListener(() => _viewManager.ActivateView(1));
        
    }

    
    private void UnSubscribeFromEvents()
    {
        GameEvenBas.OnDistanceChange -= OnDistanceChanged;
        GameEvenBas.OnCoinCountChanged -= OnCoinValueChanged;
       
        _toMenuButton.onClick.RemoveAllListeners();
    }

    private void OnDistanceChanged(int distance)
    {
        _distanceText.text = $"Distance: {distance}";
    }

    private void OnCoinValueChanged(int coinCount)
    {
        _coinText.text = $"Coin: {coinCount}";
    }
    private void CheckGameOver()
    {
        if (_movePlayer.IsGameOver)
            _viewManager.ActivateView(2);

    }

}
