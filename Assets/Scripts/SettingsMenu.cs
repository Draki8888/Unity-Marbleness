using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] TextMeshProUGUI sliderText;
    
    public CameraFollow cameraFollow;
    void Start()
    {
        sliderText.text = PlayerPrefs.GetFloat("SensitivityValue").ToString();
        sensitivitySlider.value = PlayerPrefs.GetFloat("SensitivityValue");
        
        sensitivitySlider.onValueChanged.AddListener((v)=>{
            PlayerPrefs.SetFloat("SensitivityValue", v);
            sliderText.text = v.ToString();
            cameraFollow.cameraRotationSpeed = v;
        });
    }
}
