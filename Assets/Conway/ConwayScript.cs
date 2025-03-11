using UnityEngine;

public class ConwayScript : MonoBehaviour
{
    public static ConwayScript instance { get; private set; }

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

    }
}
