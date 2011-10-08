﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Just.cs">
//   This file is part of NContext.
//
//   NContext is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or any later version.
//
//   NContext is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with NContext.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
//
// <summary>
//   Defines a Just implementation of IMaybe<T>.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace NContext.Application.Extensions
{
    /// <summary>
    /// Defines a Just implementation of <see cref="IMaybe{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type to wrap.</typeparam>
    public sealed class Just<T> : IMaybe<T>
    {
        private readonly T _Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Just{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <remarks></remarks>
        public Just(T value)
        {
            _Value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the instance is <see cref="Just{T}"/>.
        /// </summary>
        /// <remarks></remarks>
        public Boolean IsJust
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the instance is <see cref="Nothing{T}"/>.
        /// </summary>
        /// <remarks></remarks>
        public Boolean IsNothing
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the specified default value if the <see cref="IMaybe{T}"/> is <see cref="Nothing{T}"/>; 
        /// otherwise, it returns the value contained in the <see cref="IMaybe{T}"/>.
        /// </summary>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Instance of <typeparamref name="T"/>.</returns>
        /// <remarks></remarks>
        public T FromMaybe(T defaultValue)
        {
            return _Value;
        }

        /// <summary>
        /// Returns a new <see cref="Nothing{T}"/>.
        /// </summary>
        /// <returns></returns>
        public IMaybe<T> Empty()
        {
            return new Nothing<T>();
        }

        /// <summary>
        /// Returns a new <see cref="Nothing{T}"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="bindFunc">The function used to map.</param>
        /// <returns>Instance of <see cref="IMaybe{TResult}"/>.</returns>
        /// <remarks></remarks>
        public IMaybe<TResult> Bind<TResult>(Func<T, IMaybe<TResult>> bindFunc)
        {
            return bindFunc.Invoke(_Value);
        }
    }
}