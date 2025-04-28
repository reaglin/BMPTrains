using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMPTrains_2020.DomainCode;

namespace BMPTrains_2020
{
    static class Globals
    {
        private static DomainCode.BMPTrainsProject project = new BMPTrainsProject();

        public static BMPTrainsProject Project { get => project; set => project = value; }

        public static string HelpURL = "http://roneaglin.online/bmptrains/";
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class Meta : Attribute
    {
        public string Description { get; }
        public string Units { get; }
        public string Format { get; }

        public Meta (string description, string units = "", string format = "")
        {
            Description = description;
            Units = units;
            Format = format;
        }
        public static string Print(object o, string propertyName)
        {
            // v is the object that has the property, propertyName is the name of the property
            string s = "";
            var object_type = o.GetType();                          // The type of the object passed, in this case a domain object
            var property = object_type.GetProperty(propertyName);   // The specific property (by name) of the variable to print in object o
            var property_type = property.PropertyType; 

            if (property_type != null)
            {
                var metaInfo = (Meta)Attribute.GetCustomAttribute(property, typeof(Meta));
                try
                {
                    s = metaInfo.Description;
                    if (metaInfo.Units != "") s += " (" + metaInfo.Units + "): ";
                    
                    if (property_type == typeof(Double)) s += ((Double)property.GetValue(o)).ToString(metaInfo.Format);
                    if (property_type == typeof(int)) s += ((int)property.GetValue(o)).ToString(metaInfo.Format);
                    return s;
                }
                catch
                {
                    return $"Print Info not found for {propertyName}.";
                }
            }
            return s;
        }
    }
}
