aot_test 用于测试 AOT 发布的结果 [2023-11-19]

| 测试项目 | 发布耗时 | 发布后 .exe 体积 | 发布后 .pdb 体积 | 通过AOT |
| -- | -- | -- | -- | -- |
| FreeSql v3.2.805 + Sqlite | 31.882 秒 | 16,927KB | 123,812KB | 通过 |
| SqlSugar v5.1.4.117 + Sqlite | 111.002 秒 | 50,133KB | 346,412KB | 通过 |
| EFCore v8.0 + Sqlite | 50.749 | 17,410KB | 168,788KB | 未通过 |
| DapperAOT | 未测试（支持） | 未测试（支持） | 未测试（支持） | 通过 |

如果大家对 AOT 有兴趣，我后面会持续分享自己的经验，PS mysql 测试也是没问题的，其他数据库如果有使用问题可以与我交流。

## FreeSql v3.2.805 + Sqlite

```shell
发布耗时 31.882 秒

orm_freesql.exe    ( 16,927KB)
orm_freesql.pdb    (123,812KB)
SQLite.Interop.dll (  1,723KB)

E:\github\aot_test\orm_freesql\bin\Release\net8.0\publish\win-x64>orm_freesql.exe
【FreeSql AOT】开始测试...
Insert 1条 80ms
Select 1条 5ms
Update 1条 86ms
Select 1条 0ms
Delete 1条 74ms
【FreeSql AOT】测试结束.
```

PS：没有对 AOT 的支持做专门改进，都是老代码。

## SqlSugar v5.1.4.117 + Sqlite

程序代码设置要求：

```csharp
StaticConfig.EnableAot = true;
```

```shell
发布耗时 01:51.002 分钟

orm_sqlsugar.exe                 ( 50,133KB)
orm_sqlsugar.pdb                 (346,412KB)
e_sqlite3                        (  1,597KB)
Microsoft.Data.SqlClient.SNI.dll (    499KB)

E:\github\aot_test\orm_sqlsugar\bin\Release\net8.0\publish\win-x64>orm_sqlsugar.exe
【SqlSugar AOT】开始测试...
Insert 1条 214ms
Select 1条 29ms
Update 1条 119ms
Select 1条 0ms
Delete 1条 82ms
【SqlSugar AOT】测试结束.
```

https://www.cnblogs.com/sunkaixuan/p/17839825.html
《NET8 ORM 使用AOT SqlSugar posted》 @ 2023-11-17 22:31 果糖大数据科技

这篇文章是是针对 FreeSql 2023-11-16 发的 AOT 文章发的么？

https://www.cnblogs.com/FreeSql/p/17836000.html
《.NET8.0 AOT 经验分享 FreeSql/FreeRedis/FreeScheduler 均已通过测试》 posted @ 2023-11-16 14:18  FreeSql

FreeSql 一年没发文章了，发一次就被针对 seo 关键字，赶鸭子上架功能，厉害的反射性能怎么办啊？~~

提示：测试你不是贬低你

## EFCore v8.0 + Sqlite

```shell
发布耗时 01:22.813 分钟

orm_efcore.exe     ( 17,410KB)
orm_efcore.pdb     (168,788KB)
e_sqlite3          (  1,652KB)

E:\github\aot_test\orm_efcore\bin\Release\net8.0\publish\win-x64>orm_efcore.exe
【EFCore AOT】开始测试...
Unhandled Exception: System.InvalidOperationException: Model building is not supported when publishing with NativeAOT. Use a compiled model.
   at Microsoft.EntityFrameworkCore.Internal.DbContextServices.CreateModel(Boolean) + 0x148
   at Microsoft.EntityFrameworkCore.Internal.DbContextServices.get_Model() + 0x1c
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite, RuntimeResolverContext) + 0x83
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite, RuntimeResolverContext) + 0x83
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite, RuntimeResolverContext) + 0x83
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite, RuntimeResolverContext) + 0x83
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite, RuntimeResolverContext) + 0x83
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite, RuntimeResolverContext, ServiceProviderEngineScope, RuntimeResolverLock) + 0xc2
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite, RuntimeResolverContext) + 0x35
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument) + 0xa4
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite, ServiceProviderEngineScope) + 0x3d
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(ServiceIdentifier, ServiceProviderEngineScope) + 0xa3
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope.GetService(Type) + 0x42
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider, Type) + 0x50
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T](IServiceProvider) + 0x29
   at Microsoft.EntityFrameworkCore.DbContext.get_DbContextDependencies() + 0x32
   at Microsoft.EntityFrameworkCore.DbContext.get_ContextServices() + 0x14f
   at Microsoft.EntityFrameworkCore.DbContext.get_DbContextDependencies() + 0x22
   at Microsoft.EntityFrameworkCore.DbContext.EntryWithoutDetectChanges[TEntity](TEntity entity) + 0x18
   at Microsoft.EntityFrameworkCore.DbContext.SetEntityState[TEntity](TEntity entity, EntityState entityState) + 0x1d
   at Program.<Main>$(String[] args) + 0x1da
   at orm_efcore!<BaseAddress>+0x7c2ab0
```

## Dapper

Dapper 已经出了新的 DapperAOT 版本，就不测试了，100%支持 AOT。