using System;
using CutieShop.API.Models.ChatHandlers;
using System.Collections.Generic;
// ReSharper disable CollectionNeverUpdated.Local

namespace CutieShop.API.Models.Helpers
{
    /// <summary>
    /// Session Storage Helper
    /// </summary>
    internal class SessionStorageHelper
    {

        private static readonly Dictionary<Type, Dictionary<string, Dictionary<int, string>>> Storage;

        private readonly IChatHandler _chatHandler;

        public SessionStorageHelper(IChatHandler chatHandler)
        {
            _chatHandler = chatHandler;
        }

        static SessionStorageHelper()
        {
            Storage = new Dictionary<Type, Dictionary<string, Dictionary<int, string>>>();
        }

        /// <summary>
        /// Get list of stored value by providing id
        /// </summary>
        /// <param name="id">unique id</param>
        /// <returns></returns>
        internal Dictionary<int, string> this[string id] => Storage[_chatHandler.GetType()][id];

        /// <summary>
        /// Add to storage the data equivalent to the step
        /// </summary>
        /// <param name="id"></param>
        /// <param name="step"></param>
        /// <param name="value"></param>
        public void AddOrUpdateToStorage(string id, int step, string value)
        {
            //Add new secondary dictionary if Storage doesn't have the key _chatHandler
            if (!Storage.ContainsKey(_chatHandler.GetType())) Storage.Add(_chatHandler.GetType(), new Dictionary<string, Dictionary<int, string>>());
            //Add new id if not exists
            if (!Storage[_chatHandler.GetType()].ContainsKey(id)) AddId(id);
            if (!Storage[_chatHandler.GetType()][id].ContainsKey(step)) Storage[_chatHandler.GetType()][id].Add(step, value);
            else Storage[_chatHandler.GetType()][id][step] = value;
        }

        public void RemoveAllFromStorage(string id, int step)
        {
            if (!Storage[_chatHandler.GetType()].ContainsKey(id)) return;
            Storage[_chatHandler.GetType()][id].Remove(step);
        }

        private void AddId(string id)
            => Storage[_chatHandler.GetType()]
                .Add(id, new Dictionary<int, string>());
    }
}
