namespace userManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wxdb.messages")]
    public partial class messages
    {
        [Key]
        public int msid { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string name { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string wxid { get; set; }

        [Column(TypeName = "char")]
        [StringLength(225)]
        public string content { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string time { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string region { get; set; }

        [Column(TypeName = "char")]
        [StringLength(45)]
        public string imageid { get; set; }
        public messages() { }
        public messages(int msid, string name, string wxid,
            string content, string time, string region, string imageid)
        {
            this.msid = msid;
            this.name = name;
            this.wxid = wxid;
            this.content = content;
            this.time = time;
            this.region = region;
            this.imageid = imageid;
        }
    }
}
