using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int fruitsCount;
    public Text fruitsCountText;



    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }

        instance = this;
    }


    public void AddFruits(int count)
    {
        fruitsCount += count;
        fruitsCountText.text = fruitsCount.ToString();

    }

}
