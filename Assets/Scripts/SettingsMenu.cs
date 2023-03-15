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
        sensitivitySlider.onValueChanged.AddListener((v)=>{
            sliderText.text = v.ToString();
            cameraFollow.cameraRotationSpeed = v;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
