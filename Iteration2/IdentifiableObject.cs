﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventureIteration1
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] id)
        {
            foreach (string s in id)
            {
                AddIdentifier(s);
            }
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                return _identifiers.FirstOrDefault("");
            }

            //if (_identifiers.Count > 0)
            //{
            //    return _identifiers[0];
            //}
            //else
            //{
            //    return "";
            //}
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
