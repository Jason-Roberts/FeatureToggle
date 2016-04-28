﻿using FeatureToggle.Core;
using FeatureToggle.Providers;

// ReSharper disable CheckNamespace
namespace FeatureToggle.Toggles
// ReSharper restore CheckNamespace
{
    public abstract class SimpleFeatureToggle : IFeatureToggle
    {
        protected SimpleFeatureToggle()
        {
#if (WINDOWS_PHONE || NETFX_CORE)

            ToggleValueProvider = new ApplicationResourcesSettingsProvider();

#else

            ToggleValueProvider = new AppSettingsProvider();
#endif
        }


        public virtual IBooleanToggleValueProvider ToggleValueProvider { get; set; }


        public virtual bool FeatureEnabled
        {
            get { return ToggleValueProvider.EvaluateBooleanToggleValue(this); }
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
