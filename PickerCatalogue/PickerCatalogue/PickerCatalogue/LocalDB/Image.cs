using PickerCatalogue.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PickerCatalogue.LocalDB
{
    [Table("Images")]
    public class Image
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Indexed]
        [Column("brand_id")]
        public int BrandId { get; set; }

        [Indexed]
        [Column("model_id")]
        public int ModelId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
