using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace VolvoCanLogger
{
    public class ConfigIdName
    {
        public int Id;
        public string Name;
    }
    public class ConfigIdMask
    {
        public int Id;
        public ulong DataMask = 0xFFFFFFFFFFFFFFFF;
    }

    public class ConfigData : AppSettings<ConfigData>
    {
        public ulong DataMask = 0xFFFFFFFFFFFFFFFF;
        public List<ConfigIdName> Names;
        public List<ConfigIdMask> Masks;

        public ConfigData()
        {
            Names = new List<ConfigIdName>();
            Masks = new List<ConfigIdMask>();
        }
    }

    public class Config
    {
        public ulong DataMask = 0xFFFFFFFFFFFFFFFF;
        public Dictionary<int, ulong> IdDataMaskDict;
        public Dictionary<int, string> IdNameDict;
        public Config()
        {
            IdDataMaskDict = new Dictionary<int, ulong>();
            IdNameDict = new Dictionary<int, string>();
        }

        public void AddIdName(string hexId, string name)
        {
            int id = Convert.ToInt32(hexId, 16);
            IdNameDict.Add(id, name);
        }

        public void AddIdDataMask(string hexId, ulong mask)
        {
            int id = Convert.ToInt32(hexId, 16);
            IdDataMaskDict.Add(id, mask);
        }

        public void SetIdDataMask(int id, ulong mask)
        {
            if (IdDataMaskDict.ContainsKey(id))
                IdDataMaskDict[id] = mask;
            else
                IdDataMaskDict.Add(id, mask);
        }
        public void SetIdName(int id, string name)
        {
            if (IdNameDict.ContainsKey(id))
                IdNameDict[id] = name;
            else
                IdNameDict.Add(id, name);
        }

        public ConfigData GetData()
        {
            var data = new ConfigData();
            data.DataMask = DataMask;
            foreach (var p in IdDataMaskDict)
                data.Masks.Add(new ConfigIdMask() { Id = p.Key, DataMask = p.Value });
            foreach (var p in IdNameDict)
                data.Names.Add(new ConfigIdName() { Id = p.Key, Name = p.Value });

            return data;
        }

        internal void SetData(ConfigData data)
        {
            DataMask = data.DataMask;
            IdDataMaskDict.Clear();
            IdNameDict.Clear();

            foreach (var v in data.Masks)
                IdDataMaskDict.Add(v.Id, v.DataMask);
            foreach (var v in data.Names)
                IdNameDict.Add(v.Id, v.Name);
        }

        internal void RemoveIdDataMask(int id)
        {
            if (IdDataMaskDict.ContainsKey(id))
                IdDataMaskDict.Remove(id);
        }

        internal void RemoveIdName(int id)
        {
            if (IdNameDict.ContainsKey(id))
                IdNameDict.Remove(id);
        }
    }

    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            var lines = (new JavaScriptSerializer()).Serialize(this);
            File.WriteAllText(fileName, lines);
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(fileName))
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
            return t;
        }
    }
}
