using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseValue : MonoBehaviour
{
    public Text value_text;
    Slider slider;
    [HideInInspector]public float Sen_value;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void Function()
    {
        value_text.text = slider.value.ToString("0.##");
        Sen_value = slider.value;
        
    }
    
}
