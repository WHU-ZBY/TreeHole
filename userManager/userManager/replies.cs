namespace userManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wxdb.replies")]
    public partial class replies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int replyid { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string imageid { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string wxid { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string content { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string name { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string time { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string replyto { get; set; }
    }
}
