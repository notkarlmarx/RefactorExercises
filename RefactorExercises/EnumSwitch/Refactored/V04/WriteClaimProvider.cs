﻿using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.EnumSwitch.Refactored.V04
{
    public class WriteClaimProvider : IProvideClaims
    {
        public static Permission Permission => Permission.Write;

        public string GetClaim()
        {
            // Processing...
            return "- User can Write entries";
        }
    }
}
