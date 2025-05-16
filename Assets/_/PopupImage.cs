using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupImage : MonoBehaviour {


    [SerializeField] private Image image;


    private CanvasGroup canvasGroup;
    private float destroyTimer;


    private void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Instantiate(Transform parent, Vector2 anchoredPosition, Sprite sprite, Color color) {
        Transform spawnedPopup = GameObject.Instantiate(transform, parent);
        spawnedPopup.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        spawnedPopup.GetComponent<PopupImage>().Setup(sprite, color);
    }

    private void Setup(Sprite sprite, Color color) {
        image.sprite = sprite;
        image.color = color;
        destroyTimer = 1f;
    }

    private void Update() {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= .5f) {
            canvasGroup.alpha = destroyTimer * 2f;
        }
        if (destroyTimer <= 0f) {
            Destroy(gameObject);
        }
    }


}