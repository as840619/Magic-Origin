using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StashUIRemove : MonoBehaviour
{
    public void RemoveCardsAll()
    {
        TagCatcher("Card");
    }

    private void TagCatcher(string tag)
    {
        foreach (GameObject temp in GameObject.FindGameObjectsWithTag(tag))
        {
            if (temp.GetComponent<CardListInUI>() != null)
            {
                //temp.AddComponent<CardUse>();
                //Destroy(temp.GetComponent<StashUIRemove>());
                Destroy(temp.gameObject);
                //temp.GetComponent<CardUse>().ResetCards();
            }
        }
    }
}
