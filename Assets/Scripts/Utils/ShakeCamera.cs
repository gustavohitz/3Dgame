using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Cinemachine;

public class ShakeCamera : Singleton<ShakeCamera> {
    public CinemachineVirtualCamera virtualCamera;
    public float ShakeTime;
    [Header("Shake Values")]
    public float amplitude = 3f;
    public float frequency = 3f;
    public float time = .2f;

    [NaughtyAttributes.Button]
    public void Shake() {
        Shake(amplitude, frequency, time);
    }

    public void Shake(float amplitude, float frequency, float time) {
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;

        ShakeTime = time;
    }
    void Update() {
        if(ShakeTime > 0) {
            ShakeTime -= Time.deltaTime;
        }
        else {
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;
        }
    }
  
}
