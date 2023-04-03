using PickerCatalogue.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PickerCatalogue.LocalDB
{
    [Table("Models")]
    public class GuitarModel2
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Indexed]
        [Column("brand_id")]
        public int BrandId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("rating")]
        public double Rating { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("stock")]
        public int Stock { get; set; }
    }
}
