using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveValue  {

	private static int comida, stolen;

    public static int Comida 
    {
        get 
        {
            return comida;
        }
        set 
        {
            comida = value;
        }
    }

	 public static int Stolen 
    {
        get 
        {
            return stolen;
        }
        set 
        {
            stolen = value;
        }
    }
	
	
}
