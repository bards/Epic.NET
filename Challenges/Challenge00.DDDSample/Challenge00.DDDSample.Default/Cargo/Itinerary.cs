//  
//  Itinerary.cs
//  
//  Author:
//       Giacomo Tesio <giacomo@tesio.it>
// 
//  Copyright (c) 2010 Giacomo Tesio
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
using System.Collections.Generic;
using Challenge00.DDDSample.Location;
using System.Linq;
namespace Challenge00.DDDSample.Cargo
{
	[Serializable]
	public sealed class Itinerary : IItinerary
	{
		private readonly ILeg[] _legs;
		
		public Itinerary ()
			: this(new ILeg[0] { })
		{
		}
		
		private Itinerary (ILeg[] legs)
		{
			if(null == legs)
				throw new ArgumentNullException("legs");
			_legs = legs;
		}

		#region IItinerary implementation
		public IItinerary Append (ILeg leg)
		{
			if(null == leg)
				throw new ArgumentNullException("leg");
			if(_legs.Length > 0)
			{
				if(leg.LoadLocation != _legs[_legs.Length - 1].UnloadLocation)
					throw new ArgumentException("Invalid load location.", "leg");
				if(leg.LoadTime < _legs[_legs.Length - 1].UnloadTime)
					throw new ArgumentException("Invalid load time.", "leg");
			}
			ILeg[] newLegs = new ILeg[_legs.Length + 1];
			Array.Copy(_legs, newLegs, _legs.Length);
			newLegs[_legs.Length] = leg;
			return new Itinerary(newLegs);
		}

		public IItinerary ReplaceSegment (IItinerary legs)
		{
			if(null == legs)
				throw new ArgumentNullException("legs");
			
			IItinerary newItinerary = null;
			int i = 0;
			while(i < _legs.Length)
			{
				if(null != newItinerary && newItinerary.FinalArrivalLocation.Equals(_legs[i].LoadLocation))
				{
					newItinerary = newItinerary.Append(_legs[i]);
				}
				else if(_legs[i].UnloadLocation.Equals(legs.InitialDepartureLocation))
				{
					ILeg[] newLegs = new ILeg[i + 1];
					Array.Copy(_legs, newLegs, i + 1);
					newItinerary = new Itinerary(newLegs);
					foreach(ILeg l in legs)
					{
						newItinerary = newItinerary.Append(l);
					}
				}
				
				++i;
			}
			if(null == newItinerary)
			{
				string message = string.Format("The legs departure location ({0}) is not in the itinerary.", legs.InitialDepartureLocation);
				throw new ArgumentOutOfRangeException("legs", message);
			}
			
			return newItinerary;
		}

		public Location.UnLocode InitialDepartureLocation 
		{
			get 
			{
				if(_legs.Length == 0)
					return null;
				return _legs[0].LoadLocation;
			}
		}

		public Location.UnLocode FinalArrivalLocation 
		{
			get 
			{
				if(_legs.Length == 0)
					return null;
				return _legs[_legs.Length - 1].UnloadLocation;
			}
		}
		#endregion

		#region IEnumerable[Challenge00.DDDSample.Cargo.ILeg] implementation
		public IEnumerator<ILeg> GetEnumerator ()
		{
			IEnumerable<ILeg> legs = _legs;
			return legs.GetEnumerator();
		}
		#endregion

		#region IEnumerable[Challenge00.DDDSample.Cargo.ILeg] implementation
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}
		#endregion
		
		#region IEquatable[IItinerary] implementation
		public bool Equals(IItinerary other)
		{
			if(object.ReferenceEquals(other, null))
				return false;
			if(object.ReferenceEquals(this, other))
				return true;
			
			if(! InitialDepartureLocation.Equals(other.InitialDepartureLocation))
				return false;
			if(! FinalArrivalLocation.Equals(other.FinalArrivalLocation))
				return false;
			int i = 0;
			foreach(ILeg l in other)
			{
				if(i == _legs.Length)
					return false;
				if(! _legs[i].Equals(l))
					return false;
				
				++i;
			}
			if(i == _legs.Length)
				return true;
			return false;
		}
		#endregion
		
		
	}
}
