using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Oni.Utilities;

namespace Oni.Utilities.Tests
{
    [TestFixture]
    public class ListExtensionsTests
    {
        [TestCase]
        public static void AddIfNotNullOrEmpty_AddStringToListAndIgnoreNull_ExpectNotAddedToList()
        {
            var list = new List<String>();

            String nullString = null;

            list.AddIfNotNullOrEmpty(() => nullString);

            Assert.AreEqual(0, list.Count());
        }

        [TestCase]
        public static void AddIfNotNullOrEmpty_AddDoubleToList_ExpectAddedToList()
        {
            var list = new List<double>();

            var doubleValue = 1.0;

            list.AddIfNotNullOrEmpty(() => doubleValue);

            Assert.AreEqual(1, list.Count());
        }

        [TestCase]
        public static void AddIfNotNullOrEmpty_AddStringToListAndIgnoreEmptyStrings_ExpectNotAddedToList()
        {
            var list = new List<String>();

            var emptyString = "";

            list.AddIfNotNullOrEmpty(() => emptyString);

            Assert.AreEqual(0, list.Count());
        }

        [TestCase]
        public static void AddIfNotNullOrEmpty_AddIntToList_ExpectAddedToList()
        {
            var list = new List<int>();

            var integer = 1;

            list.AddIfNotNullOrEmpty(() => integer);

            Assert.AreEqual(1, list.Count());
        }

        [TestCase]
        public static void AddIfNotNullOrEmpty_AddStringToListAndIgnoreNull_ExpectAddedToList()
        {
            var list = new List<String>();

            var empty = "";

            list.AddIfNotNullOrEmpty(() => empty);

            Assert.IsFalse(list.Any());
        }

        [TestCase]
        public static void AddIfNotNullOrEmpty_AddNullToListAndIgnoreNull_ExpectNotAddedToList()
        {
            var list = new List<Product>();

            Product product = null;

            list.AddIfNotNullOrEmpty(() => product);

            Assert.IsFalse(list.Any());
        }


        [TestCase]
        public static void Add_AddIntToListIfObjectNotNull_ExpectNotAddedToList()
        {
            var list = new List<int>();

            var integer = 1;

            Object nullObject = null;

            list.Add(() => integer, nullObject);

            Assert.AreEqual(0, list.Count());
        }

        [TestCase]
        public static void Add_AddNullToListIgnoreNull_ExpectNotAddedToList()
        {
            var list = new List<Object>();

            Object nullObject = null;

            list.Add(() => nullObject, nullObject);

            Assert.AreEqual(0, list.Count());
        }

        [TestCase]
        public static void Add_AddProperStringToList_ExpectAddedToList()
        {
            var list = new List<string>();

            var properString = "ABCDE";

            list.Add(() => properString, properString);

            Assert.AreEqual(properString, list.FirstOrDefault());
        }

        [TestCase]
        public static void Add_Add_NullToListAndIgnoreNull_ExpectNotAddedToList()
        {
            var list = new List<BaseClass>();

            BaseClass baseC = null;

            list.Add(() => baseC, baseC);

            Assert.IsFalse(list.Any());
        }

        [TestCase]
        public static void Add_AddBoolToList_ExpectAddedToList()
        {
            var list = new List<bool>();

            bool b = true;

            list.Add(() => b, b);

            Assert.IsTrue(list.Any());
        }

        [TestCase]
        public static void Add_AddComplexObjectToListIfValueNotNull_ExpectAddedToList()
        {
            var list = new List<BaseClass>();

            var stringToAdd = "ABC";
            list.Add(() => new BaseClass(stringToAdd), stringToAdd);

            Assert.AreEqual(stringToAdd,list.FirstOrDefault().BaseString);
        }

        [TestCase]
        public static void Add_AddChildObjectOfBaseToListIfValueNotNull_ExpectAddedToList()
        {
            var list = new List<BaseClass>();

            var stringToAdd = "ABC";
            list.Add(() => new ChildClass(stringToAdd), stringToAdd);

            Assert.AreEqual(stringToAdd, list.FirstOrDefault().BaseString);
        }


        [TestCase]
        public static void Add_AddChildObjectOfBaseToList_ExpectOneAddedAndOneIgnored()
        {
            var list = new List<BaseClass>();

            var stringToAdd = "ABC";
            object nullObject = null;
            list.Add(() => new ChildClass(stringToAdd), stringToAdd);
            list.Add(() => new ChildClass(""),"");
            list.Add(() => new ChildClass(""), nullObject);

            Assert.IsTrue(list.Count() == 1);
        }

        [TestCase]
        public static void Add_Add_ObjectWithProperyToList_ExpectAddedToList()
        {
            var list = new List<Product>();

            list.Add(() => new Product() { Name = "Name" }, "Name");

            Assert.IsTrue(list.Any());
        }

        [TestCase]
        public static void Add_Add_EmptyStringInitializedObjectToList_ExpectNotAddedToList()
        {
            var list = new List<BaseClass>();

            list.Add(() => new ChildClass(""), "");

            Assert.IsFalse(list.Any());
        }

        [TestCase]
        public static void Add_AddObjectWithNullPropertyToListAndIgnoreNull_ExpectNotAddedToList()
        {
            var list = new List<Product>();

            var product = new Product();

            list.Add(() => new Product() {Name=product.Name}, product.Name);

            Assert.IsFalse(list.Any());
        }

        [TestCase]
        public static void Add_AddObjectWithPopulatedPropertyToListAndIgnoreNull_ExpectAddedToList()
        {
            var list = new List<BaseClass>();
            
            list.Add(() => new ChildClass("String"), "String");

            Assert.IsTrue(list.Any());
        }


        [TestCase]
        public static void Add_AddStringIfExpressionReturnsTrue_ExpectNotAddedToList()
        {
            var list = new List<BaseClass>();

            string toShort = "ABC";

            list.Add(() => new ChildClass(""), () => toShort.Length > 3);

            Assert.IsFalse(list.Any());
        }

    }

    public class BaseClass
    {
        public String BaseString { get; set; }

        public BaseClass() {}

        public BaseClass(String baseString)
        {
            this.BaseString = baseString;
        }
    }

    public class ChildClass : BaseClass
    {
        public ChildClass(String childString)
        {
            this.BaseString = childString;
        }
    }

    public class Product
    {
        public String Name { get; set; }      
    }
}