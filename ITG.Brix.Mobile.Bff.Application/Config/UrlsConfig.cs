using System;

namespace ITG.Brix.Mobile.Bff.Application.Config
{
    public class UrlsConfig
    {
        public static class UsersOperations
        {
            public static string Login(string version) => $"/api/users/login?api-version={version}";
        }

        public static class TeamsOperations
        {
            public static string List(string version, string filter) => $"/api/teams?api-version={version}&$filter={filter}";
            public static string Get(string version, string id) => $"/api/teams/{id}?api-version={version}";
        }

        public static class EccSetupOperations
        {
            public static string GetLayout(string version, Guid id) => $"/api/layouts/{id}?api-version={version}";
            public static string ListFlows(string version, string filter) => $"/api/flows?api-version={version}&$filter={filter}";
            public static string CreateActivities(string version) => $"/api/operatorActivities?api-version={version}";
            public static string GetLocation(string version, string filter) => $"/api/locations?api-version={version}&$filter={filter}";
            public static string GetDamageCodes(string version) => $"/api/DamageCodes?api-version={version}";
            public static string UploadPicture(string version) => $"/api/files/uploadKeepName?api-version={version}";
        }

        public static class WorkOrdersOperations
        {
            public static string List(string version, string filter) => $"/api/workorders?api-version={version}&$filter={filter}";
            public static string Get(string version, Guid id) => $"/api/workorders/{id}?api-version={version}";
            public static string Update(string version, Guid id) => $"/api/workorders/{id}?api-version={version}";
        }

//#if DEBUG
  //      private static string _url = "http://localhost";
//#else
        private static string _url = "https://sf-ktn-shared-dev.katoennatie.com";
//#endif

        public static string Users
        {
            get
            {
                return $"{_url}:5901";
            }
        }

        public static string Teams
        {
            get
            {
                return $"{_url}:5902";
            }
        }

        public static string EccSetup
        {
            get
            {
                return $"{_url}:5900";
            }
        }

        public static string WorkOrders
        {
            get
            {
                return $"{_url}:5903";
            }
        }
    }
}