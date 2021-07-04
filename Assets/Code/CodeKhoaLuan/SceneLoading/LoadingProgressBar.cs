using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image = transform.GetComponent<Image>();
    }

    private void Start()
    {
        image.fillAmount = 0;
    }

    private void Update()
    {
        image.fillAmount = Loader.GetLoadingProgress();
    }
}
