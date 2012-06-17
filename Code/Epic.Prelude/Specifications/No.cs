//
//  No.cs
//
//  Author:
//       Giacomo Tesio <giacomo@tesio.it>
//
//  Copyright (c) 2010-2012 Giacomo Tesio
//
//  This file is part of Epic.NET.
//
//  Epic.NET is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Epic.NET is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Epic.Specifications
{
    /// <summary>
    /// Specification that is not satisfied by any <typeparamref name="TCandidate"/>.
    /// </summary>
    /// <typeparam name="TCandidate">Type of the objects that can be tested with this specification.</typeparam>
    [Serializable]
    public sealed class No<TCandidate> : SpecificationBase<No<TCandidate>, TCandidate>,
                                         IEquatable<No<TCandidate>>,
                                         ISerializable
        where TCandidate : class
    {
        private No ()
        {
        }

        /// <summary>
        /// Singleton instance of the specification.
        /// </summary>
        public static No<TCandidate> Specification = new No<TCandidate>();

        #region implemented abstract members of Epic.Specifications.SpecificationBase

        protected override bool EqualsA (No<TCandidate> otherSpecification)
        {
            return true;
        }

        protected override bool IsSatisfiedByA (TCandidate candidate)
        {
            return false;
        }

        protected override ISpecification<TCandidate> AndAlso (ISpecification<TCandidate> other)
        {
            return this;
        }

        protected override ISpecification<TCandidate> OrElse (ISpecification<TCandidate> other)
        {
            return other;
        }

        public override ISpecification<TCandidate> Negate ()
        {
            return Any<TCandidate>.Specification;
        }

        #endregion

        #region ISerializable implementation
        void ISerializable.GetObjectData (SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(Ref));
        }
        #endregion

        [Serializable]
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        private sealed class Ref : IObjectReference, ISerializable
        {
            private Ref(SerializationInfo info, StreamingContext context)
            {
            }

            #region ISerializable Members

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }

            #endregion

            #region IObjectReference Members

            public object GetRealObject(StreamingContext context)
            {
                return No<TCandidate>.Specification;
            }

            #endregion
        }
    }
}

