using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ElementComparer
{
    /*
    Fira,       //Fire          //Light Element
    Aguis,      //Water         //Dark Element
    Jorra,      //Earth         //Dark Element
    Anemis,     //Wind          //Light Element
    Fulga,      //Lightning     //Light Element
    Glacia,     //Ice           //Dark Element
    Tenebra,    //Dark
    Sanctus     //Light 
    */

    private static Dictionary<Elements, ElementCompareContainer> ElementComparisons = new Dictionary<Elements, ElementCompareContainer>()
    {
        { Elements.Fira, new ElementCompareContainer(new Dictionary<Elements, float>()
            {
                {Elements.Fira,    1},
                {Elements.Aguis,   0.7f},
                {Elements.Jorra,   1.3f},
                {Elements.Anemis,  0.8f},
                {Elements.Fulga,   0.9f},
                {Elements.Glacia,  1.15f},
                {Elements.Tenebra, 0.8f},
                {Elements.Sanctus, 0.5f}
            })
        },
        { Elements.Aguis, new ElementCompareContainer(new Dictionary<Elements, float>()
            {
                {Elements.Fira,    1.3f},
                {Elements.Aguis,   1},
                {Elements.Jorra,   0.7f},
                {Elements.Anemis,  1.15f},
                {Elements.Fulga,   0.8f},
                {Elements.Glacia,  0.9f},
                {Elements.Tenebra, 0.5f},
                {Elements.Sanctus, 0.8f}
            })
        },
        { Elements.Jorra, new ElementCompareContainer(new Dictionary<Elements, float>()
            {
                {Elements.Fira,    0.7f},
                {Elements.Aguis,   1.3f},
                {Elements.Jorra,   1},
                {Elements.Anemis,  0.9f},
                {Elements.Fulga,   1.15f},
                {Elements.Glacia,  0.8f},
                {Elements.Tenebra, 0.5f},
                {Elements.Sanctus, 0.8f}
            })
        },
        { Elements.Anemis, new ElementCompareContainer(new Dictionary<Elements, float>()
            {
                {Elements.Fira,    1.15f},
                {Elements.Aguis,   0.8f},
                {Elements.Jorra,   0.9f},
                {Elements.Anemis,  1},
                {Elements.Fulga,   1.3f},
                {Elements.Glacia,  0.7f},
                {Elements.Tenebra, 0.8f},
                {Elements.Sanctus, 0.5f}
            })
        },
        { Elements.Fulga, new ElementCompareContainer(new Dictionary<Elements, float>()
            {
                {Elements.Fira,    0.9f},
                {Elements.Aguis,   1.15f},
                {Elements.Jorra,   0.8f},
                {Elements.Anemis,  0.7f},
                {Elements.Fulga,   1},
                {Elements.Glacia,  1.3f},
                {Elements.Tenebra, 0.8f},
                {Elements.Sanctus, 0.5f}
            })
        },
        { Elements.Glacia, new ElementCompareContainer(new Dictionary<Elements, float>()
            {
                {Elements.Fira,    0.8f},
                {Elements.Aguis,   0.9f},
                {Elements.Jorra,   1.15f},
                {Elements.Anemis,  1.3f},
                {Elements.Fulga,   0.7f},
                {Elements.Glacia,  1},
                {Elements.Tenebra, 0.5f},
                {Elements.Sanctus, 0.8f}
            })
        },
        { Elements.Tenebra, new ElementCompareContainer(new Dictionary<Elements, float>()
            {
                {Elements.Fira,    1.5f},
                {Elements.Aguis,   1.3f},
                {Elements.Jorra,   1.3f},
                {Elements.Anemis,  1.5f},
                {Elements.Fulga,   1.5f},
                {Elements.Glacia,  1.3f},
                {Elements.Tenebra, 1},
                {Elements.Sanctus, 2}
            })
        },
        { Elements.Sanctus, new ElementCompareContainer(new Dictionary<Elements, float>()
            {
                {Elements.Fira,    1.3f},
                {Elements.Aguis,   1.5f},
                {Elements.Jorra,   1.5f},
                {Elements.Anemis,  1.3f},
                {Elements.Fulga,   1.3f},
                {Elements.Glacia,  1.5f},
                {Elements.Tenebra, 2},
                {Elements.Sanctus, 1}
            })
        }
    };

    public static float GetMultiplier(Elements attacker, Elements defender)
    {
        return ElementComparisons[attacker].GetValue(defender);
    }
}

public class ElementCompareContainer
{
    private Dictionary<Elements, float> values;
    public ElementCompareContainer(Dictionary<Elements, float> d)
    {
        values = d;
    }

    public float GetValue(Elements defender)
    {
        return values[defender];
    }
}
