﻿using RefactorExercises.EnumSwitch.Model;
using System;
using System.Text;

namespace RefactorExercises.EnumSwitch.Refactored.V02
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
                var claimProvider = GetClaimProvider(permission);
                claimsBuilder.AppendLine(claimProvider.GetClaim());
            }

            // Return all the claims for the User
            return claimsBuilder.ToString();
        }

        private IProvideClaims GetClaimProvider(Permission permission)
        {
            return permission switch
            {
                Permission.Read => new ReadClaimProvider(),
                Permission.Write => new WriteClaimProvider(),
                Permission.Delete => new DeleteClaimProvider(),
                _ => throw new NotSupportedException($"Claim of type '{permission}' is not supported"),
            };
        }
    }
}
