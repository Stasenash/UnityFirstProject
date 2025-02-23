using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    public Player player;

    private void Awake() //до функции старт
    {
    }
    
    public void MoveStart()
    {
        player.StartMoving();
    }

    public void MoveStop()
    {
        player.StopMoving();
    }
}
