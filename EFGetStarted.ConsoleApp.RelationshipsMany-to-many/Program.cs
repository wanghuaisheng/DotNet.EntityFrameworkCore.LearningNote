using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGetStarted.ConsoleApp.RelationshipsMany_to_many
{
    public class Program
    {
        //Many-to-many relationships without an entity class to represent the join table are not yet supported. However, you can represent a many-to-many relationship by including an entity class for the join table and mapping two separate one-to-many relationships.
        public static void Main(string[] args)
        {
        }
    }
    public class Post
    {
        public int PostId
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }
        
        public List<PostTag> PostTags
        {
            get;
            set;
        }
    }
    
    public class Tag
    {
        public string TagId
        {
            get;
            set;
        }
        
        public List<PostTag> PostTags
        {
            get;
            set;
        }
    }
    
    public class PostTag
    {
        public int PostId
        {
            get;
            set;
        }
        public Post Post
        {
            get;
            set;
        }
        
        public string TagId
        {
            get;
            set;
        }
        public Tag Tag
        {
            get;
            set;
        }
    }
}
