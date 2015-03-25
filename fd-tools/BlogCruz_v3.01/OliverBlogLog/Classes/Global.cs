using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OliverBlogLog
{
    enum LogEntriesColumns
    {
        ID,
        BlogID,
        Url,
        Rating,
        keywords,
        Threads,
        MinIndex,
        MaxIndex,
        Created,
        Modified,
        Grabbed,
        Sessions,
        NewCounter,
        DoneCounter,
        HoldCounter,
        BadCounter,
        MiscCounter
    }

    enum LogSessionsColumns
    {
        ID,
        SessionID,
        SessionDate,
        StartIndex,
        EndIndex,
        Step,
        Images
    }

    enum LogStatsColumns
    {
        ID,
        Url,
        NewCounter,
        DoneCounter,
        HoldCounter,
        BadCounter,
        MiscCounter
    }

}
