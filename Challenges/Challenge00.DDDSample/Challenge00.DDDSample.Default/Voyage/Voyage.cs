//  
//  Voyage.cs
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
using Challenge00.DDDSample.Location;
using System.Threading;
namespace Challenge00.DDDSample.Voyage
{
	[Serializable]
	public class Voyage : IVoyage
	{
		/// <summary>
		/// Current voyage state.
		/// </summary>
		protected VoyageState CurrentState;
		
		public Voyage (VoyageNumber identifier, ISchedule schedule)
			: this(new StoppedVoyage(identifier, schedule, 0))
		{
		}
	
		protected Voyage (VoyageState initialState)
		{
			if(null == initialState)
				throw new ArgumentNullException("initialState");
			CurrentState = initialState;
		}

		#region IVoyage implementation
		public event EventHandler<VoyageEventArgs> Stopped;

		public event EventHandler<VoyageEventArgs> Departed;

		public void StopOverAt (ILocation location)
		{
			if(null == location)
				throw new ArgumentNullException("location");
			
			// Thread safe, lock free sincronization
	        VoyageState stateBeforeTransition;
	        VoyageState previousState = CurrentState;
	        do
	        {
	            stateBeforeTransition = previousState;
	            VoyageState newValue = stateBeforeTransition.StopOverAt(location);
	            previousState = Interlocked.CompareExchange<VoyageState>(ref this.CurrentState, newValue, stateBeforeTransition);
	        }
	        while (previousState != stateBeforeTransition);

			if(!previousState.Equals(this.CurrentState))
			{
				VoyageEventArgs args = new VoyageEventArgs(previousState.LastKnownLocation, previousState.NextExpectedLocation);
				
				EventHandler<VoyageEventArgs> handler = Stopped;
				if(null != handler)
					handler(this, args);
			}
		}

		public void DepartFrom (ILocation location)
		{
			if(null == location)
				throw new ArgumentNullException("location");
			
	        VoyageState stateBeforeTransition;
	        VoyageState previousState = CurrentState;
	        do
	        {
	            stateBeforeTransition = previousState;
	            VoyageState newValue = stateBeforeTransition.DepartFrom(location);
	            previousState = Interlocked.CompareExchange<VoyageState>(ref this.CurrentState, newValue, stateBeforeTransition);
	        }
	        while (previousState != stateBeforeTransition);
			
			if(!previousState.Equals(this.CurrentState))
			{
				VoyageEventArgs args = new VoyageEventArgs(CurrentState.LastKnownLocation, CurrentState.NextExpectedLocation);
				
				EventHandler<VoyageEventArgs> handler = Departed;
				if(null != handler)
					handler(this, args);
			}
		}

		public VoyageNumber Number 
		{
			get 
			{
				return CurrentState.Number;
			}
		}

		public ISchedule Schedule 
		{
			get 
			{
				return CurrentState.Schedule;
			}
		}

		public UnLocode LastKnownLocation 
		{
			get 
			{
				return CurrentState.LastKnownLocation;
			}
		}
		
		public UnLocode NextExpectedLocation 
		{
			get 
			{
				return CurrentState.NextExpectedLocation;
			}
		}

		public bool IsMoving 
		{
			get 
			{
				return CurrentState.IsMoving;
			}
		}

		public bool WillStopOverAt(ILocation location)
		{
			if(null == location)
				throw new ArgumentNullException("location");
			return CurrentState.WillStopOverAt(location);
		}
		
		#endregion
	}
}

