using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Slider _sliderMaster;
    [SerializeField] private AudioMixer _mixer;

    private float _volumeMultiplier = 20;

    private void OnEnable()
    {
        _sliderMaster.onValueChanged.AddListener(On);
        _toggle.onValueChanged.AddListener(Switch);
    }

    private void OnDisable()
    {
        _sliderMaster.onValueChanged.RemoveListener(On);
        _toggle.onValueChanged.RemoveListener(Switch);
    }

    private void Switch(bool value)
    {
        float volume = value ? _sliderMaster.value : _sliderMaster.minValue;
        _mixer.SetFloat(Constants.SoundType.MasterVolume.ToString(), Mathf.Log10(volume) * _volumeMultiplier);
    }

    private void On(float value)
    {
        if (value > _sliderMaster.minValue)
            _toggle.isOn = true;
    }
}