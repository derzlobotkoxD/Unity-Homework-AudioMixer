using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Constants.SoundType _soundType;

    private float _volumeMultiplier = 20;
    private float _minimumValue = 0.0001f;
    private float _maximumValue = 1f;

    private void Start()
    {
        _slider.maxValue = _maximumValue;
        _slider.minValue = _minimumValue;
        ChangeVolume(_slider.value);
    }

    private void OnEnable() =>
        _slider.onValueChanged.AddListener(ChangeVolume);

    private void OnDisable() =>
        _slider.onValueChanged.RemoveListener(ChangeVolume);

    private void ChangeVolume(float volume) =>
        _mixer.SetFloat(_soundType.ToString(), Mathf.Log10(volume) * _volumeMultiplier);
}
