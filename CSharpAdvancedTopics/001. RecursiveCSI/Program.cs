using System;
using System.Collections.Generic;

namespace _001.RecursiveArraySum
{
    public class Program
    {
        // Using it as a sandbox for a problem at work, the problem is the following we have a hierarchy of objects CSI in this case,
        //  every CSI can have one parent, one CSI can have many children. We need to check when we assign a parent to a child to see if the candidate parent 
        //  isn't lower in the hierarchy, in which case it shouldn't be possible to assing that CSI as a parent;
        public static void Main(string[] args)
        {
            var csi1 = new CSI(1);
            var csi2 = new CSI(2, 1);
            var csi3 = new CSI(3, 1);
            var csi4 = new CSI(4, 2);
            var csi5 = new CSI(5, 2);
            var csi6 = new CSI(6, 3);
            var csi7 = new CSI(7, 4);
            var csi8 = new CSI(8, 45);
            var csi45 = new CSI(45);

            var csiDic = new Dictionary<int, CSI>();
            csiDic.Add(csi1.Id, csi1);
            csiDic.Add(csi2.Id, csi2);
            csiDic.Add(csi3.Id, csi3);
            csiDic.Add(csi4.Id, csi4);
            csiDic.Add(csi5.Id, csi5);
            csiDic.Add(csi6.Id, csi6);
            csiDic.Add(csi7.Id, csi7);
            csiDic.Add(csi8.Id, csi8);
            csiDic.Add(csi45.Id, csi45);

            Console.WriteLine(CsiCanBeAChildOfParentBottonUpAproach(csi8, csi1, csiDic));
        }


        // treverses up from the candidate parent to see if the candidate child is positioned higher on the hierarchy than the candidate parent
        private static bool CsiCanBeAChildOfParentBottonUpAproach(CSI parentCsi, CSI childCsi, Dictionary<int, CSI> csis) // csis Dictionary is unnecessary 
        {
            if (parentCsi.ParentId == null)
            {
                return true;
            }

            if (parentCsi.ParentId == childCsi.Id)
            {
                return false;
            }
            else
            {
                return CsiCanBeAChildOfParentBottonUpAproach(csis[parentCsi.ParentId.Value], childCsi, csis); // csis[parentCsi.ParentId.Value] should be a call to the repository to find csi with id parentCsi.ParentId.Value
            }
        }

        // treverses down from the candidate child to see if one of the children down the hierarchy is the candidate parent (not efficient) still fun
        private static bool CsiCanBeAChildOfParentTopDown(CSI parentCsi, CSI childCsi, IList<CSI> csis)
        {
            if ((parentCsi.ParentId != null && parentCsi.ParentId == childCsi.Id))
            {
                return false;
            }

            foreach (var csi in csis) // here we need to iterate through children of childCsi 
            {
                if (csi.ParentId != null && csi.ParentId == childCsi.Id)
                {
                    if (!CsiCanBeAChildOfParentTopDown(parentCsi, csi, csis))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
    // whereId have not been passed

    public class CSI
    {
        public CSI(int id, int? parentId = null)
        {
            Id = id;
            ParentId = parentId;
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
    }
}
