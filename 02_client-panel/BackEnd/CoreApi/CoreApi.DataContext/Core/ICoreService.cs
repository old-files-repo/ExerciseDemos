using System;
using System.Collections.Generic;
using System.Text;
using CoreApi.DataContext.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace CoreApi.DataContext.Core
{
    public interface ICoreService<out T> : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
        ILogger<T> Logger { get; }
        IFileProvider FileProvider { get; }
    }
}
