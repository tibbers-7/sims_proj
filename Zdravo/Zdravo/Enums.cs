/***********************************************************************
 * Module:  Gender.cs
 * Author:  Darko
 * Purpose: Definition of the Enum Model.Gender
 ***********************************************************************/

using System;

namespace Zdravo
{
   public enum Gender
   {
      female,
      male
   }

    public enum RoomType
    {
        operatingRoom,
        intensiveCare,
        meetingRoom,
        waitingRoom,
        laboratory,
        restRoom,
        magacin,
        stockroom,
        toilet
    }

    public enum MarriageStatus
    {
        single,
        married,
        widow,
        divorced
    }
    public enum AccountType
    {
        sekretar,
        lekar,
        upravnik
    }

    public enum VacationStatus
    {
        accepted,
        denied,
        waiting
    }
}