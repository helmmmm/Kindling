using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HomeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _woodResourcesText;
    [SerializeField] private TMP_Text _coinResourcesText;
    [SerializeField] private TMP_Text _foodResourcesText;

    private void Start() 
    {
        UpdateResourcesUI();  

        ResourceManager.Instance.OnResourceChanged += UpdateResourceText;
    }

    private void UpdateResourceText(ResourceManager.ResourceTypes type, int amount)
    {
        UpdateResourcesUI();
    }

    private void UpdateResourcesUI()
    {
        _woodResourcesText.text = "<sprite name=\"Wood\"> " + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceTypes.Wood).ToString();
        _coinResourcesText.text = "<sprite name=\"Coin\"> " + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceTypes.Coin).ToString();
        _foodResourcesText.text = "<sprite name=\"Food\"> " + ResourceManager.Instance.GetResourceAmount(ResourceManager.ResourceTypes.Food).ToString();  
    }

    public void OnMapButtonClicked()
    {
        SceneManager.LoadScene("test_maps");
    }

    public void OnCampsButtonClicked()
    {
        SceneManager.LoadScene("Home");
    }

    public void OnCampButtonClicked()
    {
        SceneManager.LoadScene("Camp");
    }

    private void OnDisable() 
    {
        ResourceManager.Instance.OnResourceChanged -= UpdateResourceText;    
    }
}
