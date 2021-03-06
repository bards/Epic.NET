//  
//  CargoState.cs
//  
//  Author:
//       Giacomo Tesio <giacomo@tesio.it>
// 
//  Copyright (c) 2010-2011 Giacomo Tesio
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
using Challenge00.DDDSample.Shared;
namespace Challenge00.DDDSample.Cargo
{
	[Serializable]
	public abstract class CargoState : IDelivery, IEquatable<CargoState>
	{
		private readonly DateTime _calculationDate;
		private readonly RoutingStatus _routingStatus;
		private readonly DateTime? _estimatedTimeOfArrival;
		
		protected CargoState (CargoState previousState)
		{
			if(null == previousState)
				throw new ArgumentNullException("previousState");
			_calculationDate = DateTime.UtcNow;
			_routingStatus = previousState.RoutingStatus;
			this.Identifier = previousState.Identifier;
			this.RouteSpecification = previousState.RouteSpecification;
			this.Itinerary = previousState.Itinerary;
			if(_routingStatus == RoutingStatus.Routed)
				_estimatedTimeOfArrival = this.Itinerary.FinalArrivalDate;
			else
				_estimatedTimeOfArrival = null;
		}
		
		protected CargoState (TrackingId identifier, IRouteSpecification routeSpecification)
		{
			if(null == identifier)
				throw new ArgumentNullException("identifier");
			if(null == routeSpecification)
				throw new ArgumentNullException("routeSpecification");
			
			_calculationDate = DateTime.UtcNow;
			
			this.Identifier = identifier;
			this.RouteSpecification = routeSpecification;
			_routingStatus = RoutingStatus.NotRouted;
			_estimatedTimeOfArrival = null;
		}
		
		protected CargoState (CargoState previousState, IItinerary newItinerary)
			: this(previousState)
		{
			if(null == newItinerary)
				throw new ArgumentNullException("newItinerary");
			if(!previousState.RouteSpecification.IsSatisfiedBy(newItinerary))
			{
				string message = string.Format("The itinerary provided do not satisfy the route of {0}.", Identifier);
				throw new ArgumentException(message, "itinerary");
			}
			Itinerary = newItinerary;
			_routingStatus = RoutingStatus.Routed;
			_estimatedTimeOfArrival = this.Itinerary.FinalArrivalDate;
		}
		
		protected CargoState (CargoState previousState, IRouteSpecification routeSpecification)
			: this(previousState)
		{
			if(null == routeSpecification)
				throw new ArgumentNullException("routeSpecification");
			this.RouteSpecification = routeSpecification;
			if(null != this.Itinerary)
			{
				if(this.RouteSpecification.IsSatisfiedBy(this.Itinerary))
				{
					_routingStatus = RoutingStatus.Routed;
					_estimatedTimeOfArrival = this.Itinerary.FinalArrivalDate;
				}
				else
				{
					_routingStatus = RoutingStatus.Misrouted;
				}
			}
		}
		
		public readonly TrackingId Identifier;

		public readonly IItinerary Itinerary;

		public readonly IRouteSpecification RouteSpecification;
		
		public abstract CargoState SpecifyNewRoute (IRouteSpecification routeSpecification);
		
		public abstract CargoState AssignToRoute (IItinerary itinerary);

		public abstract CargoState Recieve (Location.ILocation location, DateTime date);

		public abstract CargoState ClearCustoms (Location.ILocation location, DateTime date);

		public abstract CargoState Claim (Location.ILocation location, DateTime date);
		
		public abstract CargoState LoadOn (Voyage.IVoyage voyage, DateTime date);

		public abstract CargoState Unload (Voyage.IVoyage voyage, DateTime date);

		#region IDelivery implementation
		
		public DateTime CalculationDate 
		{
			get 
			{
				return _calculationDate;
			}
		}

		public abstract Voyage.VoyageNumber CurrentVoyage  { get; }

		public abstract Location.UnLocode LastKnownLocation { get; }

		public abstract TransportStatus TransportStatus { get; }
		
		public DateTime? EstimatedTimeOfArrival 
		{
			get 
			{
				return _estimatedTimeOfArrival;
			}
		}

		public virtual bool IsUnloadedAtDestination 
		{
			get 
			{
				return false;
			}
		}

		public RoutingStatus RoutingStatus 
		{
			get 
			{
				return _routingStatus;
			}
		}
		#endregion

		#region IEquatable[Challenge00.DDDSample.Cargo.IDelivery] implementation
		public bool Equals (IDelivery other)
		{
			if(null == other)
				return false;
			if(object.ReferenceEquals(this, other))
				return true;
			if(null != CurrentVoyage && !CurrentVoyage.Equals(other.CurrentVoyage))
				return false;
			if(null == CurrentVoyage && null != other.CurrentVoyage)
				return false;
			if(null != LastKnownLocation && !LastKnownLocation.Equals(other.LastKnownLocation))
				return false;
			if(null == LastKnownLocation && null != other.LastKnownLocation)
				return false;
			if(TransportStatus != other.TransportStatus)
				return false;
			if(_routingStatus != other.RoutingStatus)
				return false;
			if(IsUnloadedAtDestination != other.IsUnloadedAtDestination)
				return false;
			return true;
		}
		
		#endregion
		
		#region IEquatable[CargoState] implementation
		
		public virtual bool Equals (CargoState other)
		{
            if (null == other)
                return false;
            if (!this.GetType().Equals(other.GetType()))
                return false;
            if (!Equals(other as IDelivery))
				return false;
			if(object.ReferenceEquals(this, other))
				return true;
			if(!Identifier.Equals(other.Identifier))
				return false;
			if(!RouteSpecification.Equals(other.RouteSpecification))
				return false;
			if(!Itinerary.Equals(other.Itinerary))
				return false;
			return true;
		}
		
		#endregion
		
		public override string ToString ()
		{
			return string.Format ("[{7}: CalculationDate={0}, CurrentVoyage={1}, LastKnownLocation={2}, TransportStatus={3}, EstimatedTimeOfArrival={4}, IsUnloadedAtDestination={5}, RoutingStatus={6}]", CalculationDate, CurrentVoyage, LastKnownLocation, TransportStatus, EstimatedTimeOfArrival, IsUnloadedAtDestination, RoutingStatus, GetType().Name);
		}
	}
}

