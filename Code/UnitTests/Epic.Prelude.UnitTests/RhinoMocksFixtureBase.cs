//  
//  RhinoMocksFixtureBase.cs
//  
//  Author:
//       Giacomo Tesio <giacomo@tesio.it>
// 
//  Copyright (c) 2010-2013 Giacomo Tesio
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
using NUnit.Framework;
using Rhino.Mocks;

namespace Epic
{
	public class RhinoMocksFixtureBase
	{
		private readonly IList<object> _mocks = new List<object>();
		
		[SetUp]
		public void ResetMocks()
		{
			_mocks.Clear();
		}
		
		[TearDown]
		public void VerifyMocksExpectations()
		{
			foreach(object mock in _mocks)
				mock.VerifyAllExpectations();
		}
		
		protected T GenerateStrictMock<T> (params object[] argumentsForConstructor)
		{
			T mock = MockRepository.GenerateStrictMock<T>(argumentsForConstructor);
			_mocks.Add(mock);
			return mock;
		}

		protected T GenerateStrictMock<T, TMultiMockInterface1> (params object[] argumentsForConstructor)
		{
			T mock = MockRepository.GenerateStrictMock<T, TMultiMockInterface1>(argumentsForConstructor);
			_mocks.Add(mock);
			return mock;
		}
		
		protected T GenerateStrictMock<T, TMultiMockInterface1, TMultiMockInterface2> (params object[] argumentsForConstructor)
		{
			T mock = MockRepository.GenerateStrictMock<T, TMultiMockInterface1, TMultiMockInterface2>(argumentsForConstructor);
			_mocks.Add(mock);
			return mock;
		}
		
		protected T GeneratePartialMock<T> (params object[] argumentsForConstructor)
		{
			T mock = MockRepository.GeneratePartialMock<T>(argumentsForConstructor);
			_mocks.Add(mock);
			return mock;
		}

		protected T GeneratePartialMock<T, TMultiMockInterface1> (params object[] argumentsForConstructor)
		{
			T mock = MockRepository.GeneratePartialMock<T, TMultiMockInterface1>(argumentsForConstructor);
			_mocks.Add(mock);
			return mock;
		}
		
		protected T GeneratePartialMock<T, TMultiMockInterface1, TMultiMockInterface2> (params object[] argumentsForConstructor)
		{
			T mock = MockRepository.GeneratePartialMock<T, TMultiMockInterface1, TMultiMockInterface2>(argumentsForConstructor);
			_mocks.Add(mock);
			return mock;
		}	
	}
}

