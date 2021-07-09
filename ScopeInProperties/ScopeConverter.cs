using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Text;

namespace ScopeInProperties
{
    public class ScopeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(String)) return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(String)) return true;

            if (destinationType == typeof(InstanceDescriptor)) return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            String result = "";
            if (destinationType == typeof(String))
            {
                Scope scope = (Scope)value;
                result = scope.Min.ToString() + "," + scope.Max.ToString();
                return result;

            }

            if (destinationType == typeof(InstanceDescriptor))
            {
                ConstructorInfo ci = typeof(Scope).GetConstructor(new Type[] { typeof(Int32), typeof(Int32) });
                Scope scope = (Scope)value;
                return new InstanceDescriptor(ci, new object[] { scope.Min, scope.Max });
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                String[] v = ((String)value).Split(',');
                if (v.GetLength(0) != 2)
                {
                    throw new ArgumentException("Invalid parameter format");
                }

                Scope csf = new Scope();
                csf.Min = Convert.ToInt32(v[0]);
                csf.Max = Convert.ToInt32(v[1]);
                return csf;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(Scope), attributes);
        }
    }
}
