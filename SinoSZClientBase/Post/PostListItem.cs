using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientBase.Post
{
    /// <summary>
    /// 岗位列表项
    /// </summary>
    [Serializable]
    public class PostListItem
    {
        private SinoPost post = null;
        /// <summary>
        /// 岗位定义
        /// </summary>
        public SinoPost Post
        {
            get { return post; }
            set { post = value; }
        }

        public PostListItem(SinoPost _sp)
        {
            post = _sp;
        }

        public override string ToString()
        {
            if (post == null || post.PostID == null)
            {
                return "";
            }
            else
            {
                return string.Format("{0} [{1}]", post.PostName.PadRight(16, '　'), post.PostDWMC);
            }
        }

    }
}
