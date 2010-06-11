using NUnit.Framework;
using System;
using Challenge00.DDDSample.Default.Shared;
using Challenge00.DDDSample.Shared;
using Rhino.Mocks;
namespace Challenge00.DDDSample.Default.UnitTests.Shared
{
	[TestFixture()]
	public class NotSpecificationTester : AbstractSpecificationTester<NotSpecification<object>, object>
	{
		#region implemented abstract members of Challenge00.DDDSample.Default.UnitTests.AbstractSpecificationTester[NotSpecification[System.Object],System.Object]
		protected override void CreateEqualsSpecification (out NotSpecification<object> spec1, out NotSpecification<object> spec2)
		{
			ISpecification<object> n1 = MockRepository.GenerateMock<ISpecification<object>>();
			ISpecification<object> n2 = MockRepository.GenerateMock<ISpecification<object>>();
			n1.Expect(s => s.Equals(n2)).Return(true);
			n2.Expect(s => s.Equals(n1)).Return(true);
			
			spec1 = new NotSpecification<object>(n1);
			spec2 = new NotSpecification<object>(n2);
		}
		
		
		protected override void CreateDifferentSpecification (out NotSpecification<object> spec1, out NotSpecification<object> spec2)
		{
			ISpecification<object> n1 = MockRepository.GenerateMock<ISpecification<object>>();
			ISpecification<object> n2 = MockRepository.GenerateMock<ISpecification<object>>();
			n1.Expect(s => s.Equals(n2)).Return(false);
			n2.Expect(s => s.Equals(n1)).Return(false);
			
			spec1 = new NotSpecification<object>(n1);
			spec2 = new NotSpecification<object>(n2);
		}
		
		
		protected override NotSpecification<object> CreateNewSpecification ()
		{
			ISpecification<object> n1 = MockRepository.GenerateMock<ISpecification<object>>();
			n1.Expect(s => s.Equals(s)).Return(true);
			
			return new NotSpecification<object>(n1);
		}
		
		#endregion
		
		[Test]
		public void Test_Ctor_01()
		{
			// arrange:
			ISpecification<object> toNegate = MockRepository.GenerateMock<ISpecification<object>>();
		
			// act:
			NotSpecification<object> spec = new NotSpecification<object>(toNegate);
		
			// assert:
			Assert.IsNotNull(spec);
			Assert.AreSame(toNegate, spec.Negated);
		}
		
		[Test()]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Test_Ctor_02 ()
		{
			// arrange:
			
		
			// act:
			new NotSpecification<object>(null);
		}
		
		[Test]
		public void Test_IsSatisfiedBy_01()
		{
			// arrange:
			object candidate = new object();
			ISpecification<object> toNegate = MockRepository.GenerateMock<ISpecification<object>>();
			toNegate.Expect(s => s.IsSatisfiedBy(candidate)).Return(true);
		
			// act:
			NotSpecification<object> spec = new NotSpecification<object>(toNegate);
			bool satisfied = spec.IsSatisfiedBy(candidate);
		
			// assert:
			Assert.IsFalse(satisfied);
			toNegate.VerifyAllExpectations();
		}
		
		[Test]
		public void Test_IsSatisfiedBy_02()
		{
			// arrange:
			object candidate = new object();
			ISpecification<object> toNegate = MockRepository.GenerateMock<ISpecification<object>>();
			toNegate.Expect(s => s.IsSatisfiedBy(candidate)).Return(false);
		
			// act:
			NotSpecification<object> spec = new NotSpecification<object>(toNegate);
			bool satisfied = spec.IsSatisfiedBy(candidate);
		
			// assert:
			Assert.IsTrue(satisfied);
			toNegate.VerifyAllExpectations();
		}
	}
}
