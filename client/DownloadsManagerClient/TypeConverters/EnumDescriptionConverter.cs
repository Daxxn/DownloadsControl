﻿using System;
using System.ComponentModel;
using System.Reflection;

namespace DownloadsManagerClient.TypeConverters
{
   public class EnumDescriptionConverter : EnumConverter
   {
      public EnumDescriptionConverter(Type type) : base(type) { }

      public override object ConvertTo(
         ITypeDescriptorContext context,
         System.Globalization.CultureInfo culture,
         object value,
         Type destinationType
      )
      {
         if (destinationType == typeof(string))
         {
            if (value != null)
            {
               FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
               if (fieldInfo != null)
               {
                  var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                  return ((attributes.Length > 0) && (!String.IsNullOrEmpty(attributes[0].Description))) ? attributes[0].Description : value.ToString();
               }
            }

            return String.Empty;
         }

         return base.ConvertTo(context, culture, value, destinationType);
      }
   }
}
