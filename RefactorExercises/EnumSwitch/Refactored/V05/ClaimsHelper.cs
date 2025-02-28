﻿using RefactorExercises.EnumSwitch.Model;
using System.Text;

namespace RefactorExercises.EnumSwitch.Refactored.V05
{
    public class ClaimsHelper : IClaimsHelper
    {
        private readonly User _user;

        public ClaimsHelper(User user)
        {
            _user = user;
        }

        public string GetClaimsForUser()
        {
            var claimsBuilder = new StringBuilder($"User '{_user.Id}' has the following claims:");

            // User can have multiple claims, so loop through them
            foreach (var permission in _user.Permissions.ToEnumerable())
            {
                var claimProvider = ClaimProviderFactorySingleton.Instance.GetClaimProvider(permission);
                claimsBuilder.AppendLine(claimProvider.GetClaim());
            }

            // Return all the claims for the User
            return claimsBuilder.ToString();
        }
    }
}
