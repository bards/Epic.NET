//  
//  CargoTester.cs
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
using NUnit.Framework;
using System;
using Challenge00.DDDSample.Cargo;
using Rhino.Mocks;
using TCargo = Challenge00.DDDSample.Cargo.Cargo;
using Challenge00.DDDSample.Voyage;
using Challenge00.DDDSample.Location;

namespace DefaultImplementation.Cargo
{
	class FakeCargo : TCargo
	{
		public FakeCargo(CargoState initialState)
			: base(initialState)
		{
		}
	}
	
	[TestFixture]
	public class CargoTester
	{
		[Test]
		public void Test_Ctor_01()
		{
			// arrange:
			TrackingId identifier = new TrackingId("CARGO01");
			IRouteSpecification route = MockRepository.GenerateStrictMock<IRouteSpecification>();
		
			// act:
			TCargo tested = new TCargo(identifier, route);
		
			// assert:
			Assert.AreSame(identifier, tested.TrackingId);
			Assert.AreSame(route, tested.RouteSpecification);
			Assert.IsNotNull(tested.Delivery);
			Assert.AreEqual(TransportStatus.NotReceived, tested.Delivery.TransportStatus);
			Assert.AreEqual(RoutingStatus.NotRouted, tested.Delivery.RoutingStatus);
			Assert.IsFalse(tested.Delivery.IsUnloadedAtDestination);
			Assert.IsNull(tested.Delivery.CurrentVoyage);
			Assert.IsNull(tested.Delivery.EstimatedTimeOfArrival);
			Assert.IsNull(tested.Delivery.LastKnownLocation);
			Assert.IsNull(tested.Itinerary);
		}
		
		[Test]
		public void Test_Ctor_02 ()
		{
			// arrange:
			TrackingId identifier = new TrackingId("CARGO01");
			VoyageNumber voyage = new VoyageNumber("VYG01");
			DateTime estimatedTimeOfArrival = DateTime.Now;
			UnLocode lastKnownLocation = new UnLocode("LSTLC");
			IItinerary itinerary = MockRepository.GenerateStrictMock<IItinerary>();
			itinerary.Expect(i => i.FinalArrivalDate).Return(estimatedTimeOfArrival).Repeat.AtLeastOnce();
			IRouteSpecification route = MockRepository.GenerateStrictMock<IRouteSpecification>();
			route.Expect(r => r.IsSatisfiedBy(itinerary)).Return(true).Repeat.AtLeastOnce();
			CargoState state = MockRepository.GeneratePartialMock<CargoState>(identifier, route);
			state = MockRepository.GeneratePartialMock<CargoState>(state, itinerary);
			state.Expect(s => s.CurrentVoyage).Return(voyage).Repeat.AtLeastOnce();
			state.Expect(s => s.IsUnloadedAtDestination).Return(false).Repeat.AtLeastOnce();
			state.Expect(s => s.LastKnownLocation).Return(lastKnownLocation).Repeat.AtLeastOnce();
			state.Expect(s => s.TransportStatus).Return(TransportStatus.NotReceived).Repeat.AtLeastOnce();
			
			// act:
			ICargo cargo = MockRepository.GeneratePartialMock<TCargo>(state);
			
			// assert:
			Assert.AreSame(identifier, cargo.TrackingId);
			Assert.IsFalse(cargo.Delivery.IsUnloadedAtDestination);
			Assert.AreSame(lastKnownLocation, cargo.Delivery.LastKnownLocation);
			Assert.AreSame(itinerary, cargo.Itinerary);
			Assert.AreSame(voyage, cargo.Delivery.CurrentVoyage);
			Assert.AreSame(route, cargo.RouteSpecification);
			Assert.AreEqual(estimatedTimeOfArrival, cargo.Delivery.EstimatedTimeOfArrival);
			Assert.AreEqual(RoutingStatus.Routed, cargo.Delivery.RoutingStatus);
			Assert.AreEqual(TransportStatus.NotReceived, cargo.Delivery.TransportStatus);
			itinerary.VerifyAllExpectations();
			state.VerifyAllExpectations();
			route.VerifyAllExpectations();
		}
		
		[Test]
		public void Test_Ctor_03()
		{
			// assert:
			Assert.Throws<ArgumentNullException>(delegate{ new FakeCargo(null); });
		}

	}
}
