using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CampUI : MonoBehaviour
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

    public void OnCampsButtonClicked()
    {
        SceneManager.LoadScene("Home");
    }

    public void OnMapButtonClicked()
    {
        SceneManager.LoadScene("test_maps");
    }

    private void OnDisable() 
    {
        ResourceManager.Instance.OnResourceChanged -= UpdateResourceText;
    }
}