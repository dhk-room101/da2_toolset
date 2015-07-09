using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Toolset.WPF.Core.Converters
{
     public class ConversationNodeStateToBrushConverter : IValueConverter
     {
          // This converts the result object to the foreground.
          public object Convert(object value, Type targetType,
              object parameter, System.Globalization.CultureInfo culture)
          {
               // Retrieve the format string and use it to format the value.
               string text = value as string;
               
               Color color = new Color();
               
               switch (text)
               {
                    case "OWNER":
                         color = (Color)ColorConverter.ConvertFromString("#FFFF0000");//Red
                         return new SolidColorBrush(color);
                    case "PLAYER":
                         color = (Color)ColorConverter.ConvertFromString("#FF0000FF");//Blue
                         return new SolidColorBrush(color);
                    default:
                         color = (Color)ColorConverter.ConvertFromString("#FF999999");
                         return new SolidColorBrush(color);
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
