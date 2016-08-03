using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP2001
{
    public class CategoriesItems : IEquatable<CategoriesItems>
    {
        public int measureCatId { get; set; }
        public string cat { get; set; }
        public string catDescription { get; set; }
        public string catType { get; set; }

        public override string ToString()
        {
            return string.Format("Cat: {0} Cat Description: {1}", cat, catDescription);
        }

        public override bool Equals (object obj)
        {
            if (obj == null) return false;
            CategoriesItems objAsCategoriesItems = obj as CategoriesItems;
            if (objAsCategoriesItems == null) return false;
            else return Equals(objAsCategoriesItems);
        }

        public override int GetHashCode()
        {
            return measureCatId;
        }

        public bool Equals(CategoriesItems other)
        {
            if (other == null) return false;
            return (this.measureCatId.Equals(other.measureCatId));
        }
    }
}
