using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.CSharpCourse.L1100_DataTypes {


    public class DataTypesLecture : MonoBehaviour {


        [SerializeField] private Transform valueContainer;
        [SerializeField] private Button stringVariableButton;
        [SerializeField] private Button intVariableButton;
        [SerializeField] private Button boolVariableButton;
        [SerializeField] private Button floatVariableButton;
        [SerializeField] private Transform canvasTransform;
        [SerializeField] private PopupImage popupImagePrefab;
        [SerializeField] private Sprite crossSprite;
        [SerializeField] private Sprite checkSprite;


        private List<DataValue> dataValueList;
        private DataValue nextDataValue;


        private void Awake() {
            stringVariableButton.onClick.AddListener(SelectStringVariable);
            intVariableButton.onClick.AddListener(SelectIntVariable);
            boolVariableButton.onClick.AddListener(SelectBoolVariable);
            floatVariableButton.onClick.AddListener(SelectFloatVariable);
        }

        private void Start() {
            dataValueList = new List<DataValue>();

            foreach (Transform valueTransform in valueContainer) {
                valueTransform.GetComponent<CanvasGroup>().alpha = .2f;

                dataValueList.Add(valueTransform.GetComponent<DataValue>());
            }

            PickNextValue();
        }

        private void PickNextValue() {
            if (dataValueList.Count == 0) {
                // No more values
                return;
            }

            nextDataValue = dataValueList[Random.Range(0, dataValueList.Count)];
            dataValueList.Remove(nextDataValue);

            nextDataValue.GetComponent<CanvasGroup>().alpha = 1f;
        }

        private void SpawnCorrectPopup(Vector2 spawnAnchoredPosition) {
            popupImagePrefab.Instantiate(
                canvasTransform,
                spawnAnchoredPosition,
                checkSprite,
                Color.green
            );
        }

        private void SpawnWrongPopup(Vector2 spawnAnchoredPosition) {
            popupImagePrefab.Instantiate(
                canvasTransform,
                spawnAnchoredPosition,
                crossSprite,
                Color.red
            );
        }

        private void SelectStringVariable() {
            if (nextDataValue.GetDataType() == DataValue.DataType.String) {
                nextDataValue.SetTargetAnchoredPosition(stringVariableButton.GetComponent<RectTransform>().anchoredPosition);
                SpawnCorrectPopup(stringVariableButton.GetComponent<RectTransform>().anchoredPosition);
                PickNextValue();
            } else {
                SpawnWrongPopup(stringVariableButton.GetComponent<RectTransform>().anchoredPosition);
            }
        }

        private void SelectIntVariable() {
            if (nextDataValue.GetDataType() == DataValue.DataType.Int) {
                nextDataValue.SetTargetAnchoredPosition(intVariableButton.GetComponent<RectTransform>().anchoredPosition);
                SpawnCorrectPopup(intVariableButton.GetComponent<RectTransform>().anchoredPosition);
                PickNextValue();
            } else {
                SpawnWrongPopup(intVariableButton.GetComponent<RectTransform>().anchoredPosition);
            }
        }

        private void SelectBoolVariable() {
            if (nextDataValue.GetDataType() == DataValue.DataType.Bool) {
                nextDataValue.SetTargetAnchoredPosition(boolVariableButton.GetComponent<RectTransform>().anchoredPosition);
                SpawnCorrectPopup(boolVariableButton.GetComponent<RectTransform>().anchoredPosition);
                PickNextValue();
            } else {
                SpawnWrongPopup(boolVariableButton.GetComponent<RectTransform>().anchoredPosition);
            }
        }

        private void SelectFloatVariable() {
            if (nextDataValue.GetDataType() == DataValue.DataType.Float) {
                nextDataValue.SetTargetAnchoredPosition(floatVariableButton.GetComponent<RectTransform>().anchoredPosition);
                SpawnCorrectPopup(floatVariableButton.GetComponent<RectTransform>().anchoredPosition);
                PickNextValue();
            } else {
                SpawnWrongPopup(floatVariableButton.GetComponent<RectTransform>().anchoredPosition);
            }
        }

    }

}