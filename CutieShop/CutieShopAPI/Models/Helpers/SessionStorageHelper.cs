using System;
using CutieShop.API.Models.ChatHandlers;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CollectionNeverUpdated.Local

namespace CutieShop.API.Models.Helpers
{
    /// <summary>
    /// Session Storage Helper
    /// </summary>
    internal class SessionStorageHelper
    {

        private static readonly Dictionary<Type, Dictionary<string, Dictionary<int, Dictionary<string, string>>>> Storage;

        private readonly IChatHandler _chatHandler;

        public SessionStorageHelper(IChatHandler chatHandler)
        {
            _chatHandler = chatHandler;
        }

        static SessionStorageHelper()
        {
            Storage = new Dictionary<Type, Dictionary<string, Dictionary<int, Dictionary<string, string>>>>();
        }

        /// <summary>
        /// Get list of stored value by providing id
        /// </summary>
        /// <param name="id">unique id</param>
        /// <param name="step"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        internal string this[string id, int step, string key = ""]
        {
            get
            {
                if (!Storage.ContainsKey(_chatHandler.GetType()) ||
                    !Storage[_chatHandler.GetType()].ContainsKey(id) ||
                    !Storage[_chatHandler.GetType()][id].ContainsKey(step) ||
                    !Storage[_chatHandler.GetType()][id][step].ContainsKey(key))
                    return null;
                return Storage[_chatHandler.GetType()][id][step][key];
            }
        }

        /// <summary>
        /// Add to storage the data equivalent to the step
        /// </summary>
        /// <param name="id"></param>
        /// <param name="step"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddOrUpdateToStorage(string id, int step, string key, string value)
        {
            //Add new secondary dictionary if Storage doesn't have the key _chatHandler
            if (!Storage.ContainsKey(_chatHandler.GetType()))
                Storage.Add(_chatHandler.GetType(), new Dictionary<string, Dictionary<int, Dictionary<string, string>>>());

            //Add new id if not exists
            if (!Storage[_chatHandler.GetType()].ContainsKey(id))
                AddId(id);

            if (!Storage[_chatHandler.GetType()][id].ContainsKey(step))
                Storage[_chatHandler.GetType()][id].Add(step, new Dictionary<string, string>());

            if (!Storage[_chatHandler.GetType()][id][step].ContainsKey(key))
                Storage[_chatHandler.GetType()][id][step].Add(key, value);

            else
                Storage[_chatHandler.GetType()][id][step][key] = value;
        }

        /// <summary>
        /// Add to storage the data equivalent to the step
        /// </summary>
        /// <param name="id"></param>
        /// <param name="step"></param>
        /// <param name="value"></param>
        public void AddOrUpdateToStorage(string id, int step, string value)
        {
            AddOrUpdateToStorage(id, step, "", value);
        }

        public void RemoveStep(string id, int step)
        {
            if (!Storage.ContainsKey(_chatHandler.GetType()) ||
                !Storage[_chatHandler.GetType()].ContainsKey(id)) return;
            Storage[_chatHandler.GetType()][id].Remove(step);
        }

        private void AddId(string id)
            => Storage[_chatHandler.GetType()]
                .Add(id, new Dictionary<int, Dictionary<string, string>>());

        public void RemoveId(string id)
            => Storage[_chatHandler.GetType()].Remove(id);

        public int GetCurrentStep(string id)
        {
            if (!Storage.ContainsKey(_chatHandler.GetType()) ||
                !Storage[_chatHandler.GetType()].ContainsKey(id) ||
                Storage[_chatHandler.GetType()][id].Keys.Count <= 0) return 0;
            return Storage[_chatHandler.GetType()][id]
                .Where(x => x.Value.ContainsKey(""))
                .Max(x => x.Key);
        }

        public static void RemoveAllById(string id)
        {
            foreach (var dctType in Storage.Keys)
            {
                Storage[dctType].Remove(id);
            }
        }
    }
}
