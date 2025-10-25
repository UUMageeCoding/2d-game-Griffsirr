using UnityEngine;
using TMPro; 

public class SignTrigger : MonoBehaviour
{
    public TextMeshProUGUI signText;
    public string message = "Hello"; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            signText.text = message;
            signText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            signText.gameObject.SetActive(false);
        }
    }
}
