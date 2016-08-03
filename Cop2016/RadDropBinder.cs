using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.WinControls.UI;

namespace COP2001
{
    public class RadDropBinder
    {
        public class Item
        {
            public int Id { get; set; }

            public string Description { get; set; }

            public Item(int id, string description)
            {
                this.Id = id;
                this.Description = description;
            }
        }

        public void Bind(int id, string myRow, RadDropDownList dropDown)
        {
            List<Item> items = new List<Item>();

            items.Add(new Item(id, myRow));
            dropDown.DataSource = items;
            dropDown.DisplayMember = "Description";
            dropDown.ValueMember = "Id";
        }


    }
}
