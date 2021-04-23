﻿using RefactorExercises.EnumSwitch.Model;

namespace RefactorExercises.EnumSwitch.Refactored.V06
{
    public class GetDeleteClaim : IGetClaim
    {
        public static Permission Permission => Permission.Delete;

        public string GetClaim()
        {
            // Processing...
            return " - User can Delete entries";
        }
    }
}
