using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class AppManager : MonoBehaviour
{
   protected GameControllerScript gameControllerScript;
    public UnityEngine.UI.Text Test;
    int test; 
    public void OnPurchaseComplete(Product product)
    {


        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        if (product.definition.id == "begginer") test += 100;
        else if (product.definition.id == "middle") gameControllerScript.increaseScore(800);
        else if (product.definition.id == "bigger") gameControllerScript.increaseScore(2600);
        else if (product.definition.id == "professional") gameControllerScript.increaseScore(6500);
        else if (product.definition.id == "hyper_professional") gameControllerScript.increaseScore(10000);
        else if (product.definition.id == "legendary") gameControllerScript.increaseScore(35000);
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of product" + product.definition.id + "failed because" + reason);
    }



    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
