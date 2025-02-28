﻿using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.EnumSwitch.Refactored.V04
{
    public class DeleteClaimProvider : IProvideClaims
    {
        public static Permission Permission => Permission.Delete;

        public string GetClaim()
        {
            // Processing...
            return " - User can Delete entries";
        }
    }
}
