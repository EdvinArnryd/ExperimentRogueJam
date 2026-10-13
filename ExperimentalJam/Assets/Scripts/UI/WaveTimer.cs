using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaveTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    void Start()
    {
        GameManager.Instance.WaveManager.OnNewWave += StartCountDown;
    }

    private void StartCountDown(float waveDuration)
    {
        StartCoroutine(StartCountDownRoutine(waveDuration));
    }

    private IEnumerator StartCountDownRoutine(float waveDuration)
    {
        float durationResult = waveDuration;

        while(durationResult > 0)
        {
            durationResult -= Time.deltaTime;
            _text.text = durationResult.ToString("F2");

            yield return null;
        }
    }

}
