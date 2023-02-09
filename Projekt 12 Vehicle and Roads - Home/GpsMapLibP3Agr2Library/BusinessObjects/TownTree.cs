using System;
using System.Collections.Generic;
using System.Text;



namespace GpsMapLibP3Agr2Library.BusinessObjects
{



    // Records reachability of other towns from a particular one.
    public class TownTree
    {



        private TownTreeNode root;



        public TownTree(Town startTown)
        {
            this.root = new TownTreeNode(startTown);
        }



        public TownTreeNode Root
        {
            get { return this.root; }
        }



        public List<TownTreeNode> GetNodesOnLevel(int level)
        {
            List<TownTreeNode> nodesWithGivenLevel = new List<TownTreeNode>();

            FindLevelAddNodes(this.root, level, nodesWithGivenLevel);

            return nodesWithGivenLevel;
        }



        private void FindLevelAddNodes(TownTreeNode node, int levelToFind, List<TownTreeNode> nodesWithRequiredLevel)
        {
            if (node.Level + 1 == levelToFind)
            {
                nodesWithRequiredLevel.AddRange(node.Children);
                return;
            }
            foreach (TownTreeNode childNode in node.Children)
            {
                FindLevelAddNodes(childNode, levelToFind, nodesWithRequiredLevel);
            }
        }



    }



}
