using System;
using System.Windows;

namespace Lab2_IvanovAV_BPI_24_01
{
    public partial class App : Application
    {
        public void ChangeTheme(bool lightTheme)
        {
            ResourceDictionary lightThemeDictionary = null;

            foreach (ResourceDictionary dictionary in Resources.MergedDictionaries)
            {
                if (dictionary.Source?.OriginalString == "Styles/LightTheme.xaml")
                {
                    lightThemeDictionary = dictionary;
                    break;
                }
            }

            if (lightTheme && lightThemeDictionary == null)
            {
                Resources.MergedDictionaries.Add(new ResourceDictionary
                {
                    Source = new Uri("Styles/LightTheme.xaml", UriKind.Relative)
                });
            }
            else if (!lightTheme && lightThemeDictionary != null)
            {
                Resources.MergedDictionaries.Remove(lightThemeDictionary);
            }
        }
    }
}