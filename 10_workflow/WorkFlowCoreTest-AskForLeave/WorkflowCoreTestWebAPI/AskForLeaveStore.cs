using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowCoreTestWebAPI.Models;

namespace WorkflowCoreTestWebAPI
{
    public static class AskForLeaveStore
    {
        private static readonly List<AskForLeaveInfo> AskForLeaveInfos = new List<AskForLeaveInfo>();

        public static AskForLeaveInfo Get(Guid id)
        {
            return AskForLeaveInfos.First(x => x.Id == id);
        }

        public static void Add(AskForLeaveInfo askForLeaveInfo)
        {
            AskForLeaveInfos.Add(askForLeaveInfo);
        }

        public static void Update(AskForLeaveInfo askForLeaveInfo)
        {
            
        }

        public static void DeniedInfo(AskForLeaveInfo askForLeaveInfo)
        {
            
        }
    }
}