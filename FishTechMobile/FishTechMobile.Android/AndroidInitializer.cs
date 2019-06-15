using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Prism;
using Prism.Ioc;

namespace FishTechMobile.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.GetContainer().Register<CachedImageRenderer>(made: Made.Of(() => new CachedImageRenderer(Arg.Of<Android.Content.Context>())));
            // OR with Reflection
            //containerRegistry.GetContainer().Register<CachedImageRenderer>(made: Made.Of(typeof(CachedImageRenderer).GetConstructor(new[] { typeof(Android.Content.Context) })));
        }
    }
}