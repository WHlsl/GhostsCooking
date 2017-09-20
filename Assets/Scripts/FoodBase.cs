using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBase : MonoBehaviour {
    
    public enum Name
    {
        cabbage, carrot,meat, flour
    }
    private Name name=Name.cabbage;
    public enum State
    {
        raw,fCut,fCook,overCooked

    }
    private State state = State.raw;
	
    public enum Place
    {
        basket,hand,cuttingBoard,pan,bowl
    }
    private Place place = Place.basket;
    
}
