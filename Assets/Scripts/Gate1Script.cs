using UnityEngine;

public class Gate1Script : MonoBehaviour
{
    private string closedMessage = "Двері зачинено!\r\nДля відкривання двері необхідно знайти ключ № 1. Продовжуйте пошук";
    private AudioSource closedSound;

    void Start()
    {
        closedSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Character")
        {
            // bool r = Random.value < 0.5f;
            MessagesScript.ShowMessage(closedMessage);

            closedSound.volume = GameState.effectsVolume;
            closedSound.Play();
        }
    }

}
