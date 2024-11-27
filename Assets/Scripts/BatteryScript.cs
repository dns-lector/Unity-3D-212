using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameState.Collect("Battery");
        Destroy(gameObject);
    }
}
/* Д.З. Реалізувати розміщення кількох "батарейок" по полю
 * Впровадити різні величини зарядів, що вони несуть.
 */
