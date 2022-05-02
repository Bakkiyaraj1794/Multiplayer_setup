using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Painting_frame_manager : MonoBehaviour
{
    public InputField CartCount;
    public void CartVal(bool PlusorMinus)
    {
        int val = int.Parse(CartCount.text);
        if (PlusorMinus)
        {
            val++;
        }
        else
        {
            if (int.Parse(CartCount.text) > 1)
            {
                val--;
            }
        }
        CartCount.text = val.ToString();
    }

    public void PurchaseItem()
    {
        
    }
    public void info()
    {
        
    }
}
