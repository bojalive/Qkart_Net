using Microsoft.AspNetCore.Authorization;
using Microsoft.Graph;

namespace CameronTubeAPI.Auth
{
    public class GroupAuthHandler : AuthorizationHandler<GroupRequirement>
    {
        //graphapi client needed
        private readonly GraphServiceClient _graphServiceClient;

        //graph api client is injected
        public GroupAuthHandler(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GroupRequirement requirement)
        {
            //check if user identity is authenticated
            if (context?.User?.Identity?.IsAuthenticated == true)
            {

                if (context.User.HasClaim(c => c.Type == "groups" && c.Value == requirement.GroupName))
                {
                    context.Succeed(requirement);
                }

                //if condition to check if context has hasgroups type
                if (context.User.Claims.Any(i => i.Type == "hasgroups" && i.Value == requirement.GroupName))
                {

                    // graph client to check member groups of list of strings is contain
                    var groupResult = _graphServiceClient.Me.CheckMemberGroups(new List<string> { requirement.GroupName })
                        .Request().PostAsync().Result;

                    if (groupResult.Any(x => x == requirement.GroupName))
                    {
                        context.Succeed(requirement);
                    }
                }

            }
            return Task.CompletedTask;
        }
    }

}
