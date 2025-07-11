using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private Canvas[] _views;

    private void OnEnable()
    {
        ViewManagerBas.OpenCanvas += ActivateView;
    }
    private void Start()
    {
        ActivateView(0); 
    }

    private void OnDisable()
    {
        ViewManagerBas.OpenCanvas -= ActivateView;
    }
    public void ActivateView(int id)
    {
        if (id >= _views.Length)return;

        foreach (var view in _views)
        {
            view.enabled = false;
        }

        _views[id].enabled = true;
    }

}
