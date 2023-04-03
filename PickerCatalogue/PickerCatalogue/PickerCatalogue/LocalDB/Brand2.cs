using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PickerCatalogue.LocalDB
{
    [Table("Brands")]
    public class Brand2
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("image")]
        public string Image { get; set; }
    }
}
