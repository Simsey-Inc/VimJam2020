using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private List<GameObject> hearts;
    #endregion

    #region Private Variables
    private float currHearts;
    #endregion

    private void Start()
    {
        currHearts = hearts.Count;
    }

    public void decreaseNumHearts(float amount) {
        
        currHearts -= amount;
    }
}
