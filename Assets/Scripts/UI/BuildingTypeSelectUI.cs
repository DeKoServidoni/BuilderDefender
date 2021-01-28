using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour {

    [SerializeField]
    private Transform template = null;

    [SerializeField]
    private Sprite arrowSprite = null;

    private readonly float offsetAmount = 130f;
    private Dictionary<BuildingTypeSO, Transform> buttonDictionary = null;

    private void Awake() {
        BuildingTypeListSO buildingTypeList = Resources
            .Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

        buttonDictionary = new Dictionary<BuildingTypeSO, Transform>();

        int index = 0;

        CreateButton(index, null);
        
        foreach (BuildingTypeSO buildingType in buildingTypeList.GetList()) {
            index++;

            var button = CreateButton(index, buildingType);
            buttonDictionary[buildingType] = button;
        }
    }

    private void Update() {
        UpdateSelectedButton();
    }

    private void UpdateSelectedButton() {
        foreach (BuildingTypeSO buildingType in buttonDictionary.Keys) {

            bool isSelected = false;

            if (BuildingManager.Instance.GetActiveBuildingType() != null) {
                isSelected = BuildingManager.Instance.GetActiveBuildingType().name == buildingType.name;
            }

            buttonDictionary[buildingType]
                .Find("Selected")
                .gameObject
                .SetActive(isSelected);
        }
    }

    private Transform CreateButton(int index, BuildingTypeSO buildingType) {
        Transform buttonTransform = Instantiate(template, transform);

         buttonTransform
            .GetComponent<RectTransform>()
            .anchoredPosition = new Vector2(offsetAmount * index, 0);

         buttonTransform.Find("Image")
            .GetComponent<Image>().sprite = (buildingType == null) ? 
             arrowSprite : buildingType.GetSprite();

        if (buildingType == null) {
            buttonTransform.Find("Image")
            .GetComponent<RectTransform>()
            .sizeDelta = new Vector2(0, -30);
        }

         buttonTransform.GetComponent<Button>().onClick.AddListener(() => {
            BuildingManager.Instance.SetActiveBuildingType(buildingType);
         });

        return buttonTransform;
    }
}
