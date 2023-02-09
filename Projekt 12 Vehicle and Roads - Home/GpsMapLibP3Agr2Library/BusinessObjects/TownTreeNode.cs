using System;
using System.Collections.Generic;
using System.Text;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    // Represents a node in the town tree of reachability.
    public class TownTreeNode
    {



        private Town town;

        private int level;

        private List<TownTreeNode> children { get; set; }

        private TownTreeNode parent { get; set; }



        public TownTreeNode(Town town)
        {
            this.level = 0;
            this.town = town;
            this.children = new List<TownTreeNode>();
            this.parent = null;
        }



        public TownTreeNode(Town town, TownTreeNode parent)
        {
            this.level = parent.level + 1;
            this.town = town;
            this.children = new List<TownTreeNode>();
            this.parent = parent;
        }



        public Town Town
        {
            get { return this.town; }
        }

        public int Level
        {
            get { return this.level; }
        }

        public List<TownTreeNode> Children
        {
            get { return this.children; }
        }

        public TownTreeNode Parent
        {
            get { return this.parent; }
        }



        public void AddChildTown(Town childTown)
        {
            TownTreeNode childNode = new TownTreeNode(childTown, this);
            this.children.Add(childNode);
        }



        public void AddChildTowns(List<Town> childTowns)
        {
            foreach (Town childTown in childTowns)
            {
                this.AddChildTown(childTown);
            }
        }



        public List<Town> GetChildTowns()
        {
            List<Town> childTowns = new List<Town>();

            foreach (TownTreeNode townTreeNode in this.children)
            {
                childTowns.Add(townTreeNode.town);
            }

            return childTowns;
        }



        public Town GetParentTown()
        {
            return this.parent.town;
        }



    }



}
