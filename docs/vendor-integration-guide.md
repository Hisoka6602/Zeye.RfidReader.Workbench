# 厂商接入指南

## 新增厂商步骤

1. 在 Domain 的 `RfidReaderVendorType` 增加厂商枚举。
2. 在 `Infrastructure/Drivers/Vendors/{VendorName}` 新增 Session。
3. 在 Infrastructure 注册 `RfidReaderDriverDescriptor`。
4. 增加配置样例。
5. 增加最小测试。
6. 确保 Avalonia 和 Application 不引用厂商 SDK。

## 目录约定

厂商驱动代码只能放在：

```text
src/Zeye.RfidReader.Workbench.Infrastructure/Drivers/Vendors/{VendorName}
```

厂商 SDK、连接细节、协议解析、设备资源释放和异常映射都应封装在该目录及 Infrastructure 注册逻辑中。

## 配置样例

```json
{
  "RfidReaders": {
    "Devices": [
      {
        "ReaderCode": "SIM-001",
        "ReaderName": "模拟读码器",
        "VendorType": "Simulated",
        "ProtocolType": "VendorSdk",
        "IsEnabled": true,
        "Sdk": {
          "Endpoint": "simulated://local"
        },
        "Read": {
          "DuplicateWindowMs": 500,
          "IsAutoStartEnabled": false,
          "IsRawFrameLoggingEnabled": false
        }
      }
    ]
  }
}
```

## 最小测试建议

- 验证新增厂商与协议组合可以注册成功。
- 验证重复注册抛出中文异常。
- 验证未注册厂商与协议组合抛出中文异常。
- 验证工厂能够基于配置创建对应 Session。
- 验证 Session 的连接、断开、启动读码、停止读码与释放方法可正常调用。

## 接入门禁

- 不得在 Avalonia 层直接引用厂商 SDK。
- 不得在 Application 层写 `if vendor == xxx` 或类似厂商分支。
- 不得修改 Domain 领域模型来适配单一厂商。
- 不得把 TCP Socket、串口读码或 SDK 细节放入 Application。
- 不得让 Infrastructure 依赖 Avalonia。
