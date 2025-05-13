using System;

namespace Enums
{
    [Serializable]
    public enum TaskStatus
    {
        None, 
        InProgress,
        Cancelled,
        Completed,
    }
}