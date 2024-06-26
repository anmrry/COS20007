﻿using System;
using System.Text;

public class Inventory
{
    private List<Item> _items; 

    public Inventory()
	{
        _items = new List<Item>();
    }
    
    public bool HasItem(string id)
    {
        foreach (Item i in _items)
        {
            if (i.AreYou(id))
            {
                return true;
            }
        }
        return false;
    }

    public void Put(Item itm)
    {
        _items.Add(itm);
    }

    public Item Take(string id)
    {
        foreach (Item i in _items)
        {
            if (i.AreYou(id))
            {
                _items.Remove(i);
                return i;
            }
        }
        return null;
    }

    public Item Fetch(string id)
    {
        foreach (Item i in _items)
        {
            if (i.AreYou(id))
            {
                return i;
            }
        }
        return null;
    }

    public string ItemList
    {
        get
        {
            List<string> ItemListString = new List<string>();
            foreach (Item i in _items)
            {
                ItemListString.Add(i.ShortDescription);
            }
            return String.Join("\n", ItemListString);
        }
    }
}

