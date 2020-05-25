//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: device_connect.proto
// Note: requires additional types generated from: common.proto
namespace Nuctech.NIS.Common.Protocol
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceRegMsg")]
  public partial class SG_DeviceRegMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceRegMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private uint _device_type;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"device_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint device_type
    {
      get { return _device_type; }
      set { _device_type = value; }
    }
    private string _device_id;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"device_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string device_id
    {
      get { return _device_id; }
      set { _device_id = value; }
    }
    private string _ip;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"ip", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ip
    {
      get { return _ip; }
      set { _ip = value; }
    }
    private string _description;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"description", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string description
    {
      get { return _description; }
      set { _description = value; }
    }
    private string _device_serial_no = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"device_serial_no", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string device_serial_no
    {
      get { return _device_serial_no; }
      set { _device_serial_no = value; }
    }
    private string _device_protocol_version = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"device_protocol_version", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string device_protocol_version
    {
      get { return _device_protocol_version; }
      set { _device_protocol_version = value; }
    }
    private string _device_softwareversion = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"device_softwareversion", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string device_softwareversion
    {
      get { return _device_softwareversion; }
      set { _device_softwareversion = value; }
    }
    private string _device_mcuversion = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"device_mcuversion", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string device_mcuversion
    {
      get { return _device_mcuversion; }
      set { _device_mcuversion = value; }
    }
    private string _device_algorithmversion = "";
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"device_algorithmversion", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string device_algorithmversion
    {
      get { return _device_algorithmversion; }
      set { _device_algorithmversion = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceRegEchoMsg")]
  public partial class SG_DeviceRegEchoMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceRegEchoMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private SG_DeviceRegEchoMsg.RegResultType _result;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public SG_DeviceRegEchoMsg.RegResultType result
    {
      get { return _result; }
      set { _result = value; }
    }
    private string _error_message = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"error_message", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string error_message
    {
      get { return _error_message; }
      set { _error_message = value; }
    }
    private uint _heartbeat_timeout = (uint)5;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"heartbeat_timeout", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((uint)5)]
    public uint heartbeat_timeout
    {
      get { return _heartbeat_timeout; }
      set { _heartbeat_timeout = value; }
    }
    private uint _heartbeat_interval = (uint)5;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"heartbeat_interval", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((uint)5)]
    public uint heartbeat_interval
    {
      get { return _heartbeat_interval; }
      set { _heartbeat_interval = value; }
    }
    private string _image_upload_path;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"image_upload_path", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string image_upload_path
    {
      get { return _image_upload_path; }
      set { _image_upload_path = value; }
    }
    private SG_DeviceRegEchoMsg.OfflineUploadOrderType _offline_upload_order = SG_DeviceRegEchoMsg.OfflineUploadOrderType.OldestFirst;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"offline_upload_order", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(SG_DeviceRegEchoMsg.OfflineUploadOrderType.OldestFirst)]
    public SG_DeviceRegEchoMsg.OfflineUploadOrderType offline_upload_order
    {
      get { return _offline_upload_order; }
      set { _offline_upload_order = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"RegResultType")]
    public enum RegResultType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"SUCCESSFUL", Value=0)]
      SUCCESSFUL = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FAILED", Value=1)]
      FAILED = 1
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"OfflineUploadOrderType")]
    public enum OfflineUploadOrderType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"OldestFirst", Value=0)]
      OldestFirst = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NewestFirst", Value=1)]
      NewestFirst = 1
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceUnRegMsg")]
  public partial class SG_DeviceUnRegMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceUnRegMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private string _device_id = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"device_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string device_id
    {
      get { return _device_id; }
      set { _device_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceUnRegEchoMsg")]
  public partial class SG_DeviceUnRegEchoMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceUnRegEchoMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceStateMsg")]
  public partial class SG_DeviceStateMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceStateMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private SG_DeviceStateMsg.DeviceStateType _work_state;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"work_state", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public SG_DeviceStateMsg.DeviceStateType work_state
    {
      get { return _work_state; }
      set { _work_state = value; }
    }
    private DeviceModeType _device_mode;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"device_mode", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public DeviceModeType device_mode
    {
      get { return _device_mode; }
      set { _device_mode = value; }
    }
    private double _current_time = default(double);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"current_time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(double))]
    public double current_time
    {
      get { return _current_time; }
      set { _current_time = value; }
    }
    private uint _error_code = default(uint);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"error_code", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint error_code
    {
      get { return _error_code; }
      set { _error_code = value; }
    }
    private byte[] _error_desc = null;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"error_desc", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] error_desc
    {
      get { return _error_desc; }
      set { _error_desc = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"DeviceStateType")]
    public enum DeviceStateType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"INIT", Value=0)]
      INIT = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NORMAL", Value=1)]
      NORMAL = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FAILURE", Value=2)]
      FAILURE = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFLINE", Value=3)]
      OFFLINE = 3
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceStateEchoMsg")]
  public partial class SG_DeviceStateEchoMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceStateEchoMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private SG_DeviceStateEchoMsg.ServerStateType _server_state;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"server_state", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public SG_DeviceStateEchoMsg.ServerStateType server_state
    {
      get { return _server_state; }
      set { _server_state = value; }
    }
    private double _current_time = default(double);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"current_time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(double))]
    public double current_time
    {
      get { return _current_time; }
      set { _current_time = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"ServerStateType")]
    public enum ServerStateType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"READY", Value=0)]
      READY = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NOT_READY", Value=1)]
      NOT_READY = 1
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DiagnoseRequestMsg")]
  public partial class SG_DiagnoseRequestMsg : global::ProtoBuf.IExtensible
  {
    public SG_DiagnoseRequestMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DiagnoseRequestEchoMsg")]
  public partial class SG_DiagnoseRequestEchoMsg : global::ProtoBuf.IExtensible
  {
    public SG_DiagnoseRequestEchoMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private uint _result;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private string _fail_reason = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"fail_reason", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fail_reason
    {
      get { return _fail_reason; }
      set { _fail_reason = value; }
    }
    private string _error_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"error_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string error_code
    {
      get { return _error_code; }
      set { _error_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DiagnoseDataMsg")]
  public partial class SG_DiagnoseDataMsg : global::ProtoBuf.IExtensible
  {
    public SG_DiagnoseDataMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private double _diagnose_time;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"diagnose_time", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double diagnose_time
    {
      get { return _diagnose_time; }
      set { _diagnose_time = value; }
    }
    private double _status_disk;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"status_disk", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double status_disk
    {
      get { return _status_disk; }
      set { _status_disk = value; }
    }
    private string _status_passport = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"status_passport", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_passport
    {
      get { return _status_passport; }
      set { _status_passport = value; }
    }
    private string _status_sensor = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"status_sensor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_sensor
    {
      get { return _status_sensor; }
      set { _status_sensor = value; }
    }
    private string _status_transmission = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"status_transmission", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_transmission
    {
      get { return _status_transmission; }
      set { _status_transmission = value; }
    }
    private string _status_face = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"status_face", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_face
    {
      get { return _status_face; }
      set { _status_face = value; }
    }
    private string _status_mcu = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"status_mcu", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_mcu
    {
      get { return _status_mcu; }
      set { _status_mcu = value; }
    }
    private string _status_camera = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"status_camera", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string status_camera
    {
      get { return _status_camera; }
      set { _status_camera = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceHeartbeatTimeoutMsg")]
  public partial class SG_DeviceHeartbeatTimeoutMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceHeartbeatTimeoutMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private string _device_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"device_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string device_id
    {
      get { return _device_id; }
      set { _device_id = value; }
    }
    private string _device_description;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"device_description", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string device_description
    {
      get { return _device_description; }
      set { _device_description = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceStateChangeRequestMsg")]
  public partial class SG_DeviceStateChangeRequestMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceStateChangeRequestMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private SG_DeviceStateChangeRequestMsg.DeviceStateType _work_state;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"work_state", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public SG_DeviceStateChangeRequestMsg.DeviceStateType work_state
    {
      get { return _work_state; }
      set { _work_state = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"DeviceStateType")]
    public enum DeviceStateType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"INIT", Value=0)]
      INIT = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"NORMAL", Value=1)]
      NORMAL = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FAILURE", Value=2)]
      FAILURE = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"OFFLINE", Value=3)]
      OFFLINE = 3
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceControlMsg")]
  public partial class SG_DeviceControlMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceControlMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private string _device_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"device_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string device_id
    {
      get { return _device_id; }
      set { _device_id = value; }
    }
    private DeviceControlType _control_type;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"control_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public DeviceControlType control_type
    {
      get { return _control_type; }
      set { _control_type = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceControlEchoMsg")]
  public partial class SG_DeviceControlEchoMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceControlEchoMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private string _device_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"device_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string device_id
    {
      get { return _device_id; }
      set { _device_id = value; }
    }
    private DeviceControlType _control_type;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"control_type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public DeviceControlType control_type
    {
      get { return _control_type; }
      set { _control_type = value; }
    }
    private uint _result;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private string _desc = "";
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"desc", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string desc
    {
      get { return _desc; }
      set { _desc = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceRunModeSwitchMsg")]
  public partial class SG_DeviceRunModeSwitchMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceRunModeSwitchMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private DeviceModeType _device_mode;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"device_mode", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public DeviceModeType device_mode
    {
      get { return _device_mode; }
      set { _device_mode = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SG_DeviceRunModeSwitchEchoMsg")]
  public partial class SG_DeviceRunModeSwitchEchoMsg : global::ProtoBuf.IExtensible
  {
    public SG_DeviceRunModeSwitchEchoMsg() {}
    
    private MsgHeader _header;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"header", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public MsgHeader header
    {
      get { return _header; }
      set { _header = value; }
    }
    private uint _result;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"result", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint result
    {
      get { return _result; }
      set { _result = value; }
    }
    private string _fail_reason = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"fail_reason", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string fail_reason
    {
      get { return _fail_reason; }
      set { _fail_reason = value; }
    }
    private string _error_code = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"error_code", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string error_code
    {
      get { return _error_code; }
      set { _error_code = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"DeviceModeType")]
    public enum DeviceModeType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"VERIFICATION", Value=0)]
      VERIFICATION = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAINTAIN", Value=1)]
      MAINTAIN = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PASSTHROUGH", Value=2)]
      PASSTHROUGH = 2
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"DeviceControlType")]
    public enum DeviceControlType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"SOFTRESET", Value=1)]
      SOFTRESET = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"COMPUTERESET", Value=2)]
      COMPUTERESET = 2
    }
  
}