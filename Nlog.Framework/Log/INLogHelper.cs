using System;

namespace Nlog.Framework.Log
{
    public interface INLogHelper
    {
        void LogError(Exception ex);
    }
}