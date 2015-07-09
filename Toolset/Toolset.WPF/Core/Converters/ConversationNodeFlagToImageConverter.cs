using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Toolset.WPF.Core.Converters
{
     public class ConversationNodeFlagToImageConverter : IValueConverter
     {
          // This converts the result object to the foreground.
          public object Convert(object value, Type targetType,
              object parameter, System.Globalization.CultureInfo culture)
          {
               // Retrieve the format string and use it to format the value.
               string text = value as string;
               
               string result = @"Images\Conversation\";
               
               switch (text)
               {
                    case "CONDITION":
                         result += "IsCondition.png";
                         return result;
                    case "ACTION":
                         result += "IsAction.png";
                         return result;
                    case "BOTH":
                         result += "IsBoth.png";
                         return result;
                    default:
                    case "NONE":
                         result += "IsNone.png";
                         return result;
               }
          }

          // No need to implement converting back on a one-way binding 
          public object ConvertBack(object value, Type targetType,
              object parameter, System.Globalization.CultureInfo culture)
          {
               throw new NotImplementedException();
          }
     }
}
