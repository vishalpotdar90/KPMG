
using System;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace NestedObject
{
    public class Class1
    {
        static void Main(string[] args)
        {
            static object GetNestedObject(JObject obj, string searchkey)
            {
                var keys = searchkey.Split('/');
                JToken currentobj = obj;
                foreach (var k in keys)
                {
                    currentobj = currentobj[k];
                    if (currentobj == null) return "Key {searchkey} not exists";
                }
                return currentobj;
            }
            /*Tests*/
            JObject obj = JObject.Parse("{\"a\":{\"b\":{\"c\":\"d\"}}}");
            var value = GetNestedObject(obj, "a/b/c");
            Console.WriteLine(value); // Output: "d"
            obj = JObject.Parse("{\"x\":{\"y\":{\"z\":\"a\"}}}");
            value = GetNestedObject(obj, "x/y/z");
            Console.WriteLine(value); // Output:  "a" 
     
        }
    }
}
