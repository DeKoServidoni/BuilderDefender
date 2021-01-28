using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceUI : MonoBehaviour {

    [SerializeField]
    private Transform template = null;

    private ResourceTypeListSO resources = null;
    private Dictionary<ResourceTypeSO, Transform> resourceDictionary = null;

    private void Awake() {
        resources = Resources
            .Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        resourceDictionary = new Dictionary<ResourceTypeSO, Transform>();

        int index = 0;
        foreach (ResourceTypeSO resource in resources.GetList()) {
            Transform resourceTransform = Instantiate(template, transform);

            float offsetAmount = -160f;

            resourceTransform
                .GetComponent<RectTransform>()
                .anchoredPosition = new Vector2(offsetAmount * index, 0);

            resourceTransform.Find("Image")
                .GetComponent<Image>().sprite = resource.GetSprite();

            resourceDictionary[resource] = resourceTransform;
            index++;
        }
    }

    private void Start() {
        ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;
        UpdateResourceAmount();
    }

    private void ResourceManager_OnResourceAmountChanged(object sender, System.EventArgs e) {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount() {
        foreach (ResourceTypeSO resource in resources.GetList()) {
            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resource);
            resourceDictionary[resource].Find("Text")
                .GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());

        }
    }
}
