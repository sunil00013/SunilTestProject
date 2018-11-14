using CommonLibrary.com.univaa.uscan.common.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UX.Delegates.General
{
    public class UserDelegate
    {
        CommonDelegate<object, List<object>> Statusmessage = new CommonDelegate<object, List<object>>("CommonServiceHub");


        internal async Task<List<object>> GetStatusMessage(object model)
        {
            List<object> temp = await Statusmessage.POSTDataWithReturnType(model, "Message/GetMessage");
            return temp;
        }
    }
}
