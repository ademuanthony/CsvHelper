﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvHelper.Tests
{
	[TestClass]
	public class RecordBuilderTests
	{
		[TestMethod]
		public void SetsDefaultCapacityInDefaultConstructorTest()
		{
			var rb = new RecordBuilder();
			Assert.AreEqual( 16, rb.Capacity );
		}

		[TestMethod]
		public void SetsDefaultCapacityWhenZeroCapacityIsGivenInConstructorTest()
		{
			var rb = new RecordBuilder( 0 );
			Assert.AreEqual( 16, rb.Capacity );
		}

		[TestMethod]
		public void SetsCapacityWhenGivenInConstructorTest()
		{
			var rb = new RecordBuilder( 1 );
			Assert.AreEqual( 1, rb.Capacity );
		}

		[TestMethod]
		public void ResizeTest()
		{
			var rb = new RecordBuilder( 2 );

			rb.Add( "1" );
			Assert.AreEqual( 1, rb.Length );
			Assert.AreEqual( 2, rb.Capacity );

			rb.Add( "2" );
			Assert.AreEqual( 2, rb.Length );
			Assert.AreEqual( 2, rb.Capacity );

			rb.Add( "3" );
			Assert.AreEqual( 3, rb.Length );
			Assert.AreEqual( 4, rb.Capacity );
		}

		[TestMethod]
		public void ClearTest()
		{
			var rb = new RecordBuilder( 1 );
			rb.Add( "1" );
			rb.Add( "2" );
			rb.Clear();
			var array = rb.ToArray();

			Assert.AreEqual( 0, rb.Length );
			Assert.AreEqual( 2, rb.Capacity );
			Assert.AreEqual( 0, array.Length );
		}

		[TestMethod]
		public void ToArrayTest()
		{
			var rb = new RecordBuilder();

			var array = rb.ToArray();
			Assert.AreEqual( 0, array.Length );

			rb.Add( "1" );
			array = rb.ToArray();
			Assert.AreEqual( 1, array.Length );
		}
	}
}
