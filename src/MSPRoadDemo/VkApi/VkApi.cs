using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MSPRoadDemo.VkApi
{
    [DataContract]
    public class Reposts
    {
        [DataMember(Name = "profiles")]
        public IEnumerable<Profiles> Profiles { get; set; }
    }

    [DataContract]
    public class RepostsResponse
    {
        [DataMember(Name = "response")]
        public Reposts Response { get; set; }
    }

    [DataContract]
    public class AccessToken
    {
        [DataMember(Name = "access_token")]
        public string Token { get; set; }
    }

    [DataContract]
    public class Profiles
    {
        [DataMember(Name = "uid")]
        public int Id { get; set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "photo")]
        public string Photo { get; set; }
    }

    public class VkApi:IVkApi
    {
        private HttpClient client = new HttpClient();
        private AccessToken token;

        public VkApi()
        {
            //client.BaseAddress = new Uri("https://oauth.vk.com/");
            //var response = client.GetAsync(
            //    "access_token?client_id=5574235&client_secret=JlyITrrtu6cxzDFXuLnF&v=5.59&grant_type=client_credentials").Result;
            //token = response.Content.ReadAsAsync<AccessToken>(new[] { new JsonMediaTypeFormatter()}).Result;
            client.BaseAddress = new Uri("https://api.vk.com/method/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<RepostsResponse> GetReposts(int ownerId, int postId)
        {
            string getrepostsRequest = String.Format("wall.getReposts?count=1000&owner_id={0}&post_id={1}",
                ownerId, postId);
            HttpResponseMessage response = await client.GetAsync(getrepostsRequest);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<RepostsResponse>(new[] { new JsonMediaTypeFormatter() });
            }
            return null;
        }
    }
}
