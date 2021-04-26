﻿using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.EnumSwitch.Refactored.V05
{
    public class DeleteClaimProvider : IGetClaim
    {
        public static Permission Permission => Permission.Delete;

        public string GetClaim()
        {
            // Processing...
            return " - User can Delete entries";
        }
    }
}