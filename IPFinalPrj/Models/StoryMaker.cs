using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IPFinalPrj.Models
{
    public class StoryBlock
    {
        public int StoryBlockID { get; set; }
        public int StoryBlockSeq { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string ImgName { get; set; }
        public string ImgPath { get; set; }
        public bool Status { get; set; }
        public string ExtraStringSb { get; set; }
        public int ExtraIntSb { get; set; }
        public string ExtraStringSb1 { get; set; }
        public int ExtraIntSb1 { get; set; }

        public virtual Collage collage { get; set; }
        [ForeignKey("collage")]
        public virtual int CollageID { get; set; }
    }
    public class Collage
    {
        public int CollageID { get; set; }
        public int CollageSeq { get; set; }
        public string CollageName { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        public int CollageTime { get; set; }
        public DateTime Uploaded { get; set; }
        public string ExtraStringCollage { get; set; }
        public int ExtraIntCollage { get; set; }
        public string ExtraStringCollage1 { get; set; }
        public int ExtraIntCollage1 { get; set; }
        public virtual ICollection<StoryBlock> storyblock { get; set; }
    }
}