//Autogenerated by Thrift Compiler (0.13.0)
#if NETFRAMEWORK
using System;
using System.Text;
using Thrift.Protocol;

namespace Hazelcast.Remote
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Response : TBase
  {
    private bool _success;
    private string _message;
    private byte[] _result;

    public bool Success
    {
      get
      {
        return _success;
      }
      set
      {
        __isset.success = true;
        this._success = value;
      }
    }

    public string Message
    {
      get
      {
        return _message;
      }
      set
      {
        __isset.message = true;
        this._message = value;
      }
    }

    public byte[] Result
    {
      get
      {
        return _result;
      }
      set
      {
        __isset.result = true;
        this._result = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool success;
      public bool message;
      public bool result;
    }

    public Response() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.Bool) {
                Success = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Message = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Result = iprot.ReadBinary();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("Response");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.success) {
          field.Name = "success";
          field.Type = TType.Bool;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Success);
          oprot.WriteFieldEnd();
        }
        if (Message != null && __isset.message) {
          field.Name = "message";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Message);
          oprot.WriteFieldEnd();
        }
        if (Result != null && __isset.result) {
          field.Name = "result";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteBinary(Result);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Response(");
      bool __first = true;
      if (__isset.success) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Success: ");
        __sb.Append(Success);
      }
      if (Message != null && __isset.message) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Message: ");
        __sb.Append(Message);
      }
      if (Result != null && __isset.result) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Result: ");
        __sb.Append(Result);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif