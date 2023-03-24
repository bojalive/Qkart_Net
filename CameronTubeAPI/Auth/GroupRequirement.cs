using Microsoft.AspNetCore.Authorization;

namespace CameronTubeAPI.Auth
{
    public class GroupRequirement : IAuthorizationRequirement
    {
        public string GroupName { get; set; }
        public GroupRequirement(string groupName)
        {
            GroupName = groupName;
        }
    }
}