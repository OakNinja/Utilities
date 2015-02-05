using System;
using System.Collections.Generic;
using Oni;

namespace Oni.Utilities
{
    public static class ListExtensions
    {
        
        /// <summary>
        /// <para>Add item to list if value of T checkNotNullOrEmpty is not null or empty. </para>
        /// <para>If item creation is declared on Add it will never be Created and Initialized if checkValueNotNullOrEmpty is null or empty.</para> 
        /// <para>&#160;</para>
        /// <para>Usage:</para> 
        /// <para>list.Add(() => new TItem(args), checkNotNullOrEmpty);</para>
        /// <para>&#160;</para>
        /// <para>Example:</para>
        /// <para>list.Add(() => new Product(product.Id, product.Name, product.Category), product.Name);</para> 
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <param name="checkNotNullOrEmpty"></param>
        public static void Add<TItem, TValue>(this IList<TItem> list, Func<TItem> item, TValue checkNotNullOrEmpty)
        {
            Common.CheckValueNotNullOrEmptyAction(() => list.Add(item()), checkNotNullOrEmpty);
        }

        /// <summary>
        /// <para>Add item to list if addIfExpressionReturnsTrue returns true, otherwise silently ignore </para>
        /// <para>If item creation is declared on Add it will never be Created and Initialized if addIfExpressionReturnsTrue returns false.</para> 
        /// <para>&#160;</para>
        /// <para>Usage:</para> 
        /// <para>list.Add(() => new TItem(args), Func<bool>(expression));</para>
        /// <para>&#160;</para>
        /// <para>Example:</para>
        /// <para>list.Add(() => new Product(), Func<bool>(string.Length >= 2));</para> 
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <param name="checkNotNullOrEmpty"></param>
        public static void Add<TItem, TValue>(this IList<TItem> list, Func<TItem> item, Func<bool> addIfExpressionReturnsTrue)
        {
            if (addIfExpressionReturnsTrue())
                list.Add(item());
        }

        #region AddIfNotNullOrEmpty

        /// <summary>
        /// Add if item is not null or empty
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        public static void AddIfNotNullOrEmpty<TItem>(this IList<TItem> list, Func<TItem> item)
        {
            Common.CheckValueNotNullOrEmptyAction(() => list.Add(item()), item);
        }

        #endregion

        //Shelf
        #region Add_OverLoad_Func

        //public static void Add<TItem>(this IList<TItem> list, Func<TItem> item)
        //{
        //    Common.CheckValueNotNullOrEmptyAction(() => list.Add(item()), item);
        //}
        
        #endregion
        #region Lazy loaded add

        /// <summary>
        /// <para>Add item to list if checkNotNullOrEmpty is not null or empty.</para> 
        /// <para>&#160;</para>
        /// <para>Usage:</para> 
        /// <para>list.Add(new Lazy<TItem>(() => new TItem(args)), checkNotNullOrEmpty);</para>
        /// <para>&#160;</para>
        /// <para>Example</para>
        /// <para>list.Add(new Lazy<Product>(() => new Product(product.Id, product.Name, product.Category)), product.Name);</para> 
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="TBase"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <param name="checkNotNullOrEmpty"></param>
        //public static void Add<TBase, TItem, TValue>(this IList<TBase> list, Lazy<TItem> item, TValue checkNotNullOrEmpty) where TItem : TBase
        //{
        //    Common.CheckValueNotNullOrEmptyAction(() =>
        //    {
        //        list.Add(item.Value);
        //    }, checkNotNullOrEmpty);

        //}
        #endregion

    }
}
