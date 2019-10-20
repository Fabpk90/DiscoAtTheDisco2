#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class AkInitializationSettings : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkInitializationSettings(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkInitializationSettings obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  internal virtual void setCPtr(global::System.IntPtr cPtr) {
    Dispose();
    swigCPtr = cPtr;
  }

  ~AkInitializationSettings() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkInitializationSettings(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public AkInitializationSettings() : this(AkSoundEnginePINVOKE.CSharp_new_AkInitializationSettings(), true) {
  }

  public AkMemSettings memSettings { set { AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_memSettings_set(swigCPtr, AkMemSettings.getCPtr(value)); } 
    get {
      global::System.IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_memSettings_get(swigCPtr);
      AkMemSettings ret = (cPtr == global::System.IntPtr.Zero) ? null : new AkMemSettings(cPtr, false);
      return ret;
    } 
  }

  public AkStreamMgrSettings streamMgrSettings { set { AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_streamMgrSettings_set(swigCPtr, AkStreamMgrSettings.getCPtr(value)); } 
    get {
      global::System.IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_streamMgrSettings_get(swigCPtr);
      AkStreamMgrSettings ret = (cPtr == global::System.IntPtr.Zero) ? null : new AkStreamMgrSettings(cPtr, false);
      return ret;
    } 
  }

  public AkDeviceSettings deviceSettings { set { AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_deviceSettings_set(swigCPtr, AkDeviceSettings.getCPtr(value)); } 
    get {
      global::System.IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_deviceSettings_get(swigCPtr);
      AkDeviceSettings ret = (cPtr == global::System.IntPtr.Zero) ? null : new AkDeviceSettings(cPtr, false);
      return ret;
    } 
  }

  public AkInitSettings initSettings { set { AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_initSettings_set(swigCPtr, AkInitSettings.getCPtr(value)); } 
    get {
      global::System.IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_initSettings_get(swigCPtr);
      AkInitSettings ret = (cPtr == global::System.IntPtr.Zero) ? null : new AkInitSettings(cPtr, false);
      return ret;
    } 
  }

  public AkPlatformInitSettings platformSettings { set { AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_platformSettings_set(swigCPtr, AkPlatformInitSettings.getCPtr(value)); } 
    get {
      global::System.IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_platformSettings_get(swigCPtr);
      AkPlatformInitSettings ret = (cPtr == global::System.IntPtr.Zero) ? null : new AkPlatformInitSettings(cPtr, false);
      return ret;
    } 
  }

  public AkMusicSettings musicSettings { set { AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_musicSettings_set(swigCPtr, AkMusicSettings.getCPtr(value)); } 
    get {
      global::System.IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_musicSettings_get(swigCPtr);
      AkMusicSettings ret = (cPtr == global::System.IntPtr.Zero) ? null : new AkMusicSettings(cPtr, false);
      return ret;
    } 
  }

  public uint preparePoolSize { set { AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_preparePoolSize_set(swigCPtr, value); }  get { return AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_preparePoolSize_get(swigCPtr); } 
  }

  public AkUnityPlatformSpecificSettings unityPlatformSpecificSettings { set { AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_unityPlatformSpecificSettings_set(swigCPtr, AkUnityPlatformSpecificSettings.getCPtr(value)); } 
    get {
      global::System.IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkInitializationSettings_unityPlatformSpecificSettings_get(swigCPtr);
      AkUnityPlatformSpecificSettings ret = (cPtr == global::System.IntPtr.Zero) ? null : new AkUnityPlatformSpecificSettings(cPtr, false);
      return ret;
    } 
  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.