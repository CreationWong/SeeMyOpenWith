![](./img/SeeMyOpenWith.png)

# See My Open With - 查看我的打开方式

一个查看、~~修改~~ 、删除 打开方式 菜单项的小工具. 

基于 .NET 开发.

## 公告
> [!CAUTION]
> 本程序涉及**对系统注册表修改**操作,任何误操作均可能导致**不可挽回**后果! 
>
> 请在专业人员指导或**明白自己在做什么**情况下使用! 
>
> 如出现任何与程序(此处程序指由**本仓库完整代码编译的、未经修改的**或由**本仓库开发者**编译的**发行程序**)本身无关的情况造成财产损失,均由使用者自行承担!

> [!WARNING]
> 本项目惰性开发中,可能出现大量 BUG . 如遇到 BUG 请及时向开发者反馈.
>
> 为了系统安全,请使用最新版本!

[#1](https://github.com/CreationWong/SeeMyOpenWith/discussions/1#discussion-8415471)

## 基础交互逻辑
此处为程序交互与运行逻辑.

```mermaid
  sequenceDiagram
    participant U as 用户
    create participant EXE as 程序
    U->>EXE: 启动程序
    create participant REG as 注册表
    EXE->>REG: 打开注册表
    loop 遍历注册表
        EXE->>REG: 读取注册表项
        REG->>EXE: 返回注册表项
        EXE->>U: 显示读取到的注册表值
    end
    par 联网搜索
        U->>EXE: 联网搜索命令
        create participant NET as 浏览器
        EXE->>NET: 打开浏览器
        U-->>EXE: 指定项
        EXE->>NET: 调用搜索引擎 API
        NET-->NET: 搜索引擎搜索
        NET<<-->>U: 用户与浏览器交互
        destroy NET
        U-xNET: 用户关闭浏览器
    and 删除
        U->>EXE: 删除命令
        U-->>EXE: 指定项
        loop 遍历注册表
          EXE->>REG: 删除目标注册表键
        end
        loop 遍历注册表
          EXE->>REG: 读取注册表项
          REG->>EXE: 返回注册表项
          EXE->>U: 显示读取到的注册表值
        end
    and 刷新
        U->>EXE: 刷新命令
        loop 遍历注册表
          EXE->>REG: 读取注册表项
          REG->>EXE: 返回注册表项
          EXE->>U: 显示读取到的注册表值
        end
    end
    destroy REG
    EXE-xREG: 关闭注册表
    destroy EXE
    U-xEXE: 用户关闭程序
```

## 路线图

- [ ] 基础功能实现
  - [ ] 修改
  - [x] 刷新

- [ ] 完善 UI
- [ ] 添加额外功能
  - [ ] 搜索
  - [x] 热键

- [ ] 添加操作回滚
- [x] 优化代码逻辑
- [x] 采用 .Net 9.0

## 协议

采用 GNU GENERAL PUBLIC LICENSE Version 3 协议分发大部分代码和所有可执行程序.

## 开源软件使用许可

### Serilog

用于程序运行日志记录.

采用 [Apache-2.0 license](https://github.com/serilog/serilog?tab=readme-ov-file#Apache-2.0-1-ov-file) 许可协议



## 安全扫描 & 构建检查

[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FCreationWong%2FSeeMyOpenWith.svg?type=large&issueType=license)](https://app.fossa.com/projects/git%2Bgithub.com%2FCreationWong%2FSeeMyOpenWith?ref=badge_large&issueType=license)

自动构建

[![Build](https://github.com/CreationWong/SeeMyOpenWith/actions/workflows/build.yml/badge.svg?branch=main)](https://github.com/CreationWong/SeeMyOpenWith/actions/workflows/build.yml)

## 特别感谢

本项目使用 **JetBrains Rider** 进行代码编写、调试. 使用 **Visual Studio 2022** 进行 UI 绘制、编译.

<img src="https://resources.jetbrains.com/storage/products/company/brand/logos/Rider.svg" alt="Rider logo." >
