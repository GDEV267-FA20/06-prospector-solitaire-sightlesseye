﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// The Prospector class manages the overall game. Whereas Deck handles the 
/// creation of cards, Prospector turns those cards into a game. Prospector 
/// collects the cards into various piles (like the draw pile and discard 
/// pile) and manages game logic.
/// </summary>

public class Prospector : MonoBehaviour {
    static public Prospector S;

    [Header("Set in Inspector")]
    public TextAsset deckXML;

    [Header("Set Dynamically")]
    public Deck deck;

    void Awake() { 
        S = this; // Set up a Singleton for Prospector
    }

    void Start() {
        deck = GetComponent<Deck>(); // Get the Deck
        deck.InitDeck(deckXML.text); // Pass DeckXML to it
        Deck.Shuffle(ref deck.cards); // This shuffles the deck by reference // a

        Card c;
        for (int cNum = 0; cNum < deck.cards.Count; cNum++) { 
            c = deck.cards[cNum]; 
            c.transform.localPosition = new Vector3((cNum % 13) * 3, cNum / 13 * 4, 0); 
        }
    }
}
