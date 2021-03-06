﻿namespace NContext.Extensions.AspNet.WebApi.Patching
{
    using System;

    /// <summary>
    /// Defines a transfer object for HTTP PATCH support.
    /// </summary>
    public abstract class PatchRequestBase
    {
        /// <summary>
        /// Gets the on patched handler.
        /// </summary>
        /// <value>The on patched handler.</value>
        protected internal Action<object> OnPatchedHandler { get; set; }
    }
}