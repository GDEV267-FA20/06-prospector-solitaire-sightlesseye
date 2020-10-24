using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class for each individual card in the deck. The Card script also contains 
/// the CardDefinition class (which holds information about where sprites are to 
/// be positioned on each rank of card) and the Decorator class (which holds 
/// information about the decorators and pips described in the XML document).
/// </summary>

public class Card : MonoBehaviour {
    [Header("Set Dynamically")] 
    public string suit; // Suit of the Card (C,D,H, or S) 
    public int rank; // Rank of the Card (1-14) 
    public Color color = Color.black; // Color to tint pips 
    public string colS = "Black"; // or "Red". Name of the Color
     
    // This List holds all of the Decorator GameObjects 
    public List<GameObject> decoGOs = new List<GameObject>();

    // This List holds all of the Pip GameObjects 
    public List<GameObject> pipGOs = new List<GameObject>(); 
    public GameObject back; // The GameObject of the back of the card 
    public CardDefinition def; // Parsed from DeckXML.xml

    public bool faceUp { 
        get { 
            return (!back.activeSelf); 
        } 
        set { 
            back.SetActive(!value); 
        } 
    }
}

[System.Serializable] // A Serializable class is able to be edited in the Inspector
public class Decorator {
    // This class stores information about each decorator or pip from DeckXML
    public string type; // For card pips, type = "pip"
    public Vector3 loc; // The location of the Sprite on the Card
    public bool flip = false; // Whether to flip the Sprite vertically
    public float scale = 1f; // The scale of the Sprite
}

[System.Serializable]
public class CardDefinition {
    // This class stores information for each rank of card
    public string face; // Sprite to use for each face card
    public int rank; // The rank (1-13) of this card
    public List<Decorator> pips = new List<Decorator>(); // Pips used
}


