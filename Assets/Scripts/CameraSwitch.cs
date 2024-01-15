using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraSwitch : MonoBehaviour
{
    public Camera initialCamera;
    public Camera secondCamera;
    public TextMeshProUGUI countdownText;
    public float delayTime = 5f; // Vertragingstijd voordat de camera wordt gewisseld

    void Start()
    {
        // Zorg ervoor dat de tweede camera uitgeschakeld is bij het begin
        secondCamera.enabled = false;

        // Start een coroutine om na een vertraging van 'delayTime' van camera te wisselen
        StartCoroutine(SwitchCameraAfterDelay());
    }

    IEnumerator SwitchCameraAfterDelay()
    {
        float timer = delayTime;

        while (timer > 0f)
        {
            // Update de countdown tekst
            countdownText.text = Mathf.Ceil(timer).ToString();

            // Zet de positie van de countdown tekst op het scherm volgens de topdown camera
            Vector3 screenPos = initialCamera.WorldToScreenPoint(transform.position);
            countdownText.rectTransform.position = screenPos;

            // Verminder de timer en wacht voor een korte periode
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        // Schakel de eerste camera uit en de tweede camera in
        initialCamera.enabled = false;
        secondCamera.enabled = true;

        // Verberg de countdown tekst
        countdownText.gameObject.SetActive(false);

    }
}
