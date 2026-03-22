# api.md - 后端 API 接口文档

本文档描述 docmgt 文档管理系统后端 API 接口定义。

## 基础信息

- **基础 URL**: `http://localhost:8080/api` (待配置)
- **数据格式**: JSON
- **认证方式**: Token 认证

## API 接口

### 用户模块

| 方法 | 端点 | 描述 |
|------|------|------|
| POST | `/user/login` | 用户登录 |
| POST | `/user/logout` | 用户登出 |
| GET | `/user/info` | 获取当前用户信息 |
| GET | `/user/list` | 获取用户列表 |
| POST | `/user/create` | 创建用户 |
| PUT | `/user/update` | 更新用户 |
| DELETE | `/user/delete/{id}` | 删除用户 |

### 文档模块

| 方法 | 端点 | 描述 |
|------|------|------|
| GET | `/doc/list` | 获取文档列表 |
| GET | `/doc/detail/{id}` | 获取文档详情 |
| POST | `/doc/upload` | 上传文档 |
| PUT | `/doc/update` | 更新文档 |
| DELETE | `/doc/delete/{id}` | 删除文档 |
| GET | `/doc/download/{id}` | 下载文档 |
| GET | `/doc/versions/{id}` | 获取文档版本历史 |

### 分类模块

| 方法 | 端点 | 描述 |
|------|------|------|
| GET | `/category/list` | 获取分类列表 |
| POST | `/category/create` | 创建分类 |
| PUT | `/category/update` | 更新分类 |
| DELETE | `/category/delete/{id}` | 删除分类 |

### 日志模块

| 方法 | 端点 | 描述 |
|------|------|------|
| GET | `/log/list` | 获取操作日志列表 |

## 响应格式

### 成功响应
```json
{
  "code": 200,
  "message": "success",
  "data": {}
}
```

### 错误响应
```json
{
  "code": 400,
  "message": "错误描述",
  "data": null
}
```

## 技术约束

- 目标框架：.NET Framework 4.5
- 开发语言：C#
- UI 框架：WPF
