using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Services.Helpers
{
    class JsonCustomConverter
    {
        public class BaseConverter : JsonCreationConverter<Base>
        {
            protected override Base Create(Type objectType, JObject jObject)
            {
                if (FieldExists("messages", jObject))
                {
                    foreach (var message in jObject["messages"])
                    {
                        var tsValue = message["ts"];
                        var dtTs = UnixTime.FromUnixTime(Convert.ToInt64(Regex.Replace(tsValue.ToString(), @"\.\d*", "")));
                        message["ts"] = dtTs.ToString("o");
                    }
                }
                return new Base();
            }

            private bool FieldExists(string fieldName, JObject jObject)
            {
                return jObject[fieldName] != null;
            }
        }

        public abstract class JsonCreationConverter<T> : JsonConverter
        {
            /// <summary>
            /// Create an instance of objectType, based properties in the JSON object
            /// </summary>
            /// <param name="objectType">type of object expected</param>
            /// <param name="jObject">
            /// contents of JSON object that will be deserialized
            /// </param>
            /// <returns></returns>
            protected abstract T Create(Type objectType, JObject jObject);

            public override bool CanConvert(Type objectType)
            {
                return typeof(T).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader,
                                            Type objectType,
                                             object existingValue,
                                             JsonSerializer serializer)
            {
                // Load JObject from stream
                JObject jObject = JObject.Load(reader);

                // Create target object based on JObject
                T target = Create(objectType, jObject);

                // Populate the object properties
                serializer.Populate(jObject.CreateReader(), target);

                return target;
            }

            public override void WriteJson(JsonWriter writer,
                                           object value,
                                           JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
