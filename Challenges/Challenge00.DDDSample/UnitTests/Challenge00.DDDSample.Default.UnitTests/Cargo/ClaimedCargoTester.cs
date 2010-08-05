//  
//  ClaimedCargoTester.cs
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
using NUnit.Framework;
using Challenge00.DDDSample.Cargo;
using Rhino.Mocks;
using Challenge00.DDDSample.Location;
namespace DefaultImplementation.Cargo
{
	[TestFixture()]
	public class ClaimedCargoTester
	{
		[Test]
		public void Test_Claim_01()
		{
			// arrange:
			UnLocode final = new UnLocode("FINAL");
			TrackingId id = new TrackingId("CLAIM");
			IRouteSpecification specification = MockRepository.GenerateStrictMock<IRouteSpecification>();
			CargoState previousState = MockRepository.GenerateStrictMock<CargoState>(id, specification);
		
			// act:
			ClaimedCargo state = new ClaimedCargo(previousState);
		
			// assert:
			Assert.AreEqual(TransportStatus.Claimed, state.TransportStatus);
			Assert.AreEqual(RoutingStatus.Routed, state.RoutingStatus);
			Assert.AreSame(final, state.LastKnownLocation);
			Assert.AreSame(specification, state.RouteSpecification);
			Assert.IsNull(state.CurrentVoyage);
			Assert.IsTrue(state.IsUnloadedAtDestination);
		}
		
	}
}
