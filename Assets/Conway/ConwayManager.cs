using UnityEngine;

public class ConwayManager : MonoBehaviour
{
    public static ConwayManager instance { get; private set; }

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
