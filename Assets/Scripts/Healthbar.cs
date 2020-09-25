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

    public void decreaseNumHearts(float amount)
    {
        StartCoroutine(decreaseNumHeartsCoroutine(amount));
    }

    private IEnumerator decreaseNumHeartsCoroutine(float amount)
    {
        for (float i = amount; i > 0; i -= 0.5f) {
            Animator heartToChangeAnimator = hearts[Mathf.FloorToInt(currHearts) - 1].GetComponent<Animator>();
            if (currHearts == Mathf.Floor(currHearts))
            {
                heartToChangeAnimator.SetTrigger("FromFullToHalf");
            }
            else
            {
                heartToChangeAnimator.SetTrigger("FromHalfToEmpty");
            }
            currHearts -= 0.5f;
            yield return new WaitForSeconds(heartToChangeAnimator.GetCurrentAnimatorClipInfo(0).Length);
        }
    }
}
