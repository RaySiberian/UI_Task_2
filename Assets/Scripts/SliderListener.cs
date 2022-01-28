using UnityEngine;
using UnityEngine.UI;

public class SliderListener : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Slider progressBar;
    
    private void Update()
    {
        progressBar.value = Mathf.Lerp(progressBar.value, slider.value, Time.deltaTime * 10f);
    }
}
