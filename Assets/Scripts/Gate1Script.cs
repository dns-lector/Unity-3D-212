using UnityEngine;

public class Gate1Script : MonoBehaviour
{
    private string closedMessage = "���� ��������!\r\n��� ���������� ���� ��������� ������ ���� � 1. ����������� �����";

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Character")
        {
            bool r = Random.value < 0.5f;
            MessagesScript.ShowMessage(closedMessage + r);
        }
    }



    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
