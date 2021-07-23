using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{

    class MyNode
    {
        //Class Object to be inserted into MyNodes List items.
        public string Key { get; set; }
        public int Value { get; set; }

        public MyNode(string key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
    }



    class HashTable
    {
        private class MyNodes : List<MyNode> {}     //This creating a class that has attributes of List to be used within data array.
        private int length;
        private MyNodes[] data;


        public HashTable(int size)
        {
            this.length = size;
            this.data = new MyNodes[size];
        }


        private int Hash(string key)
        {
            //Takes in string key and returns array index specific to key.
            int hash = 0;

            for (int i = 0; i < key.Length; i++)
            {
                hash = (hash + (int) key[i] * i) % this.length;
            }

            return hash;
        }

        public void Set(string key, int value)
        {
            //Adds the key value pair into hash table.

            //Gets the index from hash function
            int index = Hash(key);

            //Checks if a list of MyNodes already exists at the specified Array index.
            if (this.data[index] == null)
            {
                //If no list already exist at the index location creates one.
                this.data[index] = new MyNodes();
            }

            //Adds new item to the list of MyNodes at specified address.
            this.data[index].Add(new MyNode(key, value));
        }

        public int Get(string key)
        {
            //Returns the value for given key.

            //Gets the index for given key, by passing key to Hash function
            int index = Hash(key);

            //Checks if their is a MyNodes item at specified array index. return 0 if address is null
            if (this.data[index] == null)
            {
                return 0;
            }

            //Loops through each list at the specified array address.
            foreach (var node in this.data[index])
            {
                //Checks the key of each value in list against the passed key and returns value if found.
                if (node.Key.Equals(key))
                {
                    return node.Value;
                }
            }

            return 0;
        }

        public List<string> Keys()
        {
            //Returns a list of all keys, including possible Collisions
            List<string> result = new List<string>();

            //Loops through the basic Overall Array
            for (int i = 0; i < this.data.Length; i++)
            {
                //Checks that the memory address has at least 1 MyNodes List 
                if (this.data[i] != null)
                {
                    //Loops through the MyNodes List within each array[i] item in the overall array.
                    for (int j = 0; j < this.data[i].Count; j++)
                    {
                        result.Add(this.data[i][j].Key);
                    }
                }
            }

            return result;
        }
    }
}
