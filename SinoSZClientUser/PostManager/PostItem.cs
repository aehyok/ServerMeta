using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientUser.PostManager
{
        [Serializable]
        public class PostItem
        {
                private SinoPost postData = null;

                public PostItem(SinoPost _post) { 
                        postData = _post;
                }

                public SinoPost PostData
                {
                        get { return postData; }
                        set { postData = value; }
                }

                public string PostName
                {
                        get { return postData.PostName; }
                        set { postData.PostName = value; }
                }

                public string PostDescript
                {
                        get { return postData.PostDescript; }
                        set { postData.PostDescript = value; }
                }

                public int SecretLevel
                {
                        get { return postData.SecretLevel; }
                        set { postData.SecretLevel = value; }
                }
                        
        }
}
