using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private TMP_Text _distanceText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Button _toMenuButton;

   
    private void OnEnable()
    {
        SubscribeToEvents();
    }

   
    private void Start()
    {
        
    }

    private void OnDisable()
    {
       UnSubscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        GameEvenBas.OnDistanceChange += OnDistanceChanged;
    }

    
    private void UnSubscribeFromEvents()
    {
        GameEvenBas.OnDistanceChange -= OnDistanceChanged;
    }

    private void OnDistanceChanged()
    {
        _distanceText.text = $"Distance: {Time.deltaTime}";
    }

}
