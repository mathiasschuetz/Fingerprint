using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Plugin.Fingerprint;

namespace Fingerprint
{
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        #region fields

        private AppCompatActivity _currentActivity;

        #endregion

        #region Application

        public MainApplication(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            this.RegisterActivityLifecycleCallbacks(this);

            CrossFingerprint.SetCurrentActivityResolver(() => this._currentActivity as Activity);
            //CrossFingerprint.SetDialogFragmentType<MyCustomDialogFragment>();
            CrossFingerprint.DialogEnabled = true;
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            this.UnregisterActivityLifecycleCallbacks(this);
        }

        #endregion

        #region IActivityLifecycleCallbacks

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            this._currentActivity = activity as AppCompatActivity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            this._currentActivity = activity as AppCompatActivity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            this._currentActivity = activity as AppCompatActivity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }

        #endregion
    }
}