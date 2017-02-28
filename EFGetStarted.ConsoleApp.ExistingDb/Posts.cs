namespace EFGetStarted.ConsoleApp.ExistingDb
{
    public partial class Posts
    {
        public int PostId
        {
            get;
            set;
        }
        
        public int BlogId
        {
            get;
            set;
        }
        
        public string Content
        {
            get;
            set;
        }
        
        public string Title
        {
            get;
            set;
        }
        
        public virtual Blogs Blog
        {
            get;
            set;
        }
    }
}