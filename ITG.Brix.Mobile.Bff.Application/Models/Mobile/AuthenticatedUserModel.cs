using ITG.Brix.Mobile.Bff.Application.Models.Local;
using System;

namespace ITG.Brix.Mobile.Bff.Application.Models.Mobile
{
    public class AuthenticatedUserModel
    {
        public Guid Id { get; set; }
        public TeamLocalModel Team { get; set; }
        public string Layout { get; set; }
    }
}
